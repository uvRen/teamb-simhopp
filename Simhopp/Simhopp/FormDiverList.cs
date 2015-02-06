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
    public partial class FormDiverList : Form
    {
        public List<Diver> diverList;
        public FormDiverList()
        {
            InitializeComponent();
        }

        private void FormDiverList_Load(object sender, EventArgs e)
        {
            diverList = new List<Diver>();
            foreach (Diver diver in Database.GetDivers())
            {
                ListViewItem item1 = new ListViewItem();
                item1.Text = diver.ID.ToString();
                listViewDivers.Items.Add(item1);

                item1.SubItems.Add(diver.name);
                item1.SubItems.Add(diver.country);
                item1.SubItems.Add(diver.sex.ToString());
                item1.SubItems.Add(diver.age.ToString());
            }
        }

        private void FormDiverList_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Diver diver in listViewDivers.CheckedItems)
            {
                diverList.Add(diver);
            }
        }

        private void addDiverToEvent_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listViewDivers.CheckedItems)
            {
                MessageBox.Show("Item: " + item);
            }
        }
    }
}
