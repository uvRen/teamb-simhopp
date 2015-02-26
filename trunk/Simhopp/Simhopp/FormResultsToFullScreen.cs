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
        int eventId;
        public FormResultsToFullScreen(ListView listViewEvent, int eventId)
        {
            this.listViewEvent = listViewEvent;
            this.eventId = eventId;

            InitializeComponent();

            listViewResult.Items.Clear();

            foreach (Diver d in Database.GetDiversInEvent(eventId))
            {
                ListViewItem item1 = new ListViewItem();
                item1.Text = d.ID.ToString();

                item1.SubItems.Add(d.name);
                listViewResult.Items.Add(item1);
            }
        }
        public FormResultsToFullScreen()
        {
            InitializeComponent();
        }

        public void showOnMonitor(int showOnMonitor)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = 0;
            }

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }

        private void listViewResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
