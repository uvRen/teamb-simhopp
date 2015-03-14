using System;
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

            //Dölj loggning
            this.Width = 295;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            textBoxLog.Visible = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            PanelDrawer.Colorize(this);

            judgeClient = new JudgeClient(this);
            judgeClient.Start();

            listBoxJudges.Visible = false;
        }
        
        /// <summary>
        /// Inloggnings-svar från servern. Loggar in som vald domare
        /// </summary>
        /// <param name="msg"></param>
        public void AssignLogin(SimhoppMessage msg)
        {
            EventPresenter presenter = new EventPresenter(null, msg.Status.Contest);
            presenter.SetMode(EventPresenter.ViewMode.Client, (int)msg.Value, judgeClient, this.Icon);
            Console.WriteLine("Assigning login: " + msg.Serialize());
            judgeClient.Presenter = presenter;
            
            this.Hide();
            presenter.ShowView();
        }

        /// <summary>
        /// Skriver ut domare som går att ansluta som
        /// </summary>
        /// <param name="msg"></param>
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

        /// <summary>
        /// Skricka inloggningsförfrågan till servern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            listBoxJudges.Visible = false;
            imgLoading.Visible = true;
            labelJudgeList.Text = "Loggar in...";
            btnLogin.Enabled = false;

            SimhoppMessage msg = new SimhoppMessage(-1, SimhoppMessage.ClientAction.Login, listBoxJudges.SelectedItem.ToString());
            judgeClient.Messages.Enqueue(msg);
        }
    }
}
