using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormNewEvent());
        }
    }
}

/*
public static List<Judge> GetJudges()
        {
            var judgeList = new List<Judge>();

            var conn = ConnectToDatabase();
            var cmd = new MySqlCommand("SELECT * FROM judge", conn);
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);

            foreach (DataRow row in dt.Rows)
            {
                var tmp = new Judge(Int32.Parse(row["id"].ToString()), row["name"].ToString());
                judgeList.Add(tmp);
            }
            return judgeList;
        }

*/