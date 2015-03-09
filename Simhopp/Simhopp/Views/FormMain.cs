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
        private ListViewItem _selectedItem = null;

        //int pagesAmount=0;
        public FormMain()
        {
            InitializeComponent();
            PanelDrawer.Colorize(this);

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
                item1.Text = d.Id.ToString();

                item1.SubItems.Add(d.Name);
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
            Contest c = Database.GetContest(Int32.Parse(listViewEvent.SelectedItems[0].SubItems[5].Text));
            EventPresenter presenter = new EventPresenter(null, c);
            
            Show();
        }

        #endregion

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
            FormMainFunctions.FillListViewWithEvent(listViewEvent);
        }

        //stoppar tävling
        private void stoppaTävlingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database.StopEvent(Int32.Parse(_selectedItem.SubItems[5].Text));
            FormMainFunctions.FillListViewWithEvent(listViewEvent);
        }

        //tar bort event och allt tillhörande ur databasen
        private void taBortEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database.RemoveEvent(Int32.Parse(_selectedItem.SubItems[5].Text));
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

        #region Print result

        private void PrintResult_btn_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1170);
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kunde inte skriva ut, försök igen", ex.ToString());
            }
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            int y = 200;
            int count;

            ev.Graphics.DrawString(listViewEvent.SelectedItems[0].SubItems[1].Text, new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, 325, 75);       //Title event name

            ev.Graphics.DrawString("Namn", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 100, 150);                                               //column namn
            ev.Graphics.DrawString("Resultat", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 300, 150);                                           //column resultat

            count = listViewResult.Items.Count;

            for (int i = 0; i < count; ++i)
            {
                int placering = i + 1;
                ev.Graphics.DrawString(placering + ". " + listViewResult.Items[i].SubItems[1].Text, new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, 100, y);        //skriver ut namn
                ev.Graphics.DrawString(listViewResult.Items[i].Text, new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, 300, y);                    //skriver ut id/resultat
                if (placering == 3)
                {
                    ev.Graphics.DrawString("------------------------------------------", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, 100, y + 20);
                }
                y += 40;
            }
        }
        #endregion
    }
}