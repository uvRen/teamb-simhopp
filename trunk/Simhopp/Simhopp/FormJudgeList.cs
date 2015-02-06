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
                ListViewItem item1 = new ListViewItem();
                item1.Text = judge.ID.ToString();
                listViewJudge.Items.Add(item1);

                item1.SubItems.Add(judge.name);
            }
        }

        private void FormJudgeList_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Judge judge in listViewJudge.CheckedItems)
            {
                judgeList.Add(judge);
            }
        }
    }
}
