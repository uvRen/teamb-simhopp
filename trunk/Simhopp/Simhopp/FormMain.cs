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
    public partial class FormMain : Form
    {
        ListViewItem selectedItem = null;

        int t=0;
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

        #region Print

        //Thomas -- INTE KLAR
        private void PrintResult_btn_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1170); // all sizes are converted from mm to inches & then multiplied by 100.
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing", ex.ToString());
            }
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
	        if (t < 1)
	        {
                //for loop.... ändra koordinater 20, 225
                //ev.Graphics.DrawString(BOXNAME.Text.ToString(), new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 20, 225);
                ev.Graphics.DrawString("Hello world ", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 20, 225);
                t++;
                if (t < 1)
                    ev.HasMorePages = true;
                else
                     ev.HasMorePages = false;
           }
        }
        #endregion
    }
}