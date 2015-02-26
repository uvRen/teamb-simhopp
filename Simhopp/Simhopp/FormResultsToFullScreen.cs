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
    public partial class FormResultsToFullScreen : Form
    {
        ListView listViewEvent;
        Screen currentScreen;

        public FormResultsToFullScreen(ListView listViewEvent, int showMonitor)
        {
            this.listViewEvent = listViewEvent;

            InitializeComponent();

            //kollar vilken skärm som används och anpassar kolumn storleken efter det
            Screen[] sc = Screen.AllScreens;
            int whichScreen = showOnMonitor(showMonitor);
            currentScreen = sc[whichScreen];

            int bredd = currentScreen.Bounds.Width;

            listViewResult.Columns[0].Width = bredd/2;
            listViewResult.Columns[1].Width = bredd/2;

            listViewResult.Items.Clear();
            if (listViewEvent.SelectedItems.Count != 0)
            {
                foreach (Diver d in Database.GetDiversInEvent(Int32.Parse(listViewEvent.SelectedItems[0].SubItems[5].Text)))
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.Text = d.ID.ToString();

                    item1.SubItems.Add(d.name);
                    listViewResult.Items.Add(item1);
                }
            }
            else
            {
                MessageBox.Show("Välj ett event, försök igen", "Fel format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private int showOnMonitor(int showOnMonitor)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = 0;
            }

            this.currentScreen = sc[showOnMonitor];

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;

            return showOnMonitor;
        }

        private void listViewResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listViewResult.Items.Clear();

            foreach (Diver d in Database.GetDiversInEvent(Int32.Parse(listViewEvent.SelectedItems[0].SubItems[5].Text)))
            {
                ListViewItem item1 = new ListViewItem();
                item1.Text = d.ID.ToString();

                item1.SubItems.Add(d.name);
                listViewResult.Items.Add(item1);
            }
        }
    }
}
