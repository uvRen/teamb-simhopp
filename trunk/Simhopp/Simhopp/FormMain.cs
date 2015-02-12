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

            foreach(Event e in Database.getEvents()) 
            {
                ListViewItem item1 = new ListViewItem();
                item1.Text = e.ID.ToString();

                listViewEvent.Items.Add(item1);

                item1.SubItems.Add(e.name);
                item1.SubItems.Add(e.location);

                //formaterar bort klockslaget i datumet
                e.date = e.date.Substring(0, 10);
                item1.SubItems.Add(e.date);

                if(e.sex == 0)
                    item1.SubItems.Add("M");
                else
                    item1.SubItems.Add("F");
            }
        }

        private void listViewEvent_ItemActivate(object sender, EventArgs e)
        {
            //SQL för att hämta alla deltagare som ingår i en tävling
            /*
            SELECT * FROM diver WHERE id IN (SELECT diverId FROM event_diver WHERE event_diver.diverId=11) 
            */
            
            int eventId = Int32.Parse(listViewEvent.SelectedItems[0].Text);
            listView1.Items.Clear();

            foreach (Diver d in Database.GetDiversInEvent(eventId))
            {
                ListViewItem item1 = new ListViewItem();
                item1.Text = d.ID.ToString();

                listView1.Items.Add(item1);

                item1.SubItems.Add(d.name);
            }
        }
    }
}