using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Simhopp
{
    public partial class FormMain : Form, IFormMain
    {
        public ListView ListViewEvent { get {return listViewEvent; } }
        public ListView ListViewResult { get { return listViewResult; } }
        public Dictionary<ListViewItem, bool> SearchItemSource { get; set; }

        private ListViewItem _selectedItem = null;
        private MainPresenter _presenter;

        public FormMain(MainPresenter presenter = null)
        {
            _presenter = presenter;
            if (_presenter == null)
                _presenter = new MainPresenter(this);

            InitializeComponent();

            SearchItemSource = new Dictionary<ListViewItem, bool>();

            PanelDrawer.Colorize(this);

            _presenter.FillListViewWithEvent();
        }

        #region Event Funktioner
        private void listViewEvent_ItemActivate(object sender, EventArgs e)
        {
            int count = listViewEvent.SelectedItems.Count;
            int eventId = Int32.Parse(listViewEvent.SelectedItems[0].SubItems[5].Text);
            if (count != 0)
            {
                StartEvent_btn.Enabled = true;
            }
            else
            {
                StartEvent_btn.Enabled = false;
            }

            listViewResult.Items.Clear();
            Database.GetDiversInContest(eventId, listViewResult);

            //foreach (Diver d in Database.GetDiversInEvent(eventId))
            //{
            //    ListViewItem item1 = new ListViewItem();
            //    item1.Text = d.Id.ToString();

            //    item1.SubItems.Add(d.Name);
            //   listViewResult.Items.Add(item1);
            //}
        }

        //öppnar fönstret "FormNewEvent" för att skapa ett nytt event
        private void CreateEventClick(object sender, EventArgs e)
        {
            FormNewEvent newEvent = new FormNewEvent();
            newEvent.ShowDialog();
            _presenter.FillListViewWithEvent();
        }

        private void StartEventClick(object sender, EventArgs e)
        {
            if (listViewEvent.SelectedItems.Count != 0)
            {
                Database.StartEvent(Int32.Parse(listViewEvent.SelectedItems[0].SubItems[5].Text));
                _presenter.FillListViewWithEvent();
            }
            else
            {
                MessageBox.Show("Välj ett event, försök igen", "Fel format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void RegisterResultClick(object sender, EventArgs e)                    //EJ KLAR
        {
            //SELECTED EVENT
            _presenter.ResultClick();
        }

        private void listViewEvent_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo test = listViewEvent.HitTest(e.X, e.Y);
                contextMenuStrip1.Show(listViewEvent, e.Location);
                _selectedItem = test.Item;
            }
        }

        //startar tävling
        private void startaTävlingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database.StartEvent(Int32.Parse(_selectedItem.SubItems[5].Text));
            _presenter.FillListViewWithEvent();
        }

        //stoppar tävling
        private void stoppaTävlingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database.StopEvent(Int32.Parse(_selectedItem.SubItems[5].Text));
            _presenter.FillListViewWithEvent();
        }

        //tar bort event och allt tillhörande ur databasen
        private void taBortEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database.RemoveEvent(Int32.Parse(_selectedItem.SubItems[5].Text));
            _presenter.FillListViewWithEvent();
        }
        //kollar om det finns en extra skärm ansluten och skickar upp resulten (FormResultsToFullScreen) på den
        private void ResultsToFullScreen_btn_Click(object sender, EventArgs e)
        {
            if (listViewEvent.SelectedItems.Count != 0)
            {
                FormResultsToFullScreen ResultsToFullScreen = new FormResultsToFullScreen(listViewEvent, 1);
                ResultsToFullScreen.Show();
            }
            else
            {
                MessageBox.Show("Välj ett event, försök igen", "Fel format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        #endregion

        #region Print Result
        private void PrintResult_btn_Click(object sender, EventArgs e)
        {
            _presenter.PrintResult();
        }
       
        #endregion

        #region Menustrip
        private void avslutaCtrlEscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }        
        #endregion

        #region HotKeys

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                StartEventClick(sender, e);

            if (e.Control && e.KeyCode == Keys.R)
                RegisterResultClick(sender, e);

            if (e.Control && e.KeyCode == Keys.P)
                PrintResult_btn_Click(sender, e);

            if (e.Control && e.KeyValue == 122)                                                                                 //F11 = keyvalue 122
                ResultsToFullScreen_btn_Click(sender, e);

            if (e.Control && e.KeyCode == Keys.N)
                CreateEventClick(sender, e);
            
            if (e.Control && e.KeyCode == Keys.F)
                searchBox.Focus();
       }

        private void listViewEvent_KeyDown(object sender, KeyEventArgs e)
        {
            //Remove event with delete button
            if (e.KeyCode == Keys.Delete)
            {
                if (listViewEvent.SelectedItems.Count > 0)
                {
                    Database.RemoveEvent(Int32.Parse(listViewEvent.SelectedItems[0].SubItems[5].Text));
                    _presenter.FillListViewWithEvent();
                }
            }
        }
        #endregion

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            string str = searchBox.Text.ToLower();
            listViewEvent.Items.Clear();
            foreach (ListViewItem item in SearchItemSource.Keys)
            {
                if (item.SubItems[1].Text.ToLower().IndexOf(str) >= 0 || str == "")
                {
                    listViewEvent.Items.Add(item);
                }
            }
        }
    }
}