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
 
    public partial class FormNewEvent : Form
    {
        private bool privateDrag;
        private AutoCompleteStringCollection _diveNo = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection _diveName = new AutoCompleteStringCollection();
        private List<DataGridView> _dataGridViewList = new List<DataGridView>();

        ListViewItem selectedItem = null;
        public FormNewEvent()
        {
            InitializeComponent();

            //fyller listorna med dommare och hoppare
            FormNewEventFunctions.FillListViewWithDivers(radioButtonMale, radioButtonFemale, listViewDivers);
            FormNewEventFunctions.FillListViewWithJudges(listViewJudge);

            
            listViewDivers.ItemDrag += listViewDivers_ItemDrag;
            listViewDivers.DragEnter += listViewDivers_DragEnter;
            listViewDivers.DragDrop += listViewDivers_DragDrop;
            listViewDivers.AllowDrop = true;

            //hämtar autocomplete listorna från databasen
            Database.GetAutoCompleteListsFromDatabase(_diveNo, _diveName);
        }

        #region Event Funktioner
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

        //Skapar ett nytt event när användaren klickar på "Klar" i fönstret "FormNewEvent"
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FormNewEventFunctions.AddNewEventToDatabase(EventName_textBox, EventLocation_textBox, dateTimePicker1, DiveCount_numericUpDown, radioButton1meter, radioButton3meter, radioButtonTower, radioButtonSingle, radioButtonSync, radioButtonMale, radioButtonFemale, listViewDivers, listViewJudge, successfully, errorlabel);
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            FormNewEventFunctions.ResetTextBox(newDiverName);
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            FormNewEventFunctions.ResetTextBox(newDiverCountry);
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            FormNewEventFunctions.ResetTextBox(newDiverAge);
        }

        private void AddDiverToList(Diver diver, bool isSync)
        {
            ListViewItem item1 = new ListViewItem();
            if (isSync)
            {
                item1.Text = "| | " + diver.Name;
                item1.Checked = true;
            }
            else
                item1.Text = diver.Name;
            listViewDivers.Items.Add(item1);

            item1.SubItems.Add(diver.Country);
            item1.SubItems.Add(diver.Age.ToString());
            item1.SubItems.Add(newDiverSelectGender.Text);
        }

        private void AddNewDiver_Click(object sender, EventArgs e)
        {
            FormNewEventFunctions.AddNewDiver(newDiverSelectGender, newDiverName, newDiverAge, newDiverCountry, listViewDivers);
        }

        private void newJudgeName_Enter(object sender, EventArgs e)
        {
            FormNewEventFunctions.ResetTextBox(newJudgeName);
        }

        private void newJudgeSubmit_Click(object sender, EventArgs e)
        {
            FormNewEventFunctions.AddNewJudge(newJudgeName, listViewJudge);
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

        //uppdaterar listViewDivers när användaren väljer mellan Male och Female
        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            FormNewEventFunctions.FillListViewWithDivers(radioButtonMale, radioButtonFemale, listViewDivers);
        }
        
        //autocomplete
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = DiveTypeInput_dataGridView.CurrentCell.ColumnIndex;
            string headerText = DiveTypeInput_dataGridView.Columns[column].HeaderText;

            TextBox currentTextbox = e.Control as TextBox;

            if (headerText.CompareTo("Kod") == 0)
            {
                currentTextbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                currentTextbox.AutoCompleteCustomSource = _diveNo;
                currentTextbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else if (headerText.CompareTo("Name") == 0)
            {
                currentTextbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                currentTextbox.AutoCompleteCustomSource = _diveName;
                currentTextbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        //Simhoppare högerklick
        private void listViewDivers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo test = listViewDivers.HitTest(e.X, e.Y);
                listViewDivers_contextMenuStrip.Show(listViewDivers, e.Location);
                selectedItem = test.Item;
            }
        }

        private void RemoveDiverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database.RemoveDiver(Int32.Parse(selectedItem.SubItems[4].Text));
            FormNewEventFunctions.FillListViewWithDivers(radioButtonMale, radioButtonFemale, listViewDivers);
        }

        private void EditDiverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedItem != null) 
            {
                DiveTypeInput_dataGridView.Visible = true;
            }

            DiveTypeInput_dataGridView.Rows.Clear();

            string[] row = new string[] { "", "", "", ""};
            for (int i = 0; i < Int32.Parse(DiveCount_numericUpDown.Value.ToString()); i++)
            {
                DiveTypeInput_dataGridView.Rows.Add(row);
                DiveTypeInput_dataGridView.Rows[i].HeaderCell.Value = String.Format("{0}", i + 1);
            }
        }


        //Domare högerklick
        private void listViewJudges_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo test = listViewJudge.HitTest(e.X, e.Y);
                listViewJudges_contextMenuStrip.Show(listViewJudge, e.Location);
                selectedItem = test.Item;
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            int currentDiverID = Int32.Parse(selectedItem.SubItems[4].Text);
        }
        

        private void DiveTypeInput_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listViewDivers_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            string[] row = new string[] { "", "", "", "" };
            tabControl1.TabPages.Clear();

            if (listViewDivers.CheckedItems.Count > 0)
            {
                for (int i = 0; i < listViewDivers.CheckedItems.Count; i++)
                {
                    DataGridView newDataGrid = FormNewEventFunctions.GetNewDataGridView();
                    newDataGrid.Name = listViewDivers.CheckedItems[i].SubItems[4].Text;

                    _dataGridViewList.Add(newDataGrid);

                    for (int j = _dataGridViewList[i].RowCount; j < Int32.Parse(DiveCount_numericUpDown.Value.ToString()); j++)
                    {
                        _dataGridViewList[i].Rows.Add(row);
                        _dataGridViewList[i].Rows[j].HeaderCell.Value = String.Format("{0}", j + 1);
                    }

                    _dataGridViewList[i].Visible = true;
                    
                    string title = listViewDivers.CheckedItems[i].Text;
                    TabPage newTab = new TabPage(title);
                    newTab.Tag = listViewDivers.CheckedItems[i].SubItems[4].Text;

                    tabControl1.TabPages.Add(newTab);
                    newTab.Controls.Add(_dataGridViewList[i]);
                }
            }
        }
        #endregion
    }
}
