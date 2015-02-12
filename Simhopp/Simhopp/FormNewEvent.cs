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
    public partial class FormNewEvent : Form
    {
        private List<int> enableCreateEvent;
        private List<Judge> judgeList;
        private List<Diver> diverList;
        private string eventName;
        private string location;
        private string date;
        private int diveCount;
        private int discipline;
        private int sync;
        private int sex;
        private bool privateDrag;

        public FormNewEvent()
        {
            judgeList = new List<Judge>();
            diverList = new List<Diver>();
            eventName = "";
            location = "";
            date = "";
            diveCount = -1;
            discipline = -1;
            sync = -1;
            sex = -1;

            InitializeComponent();

            //ställer in formatet på datumet till 2015-02-02
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        
            foreach (Diver diver in Database.GetDivers())
            {
                ListViewItem item1 = new ListViewItem();
                item1.Text = diver.name;
                listViewDivers.Items.Add(item1);

                item1.SubItems.Add(diver.country);
                item1.SubItems.Add(diver.age.ToString());
                if (diver.sex == 0)
                    item1.SubItems.Add("M");
                else
                    item1.SubItems.Add("F");
            }

            judgeList = new List<Judge>();
            foreach (Judge judge in Database.GetJudges())
            {
                ListViewItem item1 = new ListViewItem();
                item1.Text = judge.ID.ToString();
                listViewJudge.Items.Add(item1);

                item1.SubItems.Add(judge.name);
            }
            
            listViewDivers.ItemDrag += listViewDivers_ItemDrag;
            listViewDivers.DragEnter += listViewDivers_DragEnter;
            listViewDivers.DragDrop += listViewDivers_DragDrop;
            listViewDivers.AllowDrop = true;
        }

        void listViewDivers_DragDrop(object sender, DragEventArgs e)
        {
            var pos = listViewDivers.PointToClient(new Point(e.X, e.Y));
            var hit = listViewDivers.HitTest(pos);
            if (hit.Item != null)
            {
                var dragItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                Diver d1 = new Diver(0, dragItem.Text + " & " +
                                        hit.Item.Text);
                AddDiverToList(d1, true);
            }
        }

        void listViewDivers_DragEnter(object sender, DragEventArgs e)
        {
            if (privateDrag)
                e.Effect = e.AllowedEffect;
        }

        void listViewDivers_ItemDrag(object sender, ItemDragEventArgs e)
        {
            privateDrag = true;
            DoDragDrop(e.Item, DragDropEffects.Link);
            privateDrag = false;
        }

        private void btnNewJudge_Click(object sender, EventArgs e)
        {
            FormJudgeList judgeForm = new FormJudgeList();
            judgeForm.ShowDialog();

            judgeList = judgeForm.judgeList;
        }

        private void btnNewDiver_Click(object sender, EventArgs e)
        {
            FormDiverList diverForm = new FormDiverList();
            diverForm.ShowDialog();

            diverList = diverForm.diverList;
        }

        /// <summary>
        /// Skapar ett nytt event när användaren klickar på "Klar" i fönstret "FormNewEvent"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.eventName = textBox1.Text;
            this.location = textBox2.Text;
            this.date = dateTimePicker1.Text;
            this.diveCount = (int)numericUpDown1.Value;

            //discipline: 1m = 0, 3m = 1, Tower = 2
            if (radioButton1meter.Checked)
                this.discipline = 0;
            else if (radioButton3meter.Checked)
                this.discipline = 1;
            else if (radioButtonTower.Checked)
                this.discipline = 2;

            //sync: single = 0, sync = 1
            if (radioButtonSingle.Checked)
                this.sync = 0;
            else if (radioButtonSync.Checked)
                this.sync = 1;

            //sex: male = 0, female = 1
            if (radioButtonMale.Checked)
                this.sex = 0;
            else if (radioButtonFemale.Checked)
                this.sex = 1;

            //lägger till eventet i databasen
            Event ev = new Event(eventName, date, location, discipline, sync, diveCount, sex);

            // SKA GÖRAS NÄSTA GÅNG!!! //

            //hämtar dommare och hoppare från tabellerna
            List<Judge> addJudgesToEvent = new List<Judge>();
            List<Diver> addDiversToEvent = new List<Diver>();
            Diver d;
            Judge j;

            foreach(ListViewItem item in listViewJudge.CheckedItems)
            {
                j = new Judge();
            }

            //om inmatningen lyckades
            int code = Database.AddEventToDatabase(ev, addJudgesToEvent, addDiversToEvent);
            if(code == 1)
            {
                successfully.Visible = true;
            }
            else if(code == -1) 
            {
                successfully.Visible = false;
                errorlabel.Text = "Identical event already exist";
                errorlabel.Visible = true; ;
            }
            else
            {
                successfully.Visible = false;
                errorlabel.Text = "An error occoured, try again";
                errorlabel.Visible = true;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            newDiverName.Text = "";
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            newDiverCountry.Text = "";
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            newDiverAge.Text = "";
        }

        private void AddDiverToList(Diver diver, bool isSync)
        {
            ListViewItem item1 = new ListViewItem();
            if (isSync)
            {
                item1.Text = "| | " + diver.name;
                item1.Checked = true;
            }
            else
                item1.Text = diver.name;
            listViewDivers.Items.Add(item1);

            item1.SubItems.Add(diver.country);
            item1.SubItems.Add(diver.age.ToString());
            item1.SubItems.Add(newDiverSelectGender.Text);
        }
        private void AddNewDiver_Click(object sender, EventArgs e)
        {
            int gender = -1;
            if(newDiverSelectGender.Text.CompareTo("Male") == 0)
            {
                gender = 0;
            }
            else
            {
                gender = 1;
            }

            //lägger till den nya hopparen i databasen
            Diver diver = new Diver(newDiverName.Text, Int32.Parse(newDiverAge.Text), gender, newDiverCountry.Text);
            int ID = Database.AddDiverToDatabase(diver);

            //lägger till den nya hopparen i listan
            ListViewItem item1 = new ListViewItem();
            item1.Text = diver.name;
            listViewDivers.Items.Add(item1);

            //item1.SubItems.Add(diver.name);
            item1.SubItems.Add(diver.country);
            item1.SubItems.Add(diver.age.ToString());
            item1.SubItems.Add(newDiverSelectGender.Text);

            //restore textbox
            newDiverName.Text = "Name";
            newDiverAge.Text = "Age";
            newDiverCountry.Text = "Gender";
        }

        private void newJudgeName_Enter(object sender, EventArgs e)
        {
            newJudgeName.Text = "";
        }

        private void newJudgeSubmit_Click(object sender, EventArgs e)
        {
            //lägger till den nya domaren i databasen
            Judge judge = new Judge(newJudgeName.Text);
            int ID = Database.AddJudgeToDatabase(judge);

            ListViewItem item1 = new ListViewItem();
            item1.Text = ID.ToString();
            listViewJudge.Items.Add(item1);

            item1.SubItems.Add(judge.name);

            //restore textbox
            newJudgeName.Text = "Name";
        }

        private void listViewJudge_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int count = listViewJudge.CheckedItems.Count;

            if (count % 2 != 0 && count >= 3)
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
            }
        }

    }
}
