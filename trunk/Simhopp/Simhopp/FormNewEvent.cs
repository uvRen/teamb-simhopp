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
        List<Judge> listJudges;
        public FormNewEvent()
        {
            InitializeComponent();
        }

        private void btnNewJudge_Click(object sender, EventArgs e)
        {
            Label tmpLabel = new Label();
            tmpLabel.Text = inputNewJudge.Text;
            tmpLabel.Left = 5;
            tmpLabel.Top = 30 + listJudges.Count * 16;
            grpJudges.Controls.Add(tmpLabel);

            Judge tmpJudge = new Judge(0, inputNewJudge.Text);

            inputNewJudge.Text = "Domare " + (listJudges.Count + 1);
            grpDivers.Top += 16;
            btnSubmit.Top += 16;
            this.Height += 16;
        }
    }
}
