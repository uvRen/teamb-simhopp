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
        public static void AddDivesToDiver(DataGrid dataGridView, ListView listViewDivers)
        {
            if(listViewDivers.SelectedItems.Count > 0)
            {
                dataGridView.Visible = true;
            }
        }
        //skriver ut alla hoppare som ska vara med i listan
        public static void FillListViewWithDivers(RadioButton radioButtonMale, RadioButton radioButtonFemale, ListView listViewDivers) 
        {
            listViewDivers.Items.Clear();
            foreach (Diver diver in Database.GetDivers())
            {
                if (radioButtonMale.Checked && diver.sex == 0)
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.Tag = diver;
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
                    item1.Tag = diver;
                    item1.Text = diver.name;
                    listViewDivers.Items.Add(item1);

                    item1.SubItems.Add(diver.country);
                    item1.SubItems.Add(diver.age.ToString());
                    item1.SubItems.Add("F");
                    item1.SubItems.Add(diver.ID.ToString());
                }
            }
        }

        //skriver ut alla dommare som ska vara med i listan
        public static void FillListViewWithJudges(ListView listViewJudge)
        {
            List<Judge> judgeList = new List<Judge>();
            foreach (Judge judge in Database.GetJudges())
            {
                ListViewItem item1 = new ListViewItem();
                item1.Tag = judge;
                item1.Text = judge.ID.ToString();
                listViewJudge.Items.Add(item1);

                item1.SubItems.Add(judge.name);
            }
        }

        //lägger till en ny hoppare i listan och i databasen
        public static void AddNewDiver(ComboBox newDiverSelectGender, TextBox newDiverName, TextBox newDiverAge, TextBox newDiverCountry, ListView listViewDivers)
        {
            int gender = -1;
            if (newDiverSelectGender.Text.CompareTo("Male") == 0)
            {
                gender = 0;
            }
            else
            {
                gender = 1;
            }

            //lägger till den nya hopparen i databasen
            Diver diver = new Diver();
            try
            {
                diver = new Diver(newDiverName.Text, Int32.Parse(newDiverAge.Text), gender, newDiverCountry.Text);
            }
            catch (FormatException e)
            {
                MessageBox.Show("Du har angivit fel format, försök igen", "Fel format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            newDiverCountry.Text = "Country";
        }

        //lägger till en ny domare i databasen och i listan
        public static void AddNewJudge(TextBox newJudgeName, ListView listViewJudge)
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

        //lägger till ett event till databasen med tillhörande domare och hoppare
        public static void AddNewEventToDatabase(TextBox textBox1, TextBox textBox2, DateTimePicker dateTimePicker1, NumericUpDown numericUpDown1, RadioButton radioButton1meter, RadioButton radioButton3meter, RadioButton radioButtonTower, RadioButton radioButtonSingle, RadioButton radioButtonSync, RadioButton radioButtonMale, RadioButton radioButtonFemale, ListView listViewDivers, ListView listViewJudge, Label successfully, Label errorlabel)
        {
            string eventName;
            string location;
            string date;
            int diveCount;
            int discipline = -1;
            int sync = -1;
            int sex = -1;

            eventName = textBox1.Text;
            location = textBox2.Text;
            date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            diveCount = (int)numericUpDown1.Value;

            //discipline: 1m = 0, 3m = 1, Tower = 2
            if (radioButton1meter.Checked)
                discipline = 0;
            else if (radioButton3meter.Checked)
                discipline = 1;
            else if (radioButtonTower.Checked)
                discipline = 2;

            //sync: single = 0, sync = 1
            if (radioButtonSingle.Checked)
                sync = 0;
            else if (radioButtonSync.Checked)
                sync = 1;

            //sex: male = 0, female = 1
            if (radioButtonMale.Checked)
                sex = 0;
            else if (radioButtonFemale.Checked)
                sex = 1;

            //lägger till eventet i databasen
            Contest ev = new Contest(eventName, date, location, discipline, sync, diveCount, sex);

            //hämtar dommare och hoppare från tabellerna
            List<Judge> addJudgesToEvent = new List<Judge>();
            List<Diver> addDiversToEvent = new List<Diver>();
            Diver d;
            Judge j;
            string gender;
            int g;

            foreach (ListViewItem item in listViewDivers.CheckedItems)
            {
                gender = item.SubItems[3].Text;
                if (gender.CompareTo("M") == 0)
                    g = 0;
                else
                    g = 1;
                d = new Diver(Int32.Parse(item.SubItems[4].Text), item.SubItems[0].Text, Int32.Parse(item.SubItems[2].Text), g, item.SubItems[1].Text);
                addDiversToEvent.Add(d);
                ev.AddDivers(addDiversToEvent);
            }

            foreach (ListViewItem item in listViewJudge.CheckedItems)
            {
                j = new Judge(Int32.Parse(item.SubItems[0].Text), item.SubItems[1].Text);
                addJudgesToEvent.Add(j);
                ev.AddJudges(addJudgesToEvent);
            }

            //om inmatningen lyckades
            int code = Database.AddEventToDatabase(ev);
            if (code == 1)
            {
                successfully.Visible = true;
            }
            else if (code == -1)
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

        public static void ResetTextBox(TextBox box)
        {
            if (box.Text == "Name" || box.Text == "Country" || box.Text == "Age")
                box.Text = "";
        }

        public static DataGridView GetNewDataGridView()
        {
            DataGridView newDataGrid = new DataGridView();

            DataGridViewTextBoxColumn dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn dataGridViewComboBoxColumn1 = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn dataGridViewComboBoxColumn2 = new DataGridViewComboBoxColumn();

            newDataGrid.AllowUserToAddRows = false;
            newDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            newDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dataGridViewTextBoxColumn1,
            dataGridViewTextBoxColumn2,
            dataGridViewComboBoxColumn1,
            dataGridViewComboBoxColumn2});
            newDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            newDataGrid.EnableHeadersVisualStyles = false;
            newDataGrid.TabIndex = 28;
            newDataGrid.Size = new System.Drawing.Size(360, 142);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Kod";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 51;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Name";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 155;
            // 
            // dataGridViewComboBoxColumn1
            // 
            dataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            dataGridViewComboBoxColumn1.HeaderText = "Höjd";
            dataGridViewComboBoxColumn1.Items.AddRange(new object[] {
            "1m",
            "3m",
            "5m",
            "7,5m",
            "10m"});
            dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            dataGridViewComboBoxColumn1.ToolTipText = "1m";
            dataGridViewComboBoxColumn1.Width = 55;
            // 
            // dataGridViewComboBoxColumn2
            // 
            dataGridViewComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            dataGridViewComboBoxColumn2.HeaderText = "Position";
            dataGridViewComboBoxColumn2.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            dataGridViewComboBoxColumn2.Width = 55;

            return newDataGrid;
        }
    }
}
