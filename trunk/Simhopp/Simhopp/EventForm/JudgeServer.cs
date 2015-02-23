using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace Simhopp
{
    public class JudgeServer
    {
        public JudgeServer()
        {

        }

        public void Start()
        {
            ThreadStart ts = new ThreadStart(Start1);
            Thread t = new Thread(ts);
            t.Start();

            ThreadStart ts2 = new ThreadStart(Start2);
            Thread t2 = new Thread(ts2);
            t.Start();
        }

        public void Start1()
        {

            bool done = false;

            UdpClient listener = new UdpClient(60068);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 60068);
            listener.EnableBroadcast = true;
            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);
                    Console.WriteLine("Received broadcast from {0} :\n {1}\n",groupEP.ToString(), Encoding.ASCII.GetString(bytes, 0, bytes.Length));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }

        public void Start2()
        {
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 60069);

            UdpClient newsock = new UdpClient(ipep);

            System.Diagnostics.Debug.WriteLine("Waiting for a client...");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            data = newsock.Receive(ref sender);

             System.Diagnostics.Debug.WriteLine("Message received from {0}:", sender.ToString());
             System.Diagnostics.Debug.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));

            string welcome = "Welcome to my test server";
            data = Encoding.ASCII.GetBytes(welcome);
            newsock.Send(data, data.Length, sender);

            while (true)
            {
                data = newsock.Receive(ref sender);

                System.Diagnostics.Debug.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
                newsock.Send(data, data.Length, sender);
            }

            /*
            UdpClient server = new UdpClient(ipep);

            int i = 0;
            while (i < 10)
            {
                System.Diagnostics.Debug.WriteLine("Init loop ", ipep.ToString());
                try
                {
                    string received_data;
                    byte[] receive_byte_array;

                    receive_byte_array = server.Receive(ref ipep);

                    System.Diagnostics.Debug.WriteLine("Received a broadcast from {0}", ipep.ToString());
                    Console.WriteLine("Received a broadcast from {0}", ipep.ToString());

                    received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);

                    System.Diagnostics.Debug.WriteLine("data follows \n{0}\n\n", received_data);
                    Console.WriteLine("data follows \n{0}\n\n", received_data);
                    i++;
                   
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine("Ooopsxeption");
                    throw;
                }
            }
             * */

            /*
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress send_to_address = IPAddress.Parse("192.168.2.255");
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, 11000);

            byte[] send_buffer = Encoding.ASCII.GetBytes("Mega");
            try
            {
                sending_socket.SendTo(send_buffer, sending_end_point);
            }
            catch (Exception send_exception)
            {
                Console.WriteLine(" Exception {0}", send_exception.Message);
            }
             * */


        }
    }
}
