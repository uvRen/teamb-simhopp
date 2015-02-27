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
                item1.Text = judge.Id.ToString();
                listViewJudge.Items.Add(item1);

                item1.SubItems.Add(judge.Name);
            }
        }

        private void AddJudgeToEvent_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewJudge.CheckedItems)
            {
                Judge j = new Judge(Int32.Parse(item.Text), item.SubItems[1].Text);
                judgeList.Add(j);
            }
            this.Close();
        }

        private void ExitForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
