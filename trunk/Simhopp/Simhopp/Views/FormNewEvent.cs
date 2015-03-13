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

    public partial class FormNewEvent : Form, IFormNewEvent
    {
        private bool privateDrag;
        private AutoCompleteStringCollection _diveNo = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection _diveName = new AutoCompleteStringCollection();
        private List<DataGridView> _dataGridViewList = new List<DataGridView>();
        private bool EnableSubmitButton = false;
        private bool DataGridViewCellIndex_Back = false;
        private Point _jumpBackToCell;

        ListViewItem selectedItem = null;
        public FormNewEvent()
        {
            InitializeComponent();
            PanelDrawer.Colorize(this);
            //fyller listorna med dommare och hoppare
            NewEventPresenter.FillListViewWithDivers(radioButtonMale, radioButtonFemale, listViewDivers);
            NewEventPresenter.FillListViewWithJudges(listViewJudge);

            
            listViewDivers.ItemDrag += listViewDivers_ItemDrag;
            listViewDivers.DragEnter += listViewDivers_DragEnter;
            listViewDivers.DragDrop += listViewDivers_DragDrop;
            listViewDivers.AllowDrop = true;


            //hämtar autocomplete listorna från databasen
            Database.GetAutoCompleteListsFromDatabase(_diveNo, _diveName);
        }

        #region Event Funktioner

        public void CheckIfSubmitButtonBeEnable()
        {
            if (EventName_textBox.Text.Length > 0)
                if (EventLocation_textBox.Text.Length > 0)
                    if (Int32.Parse(DiveCount_numericUpDown.Value.ToString()) > 0)
                        if (listViewDivers.CheckedItems.Count > 0)
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
        void listViewDivers_DragDrop(object sender, DragEventArgs e)
        {
            var pos = listViewDivers.PointToClient(new Point(e.X, e.Y));
            var hit = listViewDivers.HitTest(pos);
            if (hit.Item != null)
            {
                var dragItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                Random random = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
                int newId = random.Next(1, Int32.MaxValue);
                Diver d1 = new Diver(newId, dragItem.Text + " & " +
                                            hit.Item.Text);
                AddDiverToList(d1, true);
            }
        }

        void listViewDivers_DragEnter(object sender, DragEventArgs e)
        {
            if (privateDrag)
                e.Effect = e.AllowedEffect;
        }

        /// <summary>
        /// Dra hoppare över varandra för att skapa par
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void listViewDivers_ItemDrag(object sender, ItemDragEventArgs e)
        {
             if (!radioButtonSync.Checked)
                return;

            privateDrag = true;
            DoDragDrop(e.Item, DragDropEffects.Link);
            privateDrag = false;
        }

        //Skapar ett nytt event när användaren klickar på "Klar" i fönstret "FormNewEvent"
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            NewEventPresenter.AddNewEventToDatabase(EventName_textBox, EventLocation_textBox, dateTimePicker1, DiveCount_numericUpDown, radioButton1meter, radioButton3meter, radioButton5meter, radioButton7meter, radioButton10meter, radioButtonSingle, radioButtonSync, radioButtonMale, radioButtonFemale, listViewDivers, listViewJudge, successfully, errorlabel, _dataGridViewList);
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            NewEventPresenter.ResetTextBox(newDiverName);
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            NewEventPresenter.ResetTextBox(newDiverCountry);
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            NewEventPresenter.ResetTextBox(newDiverAge);
        }

        private void AddDiverToList(Diver diver, bool isSync)
        {
            ListViewItem item1 = new ListViewItem();

            item1.Text = diver.Name;

            if (isSync)
            {
                item1.SubItems.Add("");
                item1.SubItems.Add("");
                item1.SubItems.Add("");
                item1.SubItems.Add(diver.Id.ToString());
            }
            else
            {   item1.SubItems.Add(diver.Country);
                item1.SubItems.Add(diver.Age.ToString());
                item1.SubItems.Add(newDiverSelectGender.Text);
                item1.SubItems.Add(diver.Id.ToString());
            }

            listViewDivers.Items.Add(item1);

            item1.Checked = true;
            item1.EnsureVisible();
        }

        private void AddNewDiver_Click(object sender, EventArgs e)
        {
            NewEventPresenter.AddNewDiver(newDiverSelectGender, newDiverName, newDiverAge, newDiverCountry, listViewDivers, radioButtonMale, radioButtonFemale);
        }

        private void newJudgeName_Enter(object sender, EventArgs e)
        {
            NewEventPresenter.ResetTextBox(newJudgeName);
        }

        private void newJudgeSubmit_Click(object sender, EventArgs e)
        {
            NewEventPresenter.AddNewJudge(newJudgeName, listViewJudge);
        }

        private void listViewJudge_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            CheckIfSubmitButtonBeEnable();
        }

        //uppdaterar listViewDivers när användaren väljer mellan Male och Female
        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            NewEventPresenter.FillListViewWithDivers(radioButtonMale, radioButtonFemale, listViewDivers);
        }
        
        //autocomplete
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            NewEventPresenter.AddAutoCompleteToDataGridView(_dataGridViewList, tabControl1, e, _diveNo, _diveName);
            PanelDrawer.Colorize(this);
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
            NewEventPresenter.FillListViewWithDivers(radioButtonMale, radioButtonFemale, listViewDivers);
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

        private void listViewDivers_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            CheckIfSubmitButtonBeEnable();
            NewEventPresenter.AddDataGridViewToTabControl(tabControl1, listViewDivers, _diveNo, _diveName, _dataGridViewList, DiveCount_numericUpDown, panel1);
            PanelDrawer.Colorize(this);
            //lägger till en eventhandler till varje DataGridView
            for(int i = 0; i < _dataGridViewList.Count; i++)
            {
                _dataGridViewList[i].EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(DiveTypeInput_dataGridView_EditingControlShowing);
                _dataGridViewList[i].CellEndEdit += new DataGridViewCellEventHandler(DataGridViewDives_CellEndEdit);
                _dataGridViewList[i].CellBeginEdit += new DataGridViewCellCancelEventHandler(DataGridViewDives_CellBeginEdit);
            }

        }
        
        private void DiveTypeInput_dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            NewEventPresenter.AddAutoCompleteToDataGridView(_dataGridViewList, tabControl1, e, _diveNo, _diveName);
        }

        private void FormNewEvent_ResizeEnd(object sender, EventArgs e)
        {
            for(int i = 0; i < _dataGridViewList.Count; i++)
            {
                _dataGridViewList[i].Columns[1].Width = tabControl1.Width - (51 + 55 + 55);
            }
        }

        private void FormNewEvent_SizeChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < _dataGridViewList.Count; i++)
            {
                _dataGridViewList[i].Columns[1].Width = tabControl1.Width - (51 + 55 + 55);
            }
        }

        private void EventName_textBox_Leave(object sender, EventArgs e)
        {

            CheckIfSubmitButtonBeEnable();
        }

        private void EventLocation_textBox_Leave(object sender, EventArgs e)
        {

            CheckIfSubmitButtonBeEnable();
        }

        private void DiveCount_numericUpDown_Leave(object sender, EventArgs e)
        {

            CheckIfSubmitButtonBeEnable();
        }

        //kollar så att ett giltigt värde finns i DataGridViewCellen
        private void DataGridViewDives_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView currentDataGridView = new DataGridView();

            foreach (DataGridView gridView in _dataGridViewList)
            {
                if (sender.Equals(gridView))
                    currentDataGridView = gridView;
            }

            switch (e.ColumnIndex)
            {
                case 0:
                    if (_jumpBackToCell.X == e.RowIndex && _jumpBackToCell.Y == e.ColumnIndex)
                    {
                        //om det angivna värdet inte finns med i AutoComplete listan
                        if (!_diveNo.Contains(currentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) && currentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Length > 0)
                        {
                            MessageBox.Show(currentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + ": är ej ett giltigt värde!");
                            DataGridViewCellIndex_Back = true;
                            _jumpBackToCell.X = e.RowIndex;
                            _jumpBackToCell.Y = e.ColumnIndex;
                        }
                        //om det var ett giltigt värde ska DiveName cellen autocompletas
                        else
                        {
                            if (currentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Length > 0)
                            {
                                DiveType dType = new DiveType(Int32.Parse(currentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                                currentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = dType.Name;
                                DataGridViewCellIndex_Back = false;
                                _jumpBackToCell.X = -1;
                                _jumpBackToCell.Y = -1;
                            }
                        }
                    }
                    break;

                case 1:
                    if (_jumpBackToCell.X == e.RowIndex && _jumpBackToCell.Y == e.ColumnIndex)
                    {
                        //om det angivna värdet inte finns med i AutoComplete listan
                        if (!_diveName.Contains(currentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) && currentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Length > 0)
                        {
                            MessageBox.Show(currentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + ": är ej ett giltigt värde!");
                            DataGridViewCellIndex_Back = true;
                            _jumpBackToCell.X = e.RowIndex;
                            _jumpBackToCell.Y = e.ColumnIndex;
                        }
                        else
                        {
                            if (currentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Length > 0)
                            {
                                DiveType dType = new DiveType();
                                dType.Name = currentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                                currentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value = dType.No.ToString();
                                DataGridViewCellIndex_Back = false;
                                _jumpBackToCell.X = -1;
                                _jumpBackToCell.Y = -1;
                            }
                        }
                    }
                    break;
            }
        }

        //kollar om den ska hoppa tillbaka till en ofärdig cell
        private void DataGridViewDives_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (DataGridViewCellIndex_Back)
            {
                DataGridView currentDataGridView = new DataGridView();

                foreach (DataGridView gridView in _dataGridViewList)
                {
                    if (sender.Equals(gridView))
                        currentDataGridView = gridView;
                }

                switch (e.ColumnIndex)
                {
                    case 0:
                    case 1:
                    case 2:
                        BeginInvoke((Action)delegate
                        {
                            DataGridViewCell cell = currentDataGridView.Rows[_jumpBackToCell.X].Cells[_jumpBackToCell.Y];
                            currentDataGridView.CurrentCell = cell;
                            currentDataGridView.BeginEdit(true);
                        });
                        break;

                    default:
                        break;
                }

                DataGridViewCellIndex_Back = false;
            }
            else
            {
                _jumpBackToCell.X = e.RowIndex;
                _jumpBackToCell.Y = e.ColumnIndex;
            }
        }

        private void listViewDivers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            NewEventPresenter.FillListViewWithDivers(radioButtonMale, radioButtonFemale, listViewDivers, e.Column);
        }

        #endregion

        #region HotKeys
        private void FormNewEvent_KeyDown(object sender, KeyEventArgs e)
        {
            //Buttons
            if (btnSubmit.Enabled == true)
            {
                if (e.Control && e.KeyCode == Keys.S)
                {
                    btnSubmit_Click(sender, null);
                }
                    
            }

            //Focus
            if (!e.Control)
                return;

            switch (e.KeyCode)
            {
                case Keys.NumPad1: case Keys.D1:
                    EventName_textBox.Focus();
                    break;
                case Keys.NumPad2: case Keys.D2:
                    listViewDivers.Focus();         //FOCUS MIDDLE DIVERS
                    break;
                case Keys.NumPad3: case Keys.D3:
                    listViewJudge.Focus();          //FOCUS RIGHT JUDGES
                    break;
            }
        }
        #endregion

        #region MenuStrip
        private void avslutaAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void radioButtonSync_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSync.Checked)
            {
                foreach (ListViewItem item in listViewDivers.Items)
                {
                    item.Checked = false;
                }
            }
        }

        private void radioButtonSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSync.Checked)
            {
                labelSyncToolTip.Text = "Dra hoppare över varandra för att skapa par";
            }
            else
            {
                labelSyncToolTip.Text = "";
            }
        }

    }
}

