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
                item1.Text = "";
                if (e.started == 1)
                {
                    item1.SubItems[0].BackColor = Color.Green;
                }
                else
                {
                    item1.SubItems[0].BackColor = Color.Red;
                }
                item1.UseItemStyleForSubItems = false;

                item1.SubItems.Add(e.name);
                item1.SubItems.Add(e.location);

                //formaterar bort klockslaget i datumet
                e.date = e.date.Substring(0, 10);
                item1.SubItems.Add(e.date);

                if(e.sex == 0)
                    item1.SubItems.Add("M");
                else
                    item1.SubItems.Add("F");

                item1.SubItems.Add(e.ID.ToString());
                listViewEvent.Items.Add(item1);
            }
        }

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
    }
}