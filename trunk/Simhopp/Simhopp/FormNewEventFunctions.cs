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
    public class FormNewEventFunctions
    {
        public static void fillListViewWithDivers(RadioButton radioButtonMale, RadioButton radioButtonFemale, ListView listViewDivers) 
        {
            listViewDivers.Items.Clear();
            foreach (Diver diver in Database.GetDivers())
            {
                if (radioButtonMale.Checked && diver.sex == 0)
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.Text = diver.name;
                    listViewDivers.Items.Add(item1);

                    item1.SubItems.Add(diver.country);
                    item1.SubItems.Add(diver.age.ToString());
                    item1.SubItems.Add("M");
                    item1.SubItems.Add(diver.ID.ToString());
                }
                else if (radioButtonFemale.Checked && diver.sex == 1)
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.Text = diver.name;
                    listViewDivers.Items.Add(item1);

                    item1.SubItems.Add(diver.country);
                    item1.SubItems.Add(diver.age.ToString());
                    item1.SubItems.Add("F");
                    item1.SubItems.Add(diver.ID.ToString());
                }
            }
        }
    }
}
