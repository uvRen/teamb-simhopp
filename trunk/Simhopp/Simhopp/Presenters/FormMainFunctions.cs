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
    public class FormMainFunctions
    {
        public static void FillListViewWithEvent(ListView listViewEvent)
        {
            listViewEvent.Items.Clear();
            
            foreach (Contest e in Database.getEvents())
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
            }
        }
    }
}
