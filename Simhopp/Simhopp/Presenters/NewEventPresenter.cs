using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    public class NewEventPresenter
    {
        private IFormNewEvent _view;

        public NewEventPresenter(IFormNewEvent view)
        {
            _view = view;
        }

        /// <summary>
        /// Hämtar hoppare från databasen och lägger de i listViewDivers
        /// </summary>
        /// <param name="radioButtonMale"></param>
        /// <param name="radioButtonFemale"></param>
        /// <param name="listViewDivers"></param>
        /// <param name="ColumnIndex"></param>
        public static void FillListViewWithDivers(RadioButton radioButtonMale, RadioButton radioButtonFemale, ListView listViewDivers, int ColumnIndex = 0) 
        {
            listViewDivers.Items.Clear();
            foreach (Diver diver in Database.GetDivers(ColumnIndex))
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

        /// <summary>
        /// Hämtar domare från databasen och lägger de i listViewJudge
        /// </summary>
        /// <param name="listViewJudge"></param>
        public static void FillListViewWithJudges(ListView listViewJudge)
        {
            List<Judge> judgeList = new List<Judge>();
            foreach (Judge judge in Database.GetJudges())
            {
                ListViewItem item1 = new ListViewItem();
                item1.Tag = judge;
                item1.Text = judge.Id.ToString();
                item1.SubItems.Add(judge.Name);

                listViewJudge.Items.Add(item1);
            }
        }

        /// <summary>
        /// Lägger till en ny hoppare i databasen och i listViewDivers
        /// </summary>
        /// <param name="newDiverSelectGender"></param>
        /// <param name="newDiverName"></param>
        /// <param name="newDiverAge"></param>
        /// <param name="newDiverCountry"></param>
        /// <param name="listViewDivers"></param>
        /// <param name="radioButtonMale"></param>
        /// <param name="radioButtonFemale"></param>
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
                diver.Id = ID;

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
                    item1.SubItems.Add(diver.Id.ToString());
                }
            }
            
            //restore textbox
            newDiverName.Text = "Namn";
            newDiverAge.Text = "Ålder";
            newDiverCountry.Text = "Nationalitet";
        }

        /// <summary>
        /// Lägger till en domare i databasen och i listViewJudge
        /// </summary>
        /// <param name="newJudgeName"></param>
        /// <param name="listViewJudge"></param>
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

        /// <summary>
        /// Skapar en Contest med hoppare, hopp och domare
        /// </summary>
        /// <param name="textBox1"></param>
        /// <param name="textBox2"></param>
        /// <param name="dateTimePicker1"></param>
        /// <param name="numericUpDown1"></param>
        /// <param name="radioButton1meter"></param>
        /// <param name="radioButton3meter"></param>
        /// <param name="radioButton5meter"></param>
        /// <param name="radioButton7meter"></param>
        /// <param name="radioButton10meter"></param>
        /// <param name="radioButtonSingle"></param>
        /// <param name="radioButtonSync"></param>
        /// <param name="radioButtonMale"></param>
        /// <param name="radioButtonFemale"></param>
        /// <param name="listViewDivers"></param>
        /// <param name="listViewJudge"></param>
        /// <param name="successfully"></param>
        /// <param name="errorlabel"></param>
        /// <param name="dataGridViewList"></param>
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

            //discipline
            if (radioButton1meter.Checked)
                discipline = 0;
            else if (radioButton3meter.Checked)
                discipline = 1;
            else if (radioButton5meter.Checked)
                discipline = 2;
            else if (radioButton7meter.Checked)
                discipline = 3;
            else if (radioButton10meter.Checked)
                discipline = 4;

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

            int code = Database.AddEventToDatabase(ev);
            //om inmatningen lyckades
            if (code == 1)
            {
                int eventID = Database.GetLatestAddedEventID();

                DiveType dType = new DiveType();
                int diverID = -1, dNumber, diveTypeID;
                string dPosition;

                MySqlConnection conn; 
                using (conn = Database.ConnectToDatabase())
                {
                    for (int i = 0; i < dataGridViewList.Count; i++)
                    {
                        //antal rader i en DataGridView
                        for (int rad = 0; rad < dataGridViewList[i].RowCount; rad++)
                        {
                            //diver ID
                            diverID = Int32.Parse(dataGridViewList[i].Tag.ToString());
                            //DiveNo
                            dNumber = Int32.Parse(dataGridViewList[i].Rows[rad].Cells[1].Value.ToString());
                            dPosition = dataGridViewList[i].Rows[rad].Cells[0].Value.ToString();

                            dType.No = dNumber;

                            SetDiveTypeHeight(dType, radioButton1meter, radioButton3meter, radioButton5meter, radioButton7meter, radioButton10meter);
                            SetDiveTypePosition(dType, dPosition);

                            diveTypeID = Database.AddDiveTypeToDatabase(dType, conn);
                            Database.AddDiveToDiver(dType, eventID, rad + 1, diveTypeID, diverID, conn);
                        }
                    }
                }
                
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

        /// <summary>
        /// Skapar en DataGridView
        /// </summary>
        /// <param name="diveNo"></param>
        /// <param name="diveName"></param>
        /// <param name="tabControl1"></param>
        /// <returns>DataGridView</returns>
        public static DataGridView GetNewDataGridView(AutoCompleteStringCollection diveNo, AutoCompleteStringCollection diveName, TabControl tabControl1)
        {
            DataGridView newDataGrid = new DataGridView();

            DataGridViewTextBoxColumn dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn dataGridViewComboBoxColumn2 = new DataGridViewComboBoxColumn();

            newDataGrid.AllowUserToAddRows = false;
            newDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            newDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            dataGridViewComboBoxColumn2,
            dataGridViewTextBoxColumn1,
            dataGridViewTextBoxColumn2
            });
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
            dataGridViewTextBoxColumn2.Width = tabControl1.Width - (51+55+55);
            dataGridViewTextBoxColumn2.Tag = "Namn";
            
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

        //public static void AddAutoCompleteToDataGridView(List<DataGridView> _dataGridViewList, TabControl tabControl1, DataGridViewEditingControlShowingEventArgs e, AutoCompleteStringCollection _diveNo, AutoCompleteStringCollection _diveNoReadOnly, AutoCompleteStringCollection _diveName, AutoCompleteStringCollection _diveNameReadOnly, GroupBox groupBox)
        //{
        //    Thread t = new Thread(() => _AddAutoCompleteToDataGridView(_dataGridViewList, tabControl1, e, _diveNo, _diveNameReadOnly, _diveName, _diveNameReadOnly, groupBox));
        //    t.Start();
        //}
        /// <summary>
        /// Laddar in AutoComplete listorna till textboxarna i TabControlern
        /// </summary>
        /// <param name="_dataGridViewList"></param>
        /// <param name="tabControl1"></param>
        /// <param name="e"></param>
        /// <param name="_diveNo"></param>
        /// <param name="_diveNoReadOnly"></param>
        /// <param name="_diveName"></param>
        /// <param name="_diveNameReadOnly"></param>
        /// <param name="groupBox"></param>
        
        public static void AddAutoCompleteToDataGridView(List<DataGridView> _dataGridViewList, TabControl tabControl1, DataGridViewEditingControlShowingEventArgs e, AutoCompleteStringCollection _diveNo, AutoCompleteStringCollection _diveNoReadOnly, AutoCompleteStringCollection _diveName, AutoCompleteStringCollection _diveNameReadOnly, GroupBox groupBox)
        {
            int tabControlName = Int32.Parse(tabControl1.SelectedTab.Name);
            DataGridView currentDataGridView = _dataGridViewList[tabControlName];

            int columnIndex = currentDataGridView.CurrentCell.ColumnIndex;
            string headerText = currentDataGridView.Columns[columnIndex].HeaderText;
            //int rad = currentDataGridView.CurrentCell.RowIndex;

            //string position = currentDataGridView.Rows[rad].Cells[0].Value.ToString();

            UpdateAutoCompleteList(currentDataGridView, tabControl1, _diveNo, _diveNoReadOnly, _diveName, _diveNameReadOnly, groupBox);

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


        /// <summary>
        /// När positionen har ändrats i hoppet laddas AutoComplete listan om
        /// </summary>
        /// <param name="_dataGridViewList"></param>
        /// <param name="tabControl1"></param>
        /// <param name="_diveNo"></param>
        /// <param name="_diveNoReadOnly"></param>
        /// <param name="_diveName"></param>
        /// <param name="_diveNameReadOnly"></param>
        /// <param name="groupBox"></param>

        public static void UpdateAutoCompleteList(DataGridView currentDataGridView, TabControl tabControl1, AutoCompleteStringCollection _diveNo, AutoCompleteStringCollection _diveNoReadOnly, AutoCompleteStringCollection _diveName, AutoCompleteStringCollection _diveNameReadOnly, GroupBox groupBox)
        {
            //int columnIndex = currentDataGridView.CurrentCell.ColumnIndex;
            //string headerText = currentDataGridView.Columns[columnIndex].HeaderText;
            int rad = currentDataGridView.CurrentCell.RowIndex;

            string position = currentDataGridView.Rows[rad].Cells[0].Value.ToString();
            string height = "";

            _diveName.Clear();
            _diveNo.Clear();

            DiveType.DiveHeight diveHeight = DiveType.DiveHeight._1M;

            //hämtar den valda höjden
            foreach (Control button in groupBox.Controls)
            {
                RadioButton b = button as RadioButton;
                if (b.Checked)
                    height = b.Text.ToString();
            }

            switch (height)
            {
                case "1 m":
                    diveHeight = DiveType.DiveHeight._1M;
                    break;
                case "3 m":
                    diveHeight = DiveType.DiveHeight._3M;
                    break;
                case "5 m":
                    diveHeight = DiveType.DiveHeight._5M;
                    break;
                case "7,5 m":
                    diveHeight = DiveType.DiveHeight._7_5M;
                    break;
                case "10 m":
                    diveHeight = DiveType.DiveHeight._10M;
                    break;
            }

            DiveType diveType = new DiveType();
            diveType.Height = diveHeight;
            SetDiveTypePosition(diveType, position);

            foreach (string s in _diveNoReadOnly)
            {
                diveType.No = Int32.Parse(s);
                if (diveType.Difficulty != 0)
                    _diveNo.Add(s);
            }

            //diveType = new DiveType();
            //diveType.Height = diveHeight;
            //SetDiveTypePosition(diveType, position);

            foreach (string s in _diveNameReadOnly)
            {
                diveType.Name = s;
                diveType.SetNo();
                if (diveType.Difficulty != 0)
                    _diveName.Add(s);
            }
        }

        /// <summary>
        /// Lägger till en DataGridView i TabControlern
        /// </summary>
        /// <param name="tabControl1"></param>
        /// <param name="listViewDivers"></param>
        /// <param name="_diveNo"></param>
        /// <param name="_diveName"></param>
        /// <param name="_dataGridViewList"></param>
        /// <param name="DiveCount_numericUpDown"></param>
        /// <param name="panel1"></param>
        public static void AddDataGridViewToTabControl(TabControl tabControl1, ListView listViewDivers, AutoCompleteStringCollection _diveNo, AutoCompleteStringCollection _diveName, List<DataGridView> _dataGridViewList, NumericUpDown DiveCount_numericUpDown, Panel panel1)
        {
            string[] row = new string[] { "A", "1", "Dummy Dive"};
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
                        DataGridView newDataGrid = NewEventPresenter.GetNewDataGridView(_diveNo, _diveName, tabControl1);
                        newDataGrid.Dock = DockStyle.Fill;
                        _dataGridViewList.Add(newDataGrid);
                    }

                    _dataGridViewList[i].Columns[2].Width = tabControl1.Width - (51 + 55 + 55);

                    //DataGridViewens tag är den samma som Diverns ID
                    _dataGridViewList[i].Tag = listViewDivers.CheckedItems[i].SubItems[4].Text;

                    //antal rader
                    if (_dataGridViewList[i].RowCount <= Int32.Parse(DiveCount_numericUpDown.Value.ToString())) //om det är mindre rader än NumericUpDown
                    {
                        for (int j = _dataGridViewList[i].RowCount; j < Int32.Parse(DiveCount_numericUpDown.Value.ToString()); j++)
                        {
                            _dataGridViewList[i].Rows.Add(row);
                            _dataGridViewList[i].Rows[j].HeaderCell.Value = String.Format("{0}", j + 1);
                        }
                    }
                    else if (_dataGridViewList[i].RowCount > Int32.Parse(DiveCount_numericUpDown.Value.ToString())) //om det är fler rader än NumericUpDown
                    {
                        for (int j = _dataGridViewList[i].RowCount; j > Int32.Parse(DiveCount_numericUpDown.Value.ToString()); j--)
                        {
                            _dataGridViewList[i].Rows.Remove(_dataGridViewList[i].Rows[j - 1]);
                        }
                    }

                    _dataGridViewList[i].Visible = true;
                    string title = listViewDivers.CheckedItems[i].Text;
                    TabPage newTab = new TabPage(title);
                    newTab.Name = i.ToString();
                    newTab.Tag = listViewDivers.CheckedItems[i].SubItems[4].Text;

                    tabControl1.TabPages.Add(newTab);
                    newTab.Controls.Add(_dataGridViewList[i]);
                    listViewDivers.Focus();
                }
            }
            else
            {
                panel1.Visible = false;
                tabControl1.Visible = false;
            }
        }

        /// <summary>
        /// Sätter höjd till en DiveType
        /// </summary>
        /// <param name="d"></param>
        /// <param name="radioButton1meter"></param>
        /// <param name="radioButton3meter"></param>
        /// <param name="radioButton5meter"></param>
        /// <param name="radioButton7meter"></param>
        /// <param name="radioButton10meter"></param>
        private static void SetDiveTypeHeight(DiveType d, RadioButton radioButton1meter, RadioButton radioButton3meter, RadioButton radioButton5meter, RadioButton radioButton7meter, RadioButton radioButton10meter)
        {
            if (radioButton1meter.Checked)
                d.Height = DiveType.DiveHeight._1M;
            if (radioButton3meter.Checked)
                d.Height = DiveType.DiveHeight._3M;
            if (radioButton5meter.Checked)
                d.Height = DiveType.DiveHeight._5M;
            if (radioButton7meter.Checked)
                d.Height = DiveType.DiveHeight._7_5M;
            if (radioButton10meter.Checked)
                d.Height = DiveType.DiveHeight._10M;
        }

        /// <summary>
        /// Sätter position till en DiveType
        /// </summary>
        /// <param name="d"></param>
        /// <param name="position"></param>
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
