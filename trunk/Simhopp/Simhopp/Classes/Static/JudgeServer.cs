using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Simhopp
{
    public class JudgeServer
    {
        private static Thread _serverThread;
        private static EventPresenter _presenter;
        private static Dictionary<int, Judge> _judges;
        private static Dictionary<IPEndPoint, int> _judgeClients;
        //private static List<IPEndPoint> _judgeClients;
        private static UdpClient _server;

        public static EventPresenter Presenter
        {
            set { _presenter = value; }
        }
        public JudgeServer(EventPresenter presenter)
        {

        }

        public static bool IsJudgeClient(int judgeIndex)
        {
            if (_judges == null)
                return false;
            return _judges.ContainsKey(judgeIndex);
        }

        public static void Start()
        {
            _judges = new Dictionary<int, Judge>();
            _judgeClients = new Dictionary<IPEndPoint, int>();
            ThreadStart ts = new ThreadStart(UdpListener);
            _serverThread = new Thread(ts) { IsBackground = true };

            _serverThread.Start();

        }

        private static void UdpListener()
        {
            try
            {
                _server = new UdpClient(60069); //60069
                _server.EnableBroadcast = true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }

            while ( true )
            {
                try
                {
                    if (_server == null)
                        return;

                    //Vänta på broadcast från klient
                    IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 60069);

                    //Ta emot msg från klienten
                    byte[] data = _server.Receive(ref ipep);
                    string receiveMessage = Encoding.ASCII.GetString(data, 0, data.Length);

                    SimhoppMessage msg = SimhoppMessage.Deserialize(receiveMessage);
                    SimhoppMessage response;

                    switch (msg.Action)
                    {
                        case SimhoppMessage.ClientAction.Ping:
                            response = SendContestStatus();
                            break;
                        case SimhoppMessage.ClientAction.Login:
                            response = AssignIdToJudge(msg, ipep);
                            break;
                        case SimhoppMessage.ClientAction.SubmitScore:
                            SubmitScore(msg);
                            response = new SimhoppMessage(-2, SimhoppMessage.ClientAction.Confirm);
                            break;
                        case SimhoppMessage.ClientAction.Logout:
                            LogoutClient(msg);
                            response = new SimhoppMessage(-2, SimhoppMessage.ClientAction.Confirm);
                            break;
                        default:
                            response = SimhoppMessage.ErrorMessage("Not implemented");
                            break;
                    }
                    
                    //Svara
                    var responseData = Encoding.ASCII.GetBytes(response.Serialize());
                    _server.Send(responseData, responseData.Length, ipep);

                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);
                }
            }
        }

        public static void BroadcastScore(Score score, int roundIndex, int diverIndex, SimhoppMessage.ClientAction action = SimhoppMessage.ClientAction.Ping)
        {
            if (_server == null)
                return;
            _serverThread = new Thread(() => SendScoreToConnectedClients(score, roundIndex, diverIndex, action)) { IsBackground = true };
            _serverThread.Start();
        }

        public static void RequestScore()
        {
            BroadcastScore(null, _presenter.CurrentRoundIndex, _presenter.CurrentDiverIndex, SimhoppMessage.ClientAction.RequestScore);
        }

        public static void SendStatus()
        {
            BroadcastScore(null, _presenter.CurrentRoundIndex, _presenter.CurrentDiverIndex, SimhoppMessage.ClientAction.StatusUpdate);
        }


        public static void Stop(bool closeView = false)
        {
            Thread t = new Thread(() => TerminateServer(closeView));
            t.Start();
        }

        public static void TerminateServer(bool closeView = false)
        {
            try
            {
                //Skicka termineringsmeddelande till ansluna domarklienter
                SendScoreToConnectedClients(null, _presenter.CurrentRoundIndex, _presenter.CurrentDiverIndex, SimhoppMessage.ClientAction.ServerTerminating);
                Thread.Sleep(100);
                //Stäng av server
                _judgeClients.Clear();

                if (_serverThread.IsAlive)
                {
                    _serverThread.Abort();
                }
                _server.Close();
            }
            catch (Exception ex)
            {
                //ExceptionHandler.Handle(ex);
            }
            if (closeView)
                _presenter.CloseView();
        }

        private static void SendScoreToConnectedClients(Score score, int roundIndex, int diverIndex, SimhoppMessage.ClientAction action = SimhoppMessage.ClientAction.Ping)
        {
            if (_judgeClients == null)
                return;
            IPEndPoint toDelete = null;
            bool delete = false;
            //Skicka poäng (eller status / request) till anslutna domarklienter
            foreach (IPEndPoint ipep in _judgeClients.Keys)
            {
                try
                {
                    //Skapa statusmeddelande med runda/hopp
                    SimhoppMessage.SimhoppStatus status = new SimhoppMessage.SimhoppStatus(
                        roundIndex,
                        diverIndex,
                        null);

                    SimhoppMessage msg;
                    if (score == null)
                        msg = new SimhoppMessage(-2, action, "", 0, status);
                    else
                        msg = new SimhoppMessage(score.judge.Index((_presenter.Judges)), SimhoppMessage.ClientAction.SubmitScore, "", score.Points, status);

                    LogToServer("Send: " + msg.Serialize());
                    var sendData = Encoding.ASCII.GetBytes(msg.Serialize());
                    _server.Send(sendData, sendData.Length, ipep);
                }
                catch (Exception ex)
                {
                    delete = true;
                    ExceptionHandler.Handle(ex);
                }
            }
            if (delete && toDelete != null)
            {
                try
                {
                    int judgeIndex = _judgeClients[toDelete];
                    _judgeClients.Remove(toDelete);
                    _judges.Remove(judgeIndex);
                    _presenter.LogoutClient(judgeIndex);
                }
                catch (Exception ex)
                { 
                    /* Ignore */
                }

            }
        }

        public static void KickJudge(int judgeIndex)
        {
            try
            {
                _judges.Remove(judgeIndex);
                _presenter.LogoutClient(judgeIndex);

                Console.WriteLine("Kick index: " + judgeIndex);
                foreach (IPEndPoint ipep in _judgeClients.Keys)
                {
                    Console.WriteLine("ipep: " + ipep.ToString());
                    Console.WriteLine("Index: " + _judgeClients[ipep]);
                    if (_judgeClients[ipep] == judgeIndex)
                    {
                        //Skapa terminate message...
                        SimhoppMessage msg;
                        msg = new SimhoppMessage(-2, SimhoppMessage.ClientAction.ServerTerminating);
                        var sendData = Encoding.ASCII.GetBytes(msg.Serialize());

                        //...och skicka
                        _server.Send(sendData, sendData.Length, ipep);

                        //Och ta bort den
                        _judgeClients.Remove(ipep);

                        //Sen break
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                /* Ignore */
            }
        }

        private static SimhoppMessage SendContestStatus()
        {

            SimhoppMessage.SimhoppStatus status = new SimhoppMessage.SimhoppStatus(0, 0, _presenter.CurrentEvent);

            return new SimhoppMessage(-2, SimhoppMessage.ClientAction.List, "", 0, status);

        }
        private static SimhoppMessage AssignIdToJudge(SimhoppMessage msg, IPEndPoint ipep)
        {
            int index = 0;
            foreach (Judge judge in _presenter.Judges)
            {
                if (judge.Name == msg.Data)
                {
                    Guid guid = Guid.NewGuid();
                    _judges[index] = judge;

                    _judgeClients.Add(ipep, index);

                    SimhoppMessage.SimhoppStatus status = new SimhoppMessage.SimhoppStatus(0, 0, _presenter.CurrentEvent);
                    SimhoppMessage response = new SimhoppMessage(-2, SimhoppMessage.ClientAction.AssignId, guid.ToString(), judge.Index(_presenter.Judges), status);
                    _presenter.AssignJudgeAsClient(index);
                    return response;
                }
                index++;
            }
            return SimhoppMessage.ErrorMessage("Judge not found");
        }

        private static void LogoutClient(SimhoppMessage msg)
        {
            _judges.Remove(msg.Id);
            _presenter.LogoutClient(msg.Id);
        }

        private static void SubmitScore(SimhoppMessage msg)
        {
            _presenter.SubmitClientScore(msg.Value, msg.Id, msg.Status.RoundIndex, msg.Status.DiverIndex);
            //_presenter.ScoreDive(msg.Value, msg.Id);
        }

        private static void LogToServer(string message)
        {
            _presenter.LogToServer(message);
        }
    }
}
