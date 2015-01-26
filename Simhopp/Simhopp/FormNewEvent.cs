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
            listJudges = new List<Judge>();
            InitializeComponent();
        }

        private void btnNewJudge_Click(object sender, EventArgs e)
        {
            int labelHeight = 23;
            Judge tmpJudge = new Judge(0, inputNewJudge.Text);
            listJudges.Add(tmpJudge);

            Label tmpLabel = new Label();
            tmpLabel.Text = inputNewJudge.Text;
            tmpLabel.Left = 5;
            tmpLabel.Top = 27 + listJudges.Count * labelHeight;

            grpJudges.Height += labelHeight;
            grpJudges.Controls.Add(tmpLabel);

            inputNewJudge.Text = "Domare " + (listJudges.Count + 1);
            grpDivers.Top += labelHeight;
            btnSubmit.Top += labelHeight;
            this.Height += labelHeight;
        }

        private void btnNewDiver_Click(object sender, EventArgs e)
        {

        }
    }
}
