using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    /// <summary>
    /// Meddelanden som skickas mellan programmet och domarklienten
    /// </summary>
    [DataContract]
    public class SimhoppMessage
    {
        public enum ClientAction {
            Error,
            Ping,
            Confirm,
            List,
            AssignId,
            Login,
            RequestScore,
            SubmitScore,
            StatusUpdate,
            Logout,
            ServerTerminating,
            NotAccepted
        };

        [DataContract]
        public class SimhoppStatus
        {
            [DataMember]
            public int RoundIndex;

            [DataMember]
            public int DiverIndex;

            [DataMember]
            public Contest Contest;

            public SimhoppStatus(int roundIndex, int diverIndex, Contest contest)
            {
                RoundIndex = roundIndex;
                DiverIndex = diverIndex;
                Contest = contest;
            }
        }

        [DataMember]
        public int Id;
        [DataMember]
        public ClientAction Action;
        [DataMember]
        public string Data;
        [DataMember]
        public double Value;
        [DataMember]
        public SimhoppStatus Status;

        public SimhoppMessage(int id, ClientAction action, string data = "", double value = 0, SimhoppStatus status = null)
        {
            Id = id;
            Action = action;
            Data = data;
            Value = value;
            Status = status;
        }

        public string Serialize()
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SimhoppMessage));
            MemoryStream ms = new MemoryStream();
            
            js.WriteObject(ms, this);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            string msg = sr.ReadToEnd();
            sr.Close();
            //ms.Close();

            msg = Crypto.Encrypt(msg);
            return msg;
        }

        public static SimhoppMessage PingMessage()
        {
            return new SimhoppMessage(-1, ClientAction.Ping);
        }

        public static SimhoppMessage ErrorMessage(string message)
        {
            return new SimhoppMessage(-1, ClientAction.Error, message);
        }

        public static SimhoppMessage Deserialize(string message)
        {
            message = Crypto.Decrypt(message);
            SimhoppMessage msg;
            try
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SimhoppMessage));
                //MemoryStream ms = new MemoryStream(ASCIIEncoding.ASCII.GetBytes(message));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(message));

                msg = (SimhoppMessage)js.ReadObject(ms);
            }
            catch (Exception ex)
            {
                msg = ErrorMessage(ex.Message);
                ExceptionHandler.Handle(ex);
            }
            return msg;
        }
    }
}
