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
                ListViewItem item = new ListViewItem();
                item.Text = diver.name;
                listViewDivers.Items.Add(item);
            }
        }

        private void FormDiverList_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Diver diver in listViewDivers.CheckedItems)
            {
                diverList.Add(diver);
            }
        }
    }
}
