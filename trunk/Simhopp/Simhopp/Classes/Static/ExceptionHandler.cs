using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    [Serializable]
    public class ExceptionHandler
    {
        public static void Handle(Exception ex)
        {
            if (!(ex is SocketException))
                throw ex;
        }
    }
}
