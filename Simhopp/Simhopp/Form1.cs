using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Judge j1 = new Judge(3, "Thomas");
            j1.addJudgeToDatabase();
        }

        public void dbtest()
        {
            MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=tuffast.com;uid=teamb;pwd=teambteamb;database=db_teamb;";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MessageBox.Show("Connection successfull!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbtest();
        }
    }
}
