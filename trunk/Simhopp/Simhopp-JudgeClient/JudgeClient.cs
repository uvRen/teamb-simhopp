using System;
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
    class JudgeClient
    {
        private static Thread _serverThread;
        private static FormJudgeClientView _view;
        private static UdpClient client;
        private static IPEndPoint ipep;

        public JudgeClient(FormJudgeClientView view)
        {
            _view = view;
        }

        private delegate void ProcessMessage(SimhoppMessage msg);
        private static void PopulateJudgeList(SimhoppMessage msg)
        {
            ProcessMessage d = new ProcessMessage(_view.PopulateJudgeList);
            _view.Invoke(d, msg);
        }

        private static void AssignLogin(SimhoppMessage msg)
        {
            ProcessMessage d = new ProcessMessage(_view.AssignLogin);
            _view.Invoke(d, msg);
        }

        private static void LogMessage(SimhoppMessage msg)
        {
            ProcessMessage d = new ProcessMessage(_view.LogMessage);
            _view.Invoke(d, msg);
        }

        public static void Start()
        {
            ThreadStart ts = new ThreadStart(ServerFinder);
            _serverThread = new Thread(ts) {IsBackground = true};
            _serverThread.Start();
        }

        private static void ServerFinder()
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

            while ( true )
            {
                Thread.Sleep(100);
                if (!_view.Messages.TryDequeue(out msg))
                    continue;

                msg = SendReceive(msg);


                switch (msg.Action)
                {
                    case SimhoppMessage.ClientAction.List:
                        PopulateJudgeList(msg);
                        break;
                    case SimhoppMessage.ClientAction.AssignId:
                        AssignLogin(msg);
                        break;
                }

                LogMessage(msg);

            }
            client.Close();
        }

        private static SimhoppMessage SendReceive(SimhoppMessage msg, bool broadcast = false)
        {

            byte[] data = Encoding.ASCII.GetBytes(msg.Serialize());

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
                catch (SocketException)
                {
                    LogMessage(SimhoppMessage.ErrorMessage(Encoding.ASCII.GetString(data)));
                }
            }

            string responseData = Encoding.ASCII.GetString(data);
            SimhoppMessage responseMsg = SimhoppMessage.Deserialize(responseData);

            return responseMsg;
        }
    }
}
