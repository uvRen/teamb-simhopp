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
            int eventId = Int32.Parse(listViewEvent.SelectedItems[0].SubItems[5].Text);
            listView1.Items.Clear();

            foreach (Diver d in Database.GetDiversInEvent(eventId))
            {
                ListViewItem item1 = new ListViewItem();
                item1.Text = d.ID.ToString();

                item1.SubItems.Add(d.name);
                listView1.Items.Add(item1);
            }
        }

        //öppnar fönstret "FormNewEvent" för att skapa ett nytt event
        private void button2_Click(object sender, EventArgs e)
        {
            FormNewEvent newEvent = new FormNewEvent();
            newEvent.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.StartEvent(Int32.Parse(listViewEvent.SelectedItems[0].SubItems[5].Text));
            FormMainFunctions.FillListViewWithEvent(listViewEvent);
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

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormEvent FE = new FormEvent();
            FE.ShowDialog();
            Show();
        }
    }
}