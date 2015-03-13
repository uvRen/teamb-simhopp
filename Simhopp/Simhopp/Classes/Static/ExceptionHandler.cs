using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Simhopp
{
    /// <summary>
    /// Hanterar exceptions
    /// skriver ut till errorlog.exe
    /// visar prompt
    /// Ignore ignorerar felmeddelanden.
    /// </summary>
    public class ExceptionHandler
    {
        private static bool _ignore = false;
        public static void Handle(Exception ex)
        {
            //Ignorera socketexception
            //if ((ex is SocketException))
            //    return;

            //throw ex;

            using(StreamWriter writer = new StreamWriter("errorlog.txt", true, Encoding.UTF8))
            { 
                writer.WriteLine("-------- BEGIN EXCEPTION --------");
                writer.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
                writer.WriteLine(ex.HelpLink);

                writer.WriteLine("Exception:");
                writer.WriteLine(ex.InnerException);

                writer.WriteLine("Mssage:");
                writer.WriteLine(ex.Message);

                writer.WriteLine("Trace:");
                writer.WriteLine(ex.StackTrace);

                writer.WriteLine("-------- END EXCEPTION --------");

                writer.WriteLine("");
            }

            if (_ignore)
                return;

            DialogResult result = MessageBox.Show(

                "Ett fel inträffade!\nProgrammet försöker fortsätta, men kanske inte fungerar som det ska.\n\n" +
                 ex.Message + "\n\n" + 
                "Se errorlog.txt för mer info.\n\n",

                "Fel!",
                MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            if (result == DialogResult.Abort)
            {
                _ignore = true;
                Application.Exit();
            }

            if (result == DialogResult.Ignore)
            {
                _ignore = true;
            }
        }
    }
}
