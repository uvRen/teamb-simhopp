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
            foreach (Diver diver in Database.GetDivers(0))
            {
                ListViewItem item1 = new ListViewItem();
                item1.Text = diver.Id.ToString();
                listViewDivers.Items.Add(item1);

                item1.SubItems.Add(diver.Name);
                item1.SubItems.Add(diver.Country);
                item1.SubItems.Add(diver.Age.ToString());
                item1.SubItems.Add(diver.Sex.ToString());
            }
        }

        private void addDiverToEvent_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listViewDivers.CheckedItems)
            {
                Diver d = new Diver(Int32.Parse(item.Text), item.SubItems[1].Text, Int32.Parse(item.SubItems[3].Text), Int32.Parse(item.SubItems[4].Text), item.SubItems[2].Text);
                diverList.Add(d);
            }
            this.Close();
        }

        private void ExitForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
