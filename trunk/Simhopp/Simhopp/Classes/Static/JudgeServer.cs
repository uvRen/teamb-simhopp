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
        private static List<IPEndPoint> _judgeClients;
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
            _judgeClients = new List<IPEndPoint>();
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
                            _judgeClients.Add(ipep);
                            response = SendContestStatus();
                            break;
                        case SimhoppMessage.ClientAction.Login:
                            response = AssignIdToJudge(msg);
                            break;
                        case SimhoppMessage.ClientAction.SubmitScore:
                            SubmitScore(msg);
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


        public static void Stop()
        {
            Thread t = new Thread(TerminateServer);
            t.Start();
        }

        private static void TerminateServer()
        {
            try
            {
                //Skicka termineringsmeddelande till ansluna domarklienter
                SendScoreToConnectedClients(null, _presenter.CurrentRoundIndex, _presenter.CurrentDiverIndex, SimhoppMessage.ClientAction.ServerTerminating);
                
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
                ExceptionHandler.Handle(ex);
            }
        }

        private static void SendScoreToConnectedClients(Score score, int roundIndex, int diverIndex, SimhoppMessage.ClientAction action = SimhoppMessage.ClientAction.Ping)
        {
            //Skicka poäng (eller be om bedömningspoäng) till anslutna domarklienter
            foreach (IPEndPoint ipep in _judgeClients)
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
                    ExceptionHandler.Handle(ex);
                }
            }
        }

        private static SimhoppMessage SendContestStatus()
        {

            SimhoppMessage.SimhoppStatus status = new SimhoppMessage.SimhoppStatus(0, 0, _presenter.CurrentEvent);

            return new SimhoppMessage(-2, SimhoppMessage.ClientAction.List, "", 0, status);

        }
        private static SimhoppMessage AssignIdToJudge(SimhoppMessage msg)
        {
            int index = 0;
            foreach (Judge judge in _presenter.Judges)
            {
                if (judge.Name == msg.Data)
                {
                    Guid guid = Guid.NewGuid();
                    _judges[index] = judge;
                    
                    SimhoppMessage.SimhoppStatus status = new SimhoppMessage.SimhoppStatus(0, 0, _presenter.CurrentEvent);
                    SimhoppMessage response = new SimhoppMessage(-2, SimhoppMessage.ClientAction.AssignId, guid.ToString(), judge.Index(_presenter.Judges), status);
                    return response;
                }
                index++;
            }
            return SimhoppMessage.ErrorMessage("Judge not found");
        }

        private static void SubmitScore(SimhoppMessage msg)
        {
            _presenter.SubmitClientScore(msg.Value, msg.Id);
            //_presenter.ScoreDive(msg.Value, msg.Id);
        }

        private static void LogToServer(string message)
        {
            _presenter.LogToServer(message);
        }
    }
}
