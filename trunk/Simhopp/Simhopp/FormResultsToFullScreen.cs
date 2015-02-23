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
        public FormResultsToFullScreen(ListView listViewEvent)
        {
            this.listViewEvent = listViewEvent;

            InitializeComponent();
        }
        public FormResultsToFullScreen()
        {
            InitializeComponent();
        }
        private void ResultsToFullScreen_Load(object sender, System.EventArgs e)
        {
            showOnMonitor(1);

        }

        private void showOnMonitor(int showOnMonitor)
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
    }
}
