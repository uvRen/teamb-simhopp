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
        private List<Event> eventList = new List<Event>();
        public FormMain()
        {
            InitializeComponent();

            foreach(Event e in eventList) 
            {
                ListViewItem item1 = new ListViewItem();
                item1.Text = e.name;

                listViewEvent.Items.Add(item1);

                item1.SubItems.Add(e.location);
                item1.SubItems.Add(e.date);
            }
        }
    }
}
