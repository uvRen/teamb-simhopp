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
        public List<Judge> judgeList;
        public FormJudgeList()
        {
            InitializeComponent();
        }


        private void FormJudgeList_Load(object sender, EventArgs e)
        {
            judgeList = new List<Judge>();
            foreach (Judge judge in Database.GetJudges())
            {
                listBoxJudges.Items.Add(judge);
            }
        }

        private void FormJudgeList_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Judge judge in listBoxJudges.CheckedItems)
            {
                judgeList.Add(judge);
            }
        }
    }
}
