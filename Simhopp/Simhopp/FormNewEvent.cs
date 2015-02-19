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

            
            for(int i=1; i <= 5; i++)
            {
                TextBox c1, c2, c3;
                Label l1;
                l1 = new Label();

                c1 = new TextBox();
                c1.Size = new System.Drawing.Size(50, 25);

                c2 = new TextBox();
                c2.Size = new System.Drawing.Size(50, 25);

                c3 = new TextBox();
                c3.Size = new System.Drawing.Size(50, 25);

                string labelName = "Dive " + i;
                l1.Text = labelName;
                l1.Size = new System.Drawing.Size(40, 25);
                l1.Location = new Point(0, i * 25);

                string comboBoxCode = "code" + i;
                string comboBoxPosition = "position" + i;
                string comboBoxHeight = "height" + i;

                c1.Name = comboBoxCode;
                c2.Name = comboBoxPosition;
                c2.Name = comboBoxHeight;

                int count = 50;
                c1.Location = new Point(count, i * 25);
                count += 65;
                c2.Location = new Point(count, i * 25);
                count += 65;
                c3.Location = new Point(count, i * 25);

                panel1.Controls.Add(l1);
                panel1.Controls.Add(c1);
                panel1.Controls.Add(c2);
                panel1.Controls.Add(c3);

                //panel1.Controls.Add(b);
            }
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
            FormNewEventFunctions.AddNewEventToDatabase(textBox1, textBox2, dateTimePicker1, numericUpDown1, radioButton1meter, radioButton3meter, radioButtonTower, radioButtonSingle, radioButtonSync, radioButtonMale, radioButtonFemale, listViewDivers, listViewJudge, successfully, errorlabel);
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
        #endregion

    }
}
