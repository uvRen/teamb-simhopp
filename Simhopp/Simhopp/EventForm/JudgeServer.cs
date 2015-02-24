using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Simhopp
{
    public class JudgeServer
    {
        private static Thread _serverThread;
        private static EventPresenter _presenter;
        private static Dictionary<Guid, Judge> _judges; 

        public static EventPresenter Presenter
        {
            set { _presenter = value; }
        }
        public JudgeServer(EventPresenter presenter)
        {

        }

        public static void Start()
        {
            _judges = new Dictionary<Guid, Judge>();
            ThreadStart ts = new ThreadStart(UdpListener);
            _serverThread = new Thread(ts) { IsBackground = true };

            _serverThread.Start();

        }

        private static void UdpListener()
        {
            UdpClient server = new UdpClient(60069);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 60069);
            server.EnableBroadcast = true;
            try
            {
                while ( true )
                {
                    LogToServer("Waiting for broadcast");

                    //Receive
                    byte[] data = server.Receive(ref ipep);
                    string responseMessage = Encoding.ASCII.GetString(data, 0, data.Length);

                    SimhoppMessage msg = SimhoppMessage.Deserialize(responseMessage);
                    SimhoppMessage response;

                    switch (msg.Action)
                    {
                        case SimhoppMessage.ClientAction.Ping:
                            response = SendContestStatus();
                            break;
                        case SimhoppMessage.ClientAction.Login:
                            response = AssignIdToJudge(msg);
                            break;
                        default:
                            response = SimhoppMessage.ErrorMessage("No implemented");
                            break;
                    }
                    LogToServer("Recieve: " + msg.Serialize());
                    LogToServer("Response: " + response.Action.ToString());
                    LogToServer("Response: " + response.Data);

                    //Respond
                    var responseData = Encoding.ASCII.GetBytes(response.Serialize());
                    server.Send(responseData, responseData.Length, ipep);
                }
            }
            catch (Exception e)
            {
                _presenter.LogToServer(e.ToString());
            }
            finally
            {
                server.Close();
            }
        }

        private static SimhoppMessage SendContestStatus()
        {

            SimhoppMessage.SimhoppStatus status = new SimhoppMessage.SimhoppStatus(0, 0, _presenter.CurrentEvent);

            return new SimhoppMessage("server", SimhoppMessage.ClientAction.List, "", 0, status);

        }
        private static SimhoppMessage AssignIdToJudge(SimhoppMessage msg)
        {
            
            foreach (Judge judge in _presenter.Judges)
            {
                if (judge.name == msg.Data)
                {
                    Guid guid = Guid.NewGuid();
                    _judges[guid] = judge;
                    SimhoppMessage response = new SimhoppMessage("server", SimhoppMessage.ClientAction.AssignId, guid.ToString());
                    return response;
                }
            }
            return SimhoppMessage.ErrorMessage("Judge not found");
        }

        private static void LogToServer(string message)
        {
           _presenter.LogToServer(message);
        }
    }
}
