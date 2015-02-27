using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simhopp;


namespace Simhopp_JudgeClient
{
    public partial class FormJudgeClientView : Form
    {
        private JudgeClient judgeClient;
        public FormJudgeClientView()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            PanelDrawer.Colorize(this);

            judgeClient = new JudgeClient(this);
            judgeClient.Start();

            listBoxJudges.Visible = false;
        }
        
        public void AssignLogin(SimhoppMessage msg)
        {
            EventPresenter presenter = new EventPresenter(null, msg.Status.Contest);
            presenter.SetMode(EventPresenter.ViewMode.Client, (int)msg.Value, judgeClient);
            presenter.ShowView();
            judgeClient.Presenter = presenter;
        }

        public void PopulateJudgeList(SimhoppMessage msg)
        {
            listBoxJudges.Visible = true;
            imgLoading.Visible = false;
            labelTitle.Text = msg.Status.Contest.Name;
            labelJudgeList.Text = "Logga in som domare:";

            foreach (Judge judge in msg.Status.Contest.Judges)
            {
                listBoxJudges.Items.Add(judge);
            }
        }

        public void LogMessage(SimhoppMessage msg)
        {
            textBoxLog.Text = msg.Serialize() + "\r\n" + textBoxLog.Text;
        }

        private void listBoxJudges_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = listBoxJudges.SelectedItems.Count > 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SimhoppMessage msg = new SimhoppMessage(-1, SimhoppMessage.ClientAction.Login, listBoxJudges.SelectedItem.ToString());
            judgeClient.Messages.Enqueue(msg);
        }
    }
}
