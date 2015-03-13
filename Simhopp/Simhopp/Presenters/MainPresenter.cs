using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simhopp;

namespace Simhopp
{
    public class MainPresenter
    {
        private IFormMain _view;
        private ListView listViewEvent { get { return _view.ListViewEvent; } }
        private ListView listViewResult { get { return _view.ListViewResult; } }

        public MainPresenter(IFormMain view)
        {
            _view = view;
        }

        #region Printing
        public void PrintResult()
        {
            try
            {
                if (listViewEvent.SelectedItems.Count > 0)
                {
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                    PrintDocument pd = new PrintDocument();

                    printPreviewDialog1.Document = pd;
                    printPreviewDialog1.Size = new System.Drawing.Size(350, 550);
                    printPreviewDialog1.Show();
                    pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
                    pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1170);
                    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                }
                else
                {
                    MessageBox.Show("Välj ett event, försök igen", "Fel format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {

            int countItems = 0;

            int y = 300;
            int count;

            Contest c = Database.GetContest(Int32.Parse(listViewEvent.SelectedItems[0].SubItems[5].Text));

            List<string> information = c.GetCollectedContestInfo();

            //title
            ev.Graphics.DrawString(information[5], new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, 325, 75);
            //infobox
            ev.Graphics.DrawString("Plats", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.DimGray, 100, 120);
            ev.Graphics.DrawString(information[3], new Font("Times New Roman", 14, FontStyle.Regular), Brushes.DimGray, 175, 120);
            ev.Graphics.DrawString("Datum", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.DimGray, 100, 145);
            ev.Graphics.DrawString(information[4], new Font("Times New Roman", 14, FontStyle.Regular), Brushes.DimGray, 175, 145);
            ev.Graphics.DrawString("Kön", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.DimGray, 100, 170);
            ev.Graphics.DrawString(information[2], new Font("Times New Roman", 14, FontStyle.Regular), Brushes.DimGray, 175, 170);
            //undertitlar
            ev.Graphics.DrawString("Namn", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 100, 250);
            ev.Graphics.DrawString("Resultat", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 300, 250);

            count = listViewResult.Items.Count;

            for (int i = countItems; i < count; ++i)
            {

                int placering = i + 1;
                ev.Graphics.DrawString(placering + ". " + listViewResult.Items[i].SubItems[1].Text, new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, 100, y);        //skriver ut namn
                ev.Graphics.DrawString(listViewResult.Items[i].Text, new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, 300, y);                    //skriver ut id/resultat
                if (placering == 4)
                {
                    ev.Graphics.DrawString("------------------------------------------", new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, 100, y - 20);
                }
                y += 40;
                if (y > 1100)
                {
                    ev.HasMorePages = true;
                    y = 75;
                    return;
                }
                else
                {
                    ev.HasMorePages = false;
                }
                countItems = i;
            }
            countItems = 0;
        }
#endregion
        public void ResultClick()
        {
            if (_view.ListViewEvent.SelectedItems.Count > 0)
            {
                try
                {
                    _view.Hide();
                    Contest c = Database.GetContest(Int32.Parse(_view.ListViewEvent.SelectedItems[0].SubItems[5].Text));
                    EventPresenter presenter = new EventPresenter(null, c);
                    presenter.ShowViewDialog();
                    _view.Show();
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);
                }
            }
            else
            {
                MessageBox.Show("Välj ett event, försök igen", "Fel format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void FillListViewWithEvent()
        {
            ListView listViewEvent = _view.ListViewEvent;

            listViewEvent.Items.Clear();
            _view.SearchItemSource.Clear();
            
            foreach (Contest e in Database.getEvents())
            {
                ListViewItem item1 = new ListViewItem();
                
                item1.Text = "";
                if (e.started == 1)
                {
                    //item1.SubItems[0].BackColor = Color.Green;
                    item1.ImageIndex = 1;
                }
                else
                {
                    //item1.SubItems[0].BackColor = Color.Red;
                    item1.ImageIndex = 0;
                }
                item1.UseItemStyleForSubItems = false;

                item1.SubItems.Add(e.Name);
                item1.SubItems.Add(e.Location);
                

                //formaterar bort klockslaget i datumet
                e.Date = e.Date.Substring(0, 10);
                item1.SubItems.Add(e.Date);

                if (e.sex == 0)
                    item1.SubItems.Add("M");
                else
                    item1.SubItems.Add("F");

                item1.SubItems.Add(e.Id.ToString());
                listViewEvent.Items.Add(item1);
                _view.SearchItemSource.Add(item1, true);
            }
        }
    }
}
