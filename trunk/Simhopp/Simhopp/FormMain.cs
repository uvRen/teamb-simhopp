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
    public partial class FormMain : Form
    {
        ListViewItem selectedItem = null;
        public FormMain()
        {
            InitializeComponent();


            FormMainFunctions.FillListViewWithEvent(listViewEvent);
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

            foreach (Diver d in Database.GetDiversInEvent(eventId))
            {
                ListViewItem item1 = new ListViewItem();
                item1.Text = d.ID.ToString();

                item1.SubItems.Add(d.name);
                listViewResult.Items.Add(item1);
            }
        }

        //öppnar fönstret "FormNewEvent" för att skapa ett nytt event
        private void CreateEventClick(object sender, EventArgs e)
        {
            FormNewEvent newEvent = new FormNewEvent();
            newEvent.ShowDialog();
        }

        private void StartEventClick(object sender, EventArgs e)
        {
            if (listViewEvent.SelectedItems.Count != 0)
            {
                Database.StartEvent(Int32.Parse(listViewEvent.SelectedItems[0].SubItems[5].Text));
                FormMainFunctions.FillListViewWithEvent(listViewEvent);
            }
            else
            {
                MessageBox.Show("Markera ett event, försök igen", "Fel format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void RegisterResultClick(object sender, EventArgs e)
        {
            this.Hide();
            FormEvent FE = new FormEvent();
            FE.ShowDialog();
            Show();
        }

        #endregion

        private void listViewEvent_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo test = listViewEvent.HitTest(e.X, e.Y);
                contextMenuStrip1.Show(listViewEvent, e.Location);
                selectedItem = test.Item;
            }
        }

        //startar tävling
        private void startaTävlingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database.StartEvent(Int32.Parse(selectedItem.SubItems[5].Text));
            FormMainFunctions.FillListViewWithEvent(listViewEvent);
        }

        //stoppar tävling
        private void stoppaTävlingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database.StopEvent(Int32.Parse(selectedItem.SubItems[5].Text));
            FormMainFunctions.FillListViewWithEvent(listViewEvent);
        }

        //tar bort event och allt tillhörande ur databasen
        private void taBortEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database.RemoveEvent(Int32.Parse(selectedItem.SubItems[5].Text));
            FormMainFunctions.FillListViewWithEvent(listViewEvent);
        }
        //kollar om det finns en extra skärm ansluten och skickar upp resulten (FormResultsToFullScreen) på den
        private void ResultsToFullScreen_btn_Click(object sender, EventArgs e)
        {
            FormResultsToFullScreen ResultsToFullScreen = new FormResultsToFullScreen(listViewEvent);
            ResultsToFullScreen.showOnMonitor(1);
            ResultsToFullScreen.Show();


        }

        
    }
}