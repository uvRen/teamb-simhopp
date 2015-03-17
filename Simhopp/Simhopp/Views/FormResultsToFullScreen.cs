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
        private string _id;

        public FormResultsToFullScreen(ListView listViewEvent, int showMonitor)
        {
            this.listViewEvent = listViewEvent;

            InitializeComponent();

            //kollar vilken skärm som används och anpassar kolumn storleken efter det
            Screen[] sc = Screen.AllScreens;
            int whichScreen = showOnMonitor(showMonitor);
            currentScreen = sc[whichScreen];

            int bredd = currentScreen.Bounds.Width;
            _id = listViewEvent.SelectedItems[0].SubItems[5].Text;
            webBrowser.Url = new Uri("http://rockcamp.piq.nu/scoring.php?id=" + _id); 
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

        private void timer1_Tick(object sender, EventArgs e)
        {

            //webBrowser.Url = new Uri("http://rockcamp.piq.nu/scoring.php?id=" + _id); 
            //if (_id != null)
            //    webBrowser.Document.InvokeScript("apa");
        }

        private void FormResultsToFullScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void FormResultsToFullScreen_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void FormResultsToFullScreen_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void webBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
        }
    }
}
