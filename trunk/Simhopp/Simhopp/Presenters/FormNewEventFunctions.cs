﻿using System;
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

        public static void CheckIfSubmitButtonBeEnable(bool EnableSubmitButton, Button btnSubmit, TextBox EventName_textBox, TextBox EventLocation_textBox, NumericUpDown DiveCount_numericUpDown, ListView listViewDivers, ListView listViewJudge)
        {
            if(EventName_textBox.Text.Length > 0)
                if(EventLocation_textBox.Text.Length > 0)
                    if(Int32.Parse(DiveCount_numericUpDown.Value.ToString()) > 0)
                        if(listViewDivers.CheckedItems.Count > 0)
                        {
                            int count = listViewJudge.CheckedItems.Count;

                            if (count % 2 != 0 && count >= 3)
                            {
                                EnableSubmitButton = true;
                            }
                            else
                            {
                                EnableSubmitButton = false;
                            }
                        }
            btnSubmit.Enabled = EnableSubmitButton;
        }

        //skriver ut alla hoppare som ska vara med i listan
        public static void FillListViewWithDivers(RadioButton radioButtonMale, RadioButton radioButtonFemale, ListView listViewDivers) 
        {
            listViewDivers.Items.Clear();
            foreach (Diver diver in Database.GetDivers())
            {
                if (radioButtonMale.Checked && diver.Sex == 0)
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.Tag = diver;
                    item1.Text = diver.Name;
                    listViewDivers.Items.Add(item1);

                    item1.SubItems.Add(diver.Country);
                    item1.SubItems.Add(diver.Age.ToString());
                    item1.SubItems.Add("M");
                    item1.SubItems.Add(diver.Id.ToString());
                }
                else if (radioButtonFemale.Checked && diver.Sex == 1)
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.Tag = diver;
                    item1.Text = diver.Name;
                    listViewDivers.Items.Add(item1);

                    item1.SubItems.Add(diver.Country);
                    item1.SubItems.Add(diver.Age.ToString());
                    item1.SubItems.Add("F");
                    item1.SubItems.Add(diver.Id.ToString());
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
                item1.Text = judge.Id.ToString();
                listViewJudge.Items.Add(item1);

                item1.SubItems.Add(judge.Name);
            }
        }

        //lägger till en ny hoppare i listan och i databasen
        public static void AddNewDiver(ComboBox newDiverSelectGender, TextBox newDiverName, TextBox newDiverAge, TextBox newDiverCountry, ListView listViewDivers, RadioButton radioButtonMale, RadioButton radioButtonFemale)
        {
            //fel hantering, måste ange giltigt namn och nationalitet
            if (newDiverName.Text.CompareTo("Namn") == 0 || newDiverCountry.Text.CompareTo("Nationalitet") == 0 || newDiverSelectGender.Text.Length == 0)
            {
                MessageBox.Show("Fel inmatning, försök igen");
            }
            else 
            {
                int gender = -1;
                if (newDiverSelectGender.Text.CompareTo("Man") == 0)
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
                if ((radioButtonMale.Checked && newDiverSelectGender.Text.CompareTo("Man") == 0) || (radioButtonFemale.Checked && newDiverSelectGender.Text.CompareTo("Kvinna") == 0))
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.Text = diver.Name;
                    listViewDivers.Items.Add(item1);

                    item1.SubItems.Add(diver.Country);
                    item1.SubItems.Add(diver.Age.ToString());
                    if (gender == 0)
                    {
                        item1.SubItems.Add("M");
                    }
                    else
                    {
                        item1.SubItems.Add("F");
                    }
                }
            }
            
            //restore textbox
            newDiverName.Text = "Namn";
            newDiverAge.Text = "Ålder";
            newDiverCountry.Text = "Nationalitet";
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

            item1.SubItems.Add(judge.Name);

            //restore textbox
            newJudgeName.Text = "Namn";
        }

        //lägger till ett event till databasen med tillhörande domare och hoppare
        public static void AddNewEventToDatabase(TextBox textBox1, TextBox textBox2, DateTimePicker dateTimePicker1, NumericUpDown numericUpDown1, RadioButton radioButton1meter, RadioButton radioButton3meter, RadioButton radioButton5meter, RadioButton radioButton7meter, RadioButton radioButton10meter, RadioButton radioButtonSingle, RadioButton radioButtonSync, RadioButton radioButtonMale, RadioButton radioButtonFemale, ListView listViewDivers, ListView listViewJudge, Label successfully, Label errorlabel, List<DataGridView> dataGridViewList)
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
            else if (radioButton5meter.Checked)
                discipline = 1;
            else if (radioButton7meter.Checked)
                discipline = 2;
            else if (radioButton10meter.Checked)
                discipline = 1;

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
            }
            ev.AddDivers(addDiversToEvent);

            foreach (ListViewItem item in listViewJudge.CheckedItems)
            {
                j = new Judge(Int32.Parse(item.SubItems[0].Text), item.SubItems[1].Text);
                addJudgesToEvent.Add(j);
            }
            ev.AddJudges(addJudgesToEvent);

            //om inmatningen lyckades
            int code = Database.AddEventToDatabase(ev);
            //om inmatningen lyckades
            if (code == 1)
            {
                int eventID = Database.GetLatestAddedEventID();
                //----------------------------
                DiveType dType = new DiveType();
                int diverID = -1, dNumber, diveTypeID;
                string dPosition, dHeight;
                for (int i = 0; i < dataGridViewList.Count; i++)
                {
                    //antal rader i en DataGridView
                    for (int rad = 0; rad < dataGridViewList[i].RowCount; rad++)
                    {
                        //diver ID
                        diverID = Int32.Parse(dataGridViewList[i].Tag.ToString());
                        //DiveNo
                        dNumber = Int32.Parse(dataGridViewList[i].Rows[rad].Cells[0].Value.ToString());
                        //Height
                        dHeight = dataGridViewList[i].Rows[rad].Cells[2].Value.ToString();
                        //Position
                        dPosition = dataGridViewList[i].Rows[rad].Cells[3].Value.ToString();

                        dType.No = dNumber;
                        SetDiveTypeHeight(dType, dHeight);
                        SetDiveTypePosition(dType, dPosition);

                        diveTypeID = Database.AddDiveTypeToDatabase(dType);
                        Database.AddDiveToDiver(dType, eventID, rad + 1, diveTypeID, diverID);
                    }
                }
                //----------------------------
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
            if (box.Text == "Namn" || box.Text == "Nationalitet" || box.Text == "Ålder")
                box.Text = "";
        }

        //returnerar en ny DataGridView
        public static DataGridView GetNewDataGridView(AutoCompleteStringCollection diveNo, AutoCompleteStringCollection diveName, TabControl tabControl1)
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
            newDataGrid.Size = new System.Drawing.Size(360, 150);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Kod";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 51;
            dataGridViewTextBoxColumn1.Tag = "Kod";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Namn";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = tabControl1.Width - (51+55+55+55);
            dataGridViewTextBoxColumn2.Tag = "Namn";
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
            dataGridViewComboBoxColumn1.FlatStyle = FlatStyle.Flat;
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
            dataGridViewComboBoxColumn2.FlatStyle = FlatStyle.Flat;

            return newDataGrid;
        }

        public static void AddAutoCompleteToDataGridView(List<DataGridView> _dataGridViewList, TabControl tabControl1, DataGridViewEditingControlShowingEventArgs e, AutoCompleteStringCollection _diveNo, AutoCompleteStringCollection _diveName)
        {
            int columnIndex = _dataGridViewList[Int32.Parse(tabControl1.SelectedTab.Name)].CurrentCell.ColumnIndex;
            string headerText = _dataGridViewList[Int32.Parse(tabControl1.SelectedTab.Name)].Columns[columnIndex].HeaderText;

            if (headerText.Equals("Kod"))
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = _diveNo;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }

            if (headerText.Equals("Namn"))
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = _diveName;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            } 
        }

        //lägger till DataGridViews i TabControlern
        public static void AddDataGridViewToTabControl(TabControl tabControl1, ListView listViewDivers, AutoCompleteStringCollection _diveNo, AutoCompleteStringCollection _diveName, List<DataGridView> _dataGridViewList, NumericUpDown DiveCount_numericUpDown, Panel panel1)
        {
            string[] row = new string[] { "", "", "", "" };
            tabControl1.TabPages.Clear();

            if (listViewDivers.CheckedItems.Count > 0)
            {
                panel1.Visible = true;
                tabControl1.Visible = true;
                //antal tabbar
                for (int i = 0; i < listViewDivers.CheckedItems.Count; i++)
                {
                    //om det har lagts till en ny hoppare skapas en ny DataGridView
                    if(listViewDivers.CheckedItems.Count > _dataGridViewList.Count)
                    {
                        DataGridView newDataGrid = FormNewEventFunctions.GetNewDataGridView(_diveNo, _diveName, tabControl1);
                        newDataGrid.Dock = DockStyle.Fill;
                        _dataGridViewList.Add(newDataGrid);
                    }

                    _dataGridViewList[i].Columns[1].Width = tabControl1.Width - (51 + 55 + 55 + 55);

                    //DataGridViewens tag är den samma som Diverns ID
                    _dataGridViewList[i].Tag = listViewDivers.CheckedItems[i].SubItems[4].Text;

                    //antal rader
                    for (int j = _dataGridViewList[i].RowCount; j < Int32.Parse(DiveCount_numericUpDown.Value.ToString()); j++)
                    {
                        _dataGridViewList[i].Rows.Add(row);
                        _dataGridViewList[i].Rows[j].HeaderCell.Value = String.Format("{0}", j + 1);

                    }

                    _dataGridViewList[i].Visible = true;
                    string title = listViewDivers.CheckedItems[i].Text;
                    TabPage newTab = new TabPage(title);
                    newTab.Name = i.ToString();
                    newTab.Tag = listViewDivers.CheckedItems[i].SubItems[4].Text;

                    tabControl1.TabPages.Add(newTab);
                    newTab.Controls.Add(_dataGridViewList[i]);
                }
            }
            else
            {
                panel1.Visible = false;
                tabControl1.Visible = false;
            }
        }

        private static void SetDiveTypeHeight(DiveType d, string height)
        {
            if (height.CompareTo("1m") == 0)
                d.Height = DiveType.DiveHeight._1M;

            else if(height.CompareTo("3m") == 0)
                d.Height = DiveType.DiveHeight._3M;

            else if (height.CompareTo("5m") == 0)
                d.Height = DiveType.DiveHeight._5M;

            else if (height.CompareTo("7,5m") == 0)
                d.Height = DiveType.DiveHeight._7_5M;

            else if (height.CompareTo("10m") == 0)
                d.Height = DiveType.DiveHeight._10M;
        }

        private static void SetDiveTypePosition(DiveType d, string position)
        {
            if (position.CompareTo("A") == 0)
                d.Position = DiveType.DivePosition.A;

            else if(position.CompareTo("B") == 0)
                d.Position = DiveType.DivePosition.B;

            else if (position.CompareTo("C") == 0)
                d.Position = DiveType.DivePosition.C;

            else if (position.CompareTo("D") == 0)
                d.Position = DiveType.DivePosition.D;
        }
    }
}