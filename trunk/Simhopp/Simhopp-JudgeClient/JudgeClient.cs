using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simhopp;

namespace Simhopp_JudgeClient
{
    public class JudgeClient : Simhopp.IJudgeClient
    {
        public ConcurrentQueue<SimhoppMessage> Messages { get; set; }
        public EventPresenter Presenter { get; set; }
        private Thread _serverThread;
        private FormJudgeClientView _view;
        private UdpClient client;
        private IPEndPoint ipep;

        public JudgeClient(FormJudgeClientView view)
        {
            _view = view;
        }

        private delegate void ProcessMessage(SimhoppMessage msg);
        private void PopulateJudgeList(SimhoppMessage msg)
        {
            try
            {
                ProcessMessage d = new ProcessMessage(_view.PopulateJudgeList);
                _view.Invoke(d, msg);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        private  void AssignLogin(SimhoppMessage msg)
        {
            try
            {
                ProcessMessage d = new ProcessMessage(_view.AssignLogin);
                _view.Invoke(d, msg);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        private  void LogMessage(SimhoppMessage msg)
        {
            return;
            try
            {
                ProcessMessage d = new ProcessMessage(_view.LogMessage);
                _view.Invoke(d, msg);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        public void Start()
        {
            Messages = new ConcurrentQueue<SimhoppMessage>();

            ThreadStart ts = new ThreadStart(ServerFinder);
            _serverThread = new Thread(ts) {IsBackground = true};
            _serverThread.Start();
        }

        /// <summary>
        /// Letar efter server och upprättar en anslutning
        /// </summary>
        private void ServerFinder()
        {
            //Broadcasta ping-meddelande
            client = new UdpClient();
            ipep = new IPEndPoint(IPAddress.Any, 0);
            client.EnableBroadcast = true;

            SimhoppMessage msg = SendReceive(SimhoppMessage.PingMessage(), true);
            
            switch (msg.Action)
            {
                case SimhoppMessage.ClientAction.List:
                    PopulateJudgeList(msg);
                    break;
            }

            LogMessage(msg);

            //Klient-tråd
            //Tar emot meddelanden från servern
            while ( true )
            {
                try
                {
                    Thread.Sleep(100);

                    msg = SendReceive();

                    if (msg == null)
                        continue;

                    switch (msg.Action)
                    {
                        case SimhoppMessage.ClientAction.List:
                            PopulateJudgeList(msg);
                            break;
                        case SimhoppMessage.ClientAction.AssignId:
                            AssignLogin(msg);
                            break;
                        case SimhoppMessage.ClientAction.SubmitScore:
                            if (Presenter != null)
                                Presenter.SubmitClientScore(msg.Value, msg.Id, msg.Status.RoundIndex, msg.Status.DiverIndex);
                            break;
                        case SimhoppMessage.ClientAction.RequestScore:
                            if (Presenter != null)
                                Presenter.ScoreRequested(msg);
                            break;
                        case SimhoppMessage.ClientAction.StatusUpdate:
                            if (Presenter != null)
                                Presenter.StatusUpdated(msg);
                            break;
                        case SimhoppMessage.ClientAction.ServerTerminating:
                            if (Presenter != null)
                                Presenter.Close(true);
                            Application.Exit();
                            break;
                    }

                    LogMessage(msg);

                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);
                }
            }
        }

        private  SimhoppMessage SendReceive(SimhoppMessage msg = null, bool broadcast = false)
        {
            byte[] data;
            string responseData;
            SimhoppMessage responseMsg;
            if (msg == null && !Messages.TryDequeue(out msg))
            {
                try
                {
                    client.Client.ReceiveTimeout = 1000;
                    data = client.Receive(ref ipep);
                    responseData = Encoding.ASCII.GetString(data);

                    responseMsg = SimhoppMessage.Deserialize(responseData);

                    return responseMsg;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            if (msg == null)
                return null;

            data = Encoding.ASCII.GetBytes(msg.Serialize());

            int tries = 0;
            while (true)
            {
                tries++;
                try
                {
                    //Öka timeout för vaje försök
                    client.Client.ReceiveTimeout = 1000 + Math.Min(tries * 100, 10000);
                    
                    if (broadcast)
                    { 
                        data = Encoding.ASCII.GetBytes(SimhoppMessage.PingMessage().Serialize());
                        client.Send(data, data.Length, new IPEndPoint(IPAddress.Broadcast, 60069));
                    }
                    else
                    {
                        client.Send(data, data.Length, ipep);
                    }
                    data = client.Receive(ref ipep);
                    break;
                }
                catch (SocketException ex)
                {
                    LogMessage(SimhoppMessage.ErrorMessage(Encoding.ASCII.GetString(data)));
                    ExceptionHandler.Handle(ex);
                }
            }

            responseData = Encoding.ASCII.GetString(data);
            responseMsg = SimhoppMessage.Deserialize(responseData);

            return responseMsg;
        }

        public void CommitScore(int judgeIndex, Score score)
        {
            SimhoppMessage.SimhoppStatus status = new SimhoppMessage.SimhoppStatus(Presenter.CurrentRoundIndex, Presenter.CurrentDiverIndex, null);
            SimhoppMessage msg = new SimhoppMessage(judgeIndex, SimhoppMessage.ClientAction.SubmitScore, "", score.Points, status);
            Messages.Enqueue(msg);
        }

        public void SendLogout(int judgeIndex)
        {
            try
            {
                SimhoppMessage msg = new SimhoppMessage(judgeIndex, SimhoppMessage.ClientAction.Logout, "");
            
                byte[] data = Encoding.ASCII.GetBytes(msg.Serialize());
                client.Send(data, data.Length, ipep);

                _view.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }
    }
}
