using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public partial class FormNewEvent : Form
    {
        List<Judge> judgeList;
        public FormNewEvent()
        {
            judgeList = new List<Judge>();
            InitializeComponent();
        }

        private void btnNewJudge_Click(object sender, EventArgs e)
        {
            FormJudgeList judgeForm = new FormJudgeList();
            judgeForm.ShowDialog();

            judgeList = judgeForm.judgeList;
            
            int labelHeight = 23;
            int i = 0;
            foreach (Judge judge in judgeList)
            {
                i++;
                Label tmpLabel = new Label();
                tmpLabel.Text = judge.GetJudgeName();
                tmpLabel.Left = 5;
                tmpLabel.Top = 27 + i*labelHeight;
                grpJudges.Height += labelHeight;
                grpJudges.Controls.Add(tmpLabel);

                grpDivers.Top += labelHeight;
                btnSubmit.Top += labelHeight;
                this.Height += labelHeight;
            }
        }

        private void btnNewDiver_Click(object sender, EventArgs e)
        {
        }
    }
}
