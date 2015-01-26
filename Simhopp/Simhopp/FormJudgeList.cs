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
    public partial class FormJudgeList : Form
    {
        public FormJudgeList()
        {
            InitializeComponent();
        }

        public FormJudgeList(MySqlDataReader dr)
        {
            DataTable dt = new DataTable();
            dt.Load(dr);
            foreach (DataRow row in dt.Rows)
            {
                listBoxJudges.Items.Add(row["name"]);
            }
    }

        private void FormJudgeList_Load(object sender, EventArgs e)
        {

        }
    }
}
