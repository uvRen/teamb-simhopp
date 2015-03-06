namespace Simhopp
{
    public partial class FormNewEvent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.EventName_label = new System.Windows.Forms.Label();
            this.EventName_textBox = new System.Windows.Forms.TextBox();
            this.EventLocation_textBox = new System.Windows.Forms.TextBox();
            this.EventLocation_label = new System.Windows.Forms.Label();
            this.DiveCount_label = new System.Windows.Forms.Label();
            this.radioButtonSync = new System.Windows.Forms.RadioButton();
            this.radioButtonSingle = new System.Windows.Forms.RadioButton();
            this.DiveCount_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.radioButton1meter = new System.Windows.Forms.RadioButton();
            this.radioButton3meter = new System.Windows.Forms.RadioButton();
            this.radioButtonTower = new System.Windows.Forms.RadioButton();
            this.groupBoxDisciplin = new System.Windows.Forms.GroupBox();
            this.groupBoxSingle = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.EventDate_label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.successfully = new System.Windows.Forms.Label();
            this.errorlabel = new System.Windows.Forms.Label();
            this.listViewJudge = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewDivers = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.newDiverName = new System.Windows.Forms.TextBox();
            this.newDiverAge = new System.Windows.Forms.TextBox();
            this.newDiverCountry = new System.Windows.Forms.TextBox();
            this.AddNewDiverSubmit = new System.Windows.Forms.Button();
            this.newJudgeName = new System.Windows.Forms.TextBox();
            this.newJudgeSubmit = new System.Windows.Forms.Button();
            this.newDiverSelectGender = new System.Windows.Forms.ComboBox();
            this.listViewDivers_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditDiverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveDiverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewJudges_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveJudge_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DiveTypeInput_dataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.DiveCount_numericUpDown)).BeginInit();
            this.groupBoxDisciplin.SuspendLayout();
            this.groupBoxSingle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.listViewDivers_contextMenuStrip.SuspendLayout();
            this.listViewJudges_contextMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiveTypeInput_dataGridView)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // EventName_label
            // 
            this.EventName_label.AutoSize = true;
            this.EventName_label.Location = new System.Drawing.Point(20, 34);
            this.EventName_label.Name = "EventName_label";
            this.EventName_label.Size = new System.Drawing.Size(35, 13);
            this.EventName_label.TabIndex = 0;
            this.EventName_label.Text = "Namn";
            // 
            // EventName_textBox
            // 
            this.EventName_textBox.Location = new System.Drawing.Point(88, 32);
            this.EventName_textBox.Name = "EventName_textBox";
            this.EventName_textBox.Size = new System.Drawing.Size(181, 20);
            this.EventName_textBox.TabIndex = 1;
            // 
            // EventLocation_textBox
            // 
            this.EventLocation_textBox.Location = new System.Drawing.Point(88, 57);
            this.EventLocation_textBox.Name = "EventLocation_textBox";
            this.EventLocation_textBox.Size = new System.Drawing.Size(181, 20);
            this.EventLocation_textBox.TabIndex = 2;
            // 
            // EventLocation_label
            // 
            this.EventLocation_label.AutoSize = true;
            this.EventLocation_label.Location = new System.Drawing.Point(20, 60);
            this.EventLocation_label.Name = "EventLocation_label";
            this.EventLocation_label.Size = new System.Drawing.Size(30, 13);
            this.EventLocation_label.TabIndex = 2;
            this.EventLocation_label.Text = "Plats";
            // 
            // DiveCount_label
            // 
            this.DiveCount_label.AutoSize = true;
            this.DiveCount_label.Location = new System.Drawing.Point(20, 110);
            this.DiveCount_label.Name = "DiveCount_label";
            this.DiveCount_label.Size = new System.Drawing.Size(58, 13);
            this.DiveCount_label.TabIndex = 5;
            this.DiveCount_label.Text = "Antal hopp";
            // 
            // radioButtonSync
            // 
            this.radioButtonSync.AutoSize = true;
            this.radioButtonSync.Location = new System.Drawing.Point(95, 19);
            this.radioButtonSync.Name = "radioButtonSync";
            this.radioButtonSync.Size = new System.Drawing.Size(89, 17);
            this.radioButtonSync.TabIndex = 11;
            this.radioButtonSync.TabStop = true;
            this.radioButtonSync.Text = "Synkroniserat";
            this.radioButtonSync.UseVisualStyleBackColor = true;
            // 
            // radioButtonSingle
            // 
            this.radioButtonSingle.AutoSize = true;
            this.radioButtonSingle.Checked = true;
            this.radioButtonSingle.Location = new System.Drawing.Point(6, 19);
            this.radioButtonSingle.Name = "radioButtonSingle";
            this.radioButtonSingle.Size = new System.Drawing.Size(54, 17);
            this.radioButtonSingle.TabIndex = 10;
            this.radioButtonSingle.TabStop = true;
            this.radioButtonSingle.Text = "Single";
            this.radioButtonSingle.UseVisualStyleBackColor = true;
            // 
            // DiveCount_numericUpDown
            // 
            this.DiveCount_numericUpDown.Location = new System.Drawing.Point(88, 107);
            this.DiveCount_numericUpDown.Name = "DiveCount_numericUpDown";
            this.DiveCount_numericUpDown.Size = new System.Drawing.Size(54, 20);
            this.DiveCount_numericUpDown.TabIndex = 4;
            this.DiveCount_numericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // radioButton1meter
            // 
            this.radioButton1meter.AutoSize = true;
            this.radioButton1meter.Checked = true;
            this.radioButton1meter.Location = new System.Drawing.Point(6, 19);
            this.radioButton1meter.Name = "radioButton1meter";
            this.radioButton1meter.Size = new System.Drawing.Size(42, 17);
            this.radioButton1meter.TabIndex = 6;
            this.radioButton1meter.TabStop = true;
            this.radioButton1meter.Text = "1 m";
            this.radioButton1meter.UseVisualStyleBackColor = true;
            // 
            // radioButton3meter
            // 
            this.radioButton3meter.AutoSize = true;
            this.radioButton3meter.Location = new System.Drawing.Point(95, 19);
            this.radioButton3meter.Name = "radioButton3meter";
            this.radioButton3meter.Size = new System.Drawing.Size(42, 17);
            this.radioButton3meter.TabIndex = 7;
            this.radioButton3meter.TabStop = true;
            this.radioButton3meter.Text = "3 m";
            this.radioButton3meter.UseVisualStyleBackColor = true;
            // 
            // radioButtonTower
            // 
            this.radioButtonTower.AutoSize = true;
            this.radioButtonTower.Location = new System.Drawing.Point(203, 19);
            this.radioButtonTower.Name = "radioButtonTower";
            this.radioButtonTower.Size = new System.Drawing.Size(47, 17);
            this.radioButtonTower.TabIndex = 8;
            this.radioButtonTower.TabStop = true;
            this.radioButtonTower.Text = "Torn";
            this.radioButtonTower.UseVisualStyleBackColor = true;
            // 
            // groupBoxDisciplin
            // 
            this.groupBoxDisciplin.Controls.Add(this.radioButton1meter);
            this.groupBoxDisciplin.Controls.Add(this.radioButton3meter);
            this.groupBoxDisciplin.Controls.Add(this.radioButtonTower);
            this.groupBoxDisciplin.Location = new System.Drawing.Point(23, 137);
            this.groupBoxDisciplin.Name = "groupBoxDisciplin";
            this.groupBoxDisciplin.Size = new System.Drawing.Size(264, 46);
            this.groupBoxDisciplin.TabIndex = 5;
            this.groupBoxDisciplin.TabStop = false;
            this.groupBoxDisciplin.Text = "Disciplin";
            // 
            // groupBoxSingle
            // 
            this.groupBoxSingle.Controls.Add(this.radioButtonSync);
            this.groupBoxSingle.Controls.Add(this.radioButtonSingle);
            this.groupBoxSingle.Location = new System.Drawing.Point(23, 191);
            this.groupBoxSingle.Name = "groupBoxSingle";
            this.groupBoxSingle.Size = new System.Drawing.Size(264, 47);
            this.groupBoxSingle.TabIndex = 9;
            this.groupBoxSingle.TabStop = false;
            this.groupBoxSingle.Text = "Single/synkroniserat";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(17, 632);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(89, 23);
            this.btnSubmit.TabIndex = 18;
            this.btnSubmit.Text = "Skapa event";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 81);
            this.dateTimePicker1.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(181, 20);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.Value = new System.DateTime(2015, 2, 9, 0, 0, 0, 0);
            // 
            // EventDate_label
            // 
            this.EventDate_label.AutoSize = true;
            this.EventDate_label.Location = new System.Drawing.Point(20, 87);
            this.EventDate_label.Name = "EventDate_label";
            this.EventDate_label.Size = new System.Drawing.Size(38, 13);
            this.EventDate_label.TabIndex = 20;
            this.EventDate_label.Text = "Datum";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonMale);
            this.groupBox1.Controls.Add(this.radioButtonFemale);
            this.groupBox1.Location = new System.Drawing.Point(23, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 46);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kön";
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Checked = true;
            this.radioButtonMale.Location = new System.Drawing.Point(6, 19);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(46, 17);
            this.radioButtonMale.TabIndex = 13;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Man";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            this.radioButtonMale.CheckedChanged += new System.EventHandler(this.radioButtonMale_CheckedChanged);
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Location = new System.Drawing.Point(95, 19);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(58, 17);
            this.radioButtonFemale.TabIndex = 14;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Kvinna";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // successfully
            // 
            this.successfully.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.successfully.AutoSize = true;
            this.successfully.ForeColor = System.Drawing.Color.Green;
            this.successfully.Location = new System.Drawing.Point(115, 637);
            this.successfully.Name = "successfully";
            this.successfully.Size = new System.Drawing.Size(134, 13);
            this.successfully.TabIndex = 24;
            this.successfully.Text = "Event created successfully";
            this.successfully.Visible = false;
            // 
            // errorlabel
            // 
            this.errorlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.errorlabel.AutoSize = true;
            this.errorlabel.ForeColor = System.Drawing.Color.Firebrick;
            this.errorlabel.Location = new System.Drawing.Point(115, 637);
            this.errorlabel.Name = "errorlabel";
            this.errorlabel.Size = new System.Drawing.Size(132, 13);
            this.errorlabel.TabIndex = 25;
            this.errorlabel.Text = "An error occured, try again";
            this.errorlabel.Visible = false;
            // 
            // listViewJudge
            // 
            this.listViewJudge.CheckBoxes = true;
            this.listViewJudge.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewJudge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewJudge.FullRowSelect = true;
            this.listViewJudge.GridLines = true;
            this.listViewJudge.Location = new System.Drawing.Point(3, 3);
            this.listViewJudge.Name = "listViewJudge";
            this.listViewJudge.Size = new System.Drawing.Size(288, 598);
            this.listViewJudge.TabIndex = 21;
            this.listViewJudge.UseCompatibleStateImageBehavior = false;
            this.listViewJudge.View = System.Windows.Forms.View.Details;
            this.listViewJudge.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewJudge_ItemChecked);
            this.listViewJudge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewJudges_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Domare";
            this.columnHeader2.Width = 210;
            // 
            // listViewDivers
            // 
            this.listViewDivers.CheckBoxes = true;
            this.listViewDivers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader3});
            this.listViewDivers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDivers.FullRowSelect = true;
            this.listViewDivers.GridLines = true;
            this.listViewDivers.Location = new System.Drawing.Point(3, 3);
            this.listViewDivers.Name = "listViewDivers";
            this.listViewDivers.Size = new System.Drawing.Size(367, 426);
            this.listViewDivers.TabIndex = 15;
            this.listViewDivers.UseCompatibleStateImageBehavior = false;
            this.listViewDivers.View = System.Windows.Forms.View.Details;
            this.listViewDivers.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewDivers_ItemChecked);
            this.listViewDivers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewDivers_MouseDown);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "     Hoppare";
            this.columnHeader7.Width = 154;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Nationalitet";
            this.columnHeader8.Width = 95;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Ålder";
            this.columnHeader9.Width = 49;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Kön";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 0;
            // 
            // newDiverName
            // 
            this.newDiverName.Dock = System.Windows.Forms.DockStyle.Top;
            this.newDiverName.Location = new System.Drawing.Point(3, 3);
            this.newDiverName.Name = "newDiverName";
            this.newDiverName.Size = new System.Drawing.Size(126, 20);
            this.newDiverName.TabIndex = 16;
            this.newDiverName.Text = "Namn";
            this.newDiverName.Enter += new System.EventHandler(this.textBox3_Enter);
            // 
            // newDiverAge
            // 
            this.newDiverAge.Location = new System.Drawing.Point(232, 3);
            this.newDiverAge.Name = "newDiverAge";
            this.newDiverAge.Size = new System.Drawing.Size(37, 20);
            this.newDiverAge.TabIndex = 18;
            this.newDiverAge.Text = "Ålder";
            this.newDiverAge.Enter += new System.EventHandler(this.textBox5_Enter);
            // 
            // newDiverCountry
            // 
            this.newDiverCountry.Dock = System.Windows.Forms.DockStyle.Top;
            this.newDiverCountry.Location = new System.Drawing.Point(135, 3);
            this.newDiverCountry.Name = "newDiverCountry";
            this.newDiverCountry.Size = new System.Drawing.Size(91, 20);
            this.newDiverCountry.TabIndex = 17;
            this.newDiverCountry.Text = "Nationalitet";
            this.newDiverCountry.Enter += new System.EventHandler(this.textBox6_Enter);
            // 
            // AddNewDiverSubmit
            // 
            this.AddNewDiverSubmit.Location = new System.Drawing.Point(341, 3);
            this.AddNewDiverSubmit.Name = "AddNewDiverSubmit";
            this.AddNewDiverSubmit.Size = new System.Drawing.Size(21, 21);
            this.AddNewDiverSubmit.TabIndex = 20;
            this.AddNewDiverSubmit.Text = "+";
            this.AddNewDiverSubmit.UseVisualStyleBackColor = true;
            this.AddNewDiverSubmit.Click += new System.EventHandler(this.AddNewDiver_Click);
            // 
            // newJudgeName
            // 
            this.newJudgeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.newJudgeName.Location = new System.Drawing.Point(3, 3);
            this.newJudgeName.Name = "newJudgeName";
            this.newJudgeName.Size = new System.Drawing.Size(255, 20);
            this.newJudgeName.TabIndex = 22;
            this.newJudgeName.Text = "Namn";
            this.newJudgeName.Enter += new System.EventHandler(this.newJudgeName_Enter);
            // 
            // newJudgeSubmit
            // 
            this.newJudgeSubmit.Location = new System.Drawing.Point(264, 3);
            this.newJudgeSubmit.Name = "newJudgeSubmit";
            this.newJudgeSubmit.Size = new System.Drawing.Size(21, 21);
            this.newJudgeSubmit.TabIndex = 23;
            this.newJudgeSubmit.Text = "+";
            this.newJudgeSubmit.UseVisualStyleBackColor = true;
            this.newJudgeSubmit.Click += new System.EventHandler(this.newJudgeSubmit_Click);
            // 
            // newDiverSelectGender
            // 
            this.newDiverSelectGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.newDiverSelectGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newDiverSelectGender.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.newDiverSelectGender.Location = new System.Drawing.Point(275, 3);
            this.newDiverSelectGender.MaxLength = 100;
            this.newDiverSelectGender.Name = "newDiverSelectGender";
            this.newDiverSelectGender.Size = new System.Drawing.Size(60, 21);
            this.newDiverSelectGender.Sorted = true;
            this.newDiverSelectGender.TabIndex = 19;
            // 
            // listViewDivers_contextMenuStrip
            // 
            this.listViewDivers_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditDiverToolStripMenuItem,
            this.RemoveDiverToolStripMenuItem});
            this.listViewDivers_contextMenuStrip.Name = "listViewDivers_contextMenuStrip";
            this.listViewDivers_contextMenuStrip.Size = new System.Drawing.Size(152, 48);
            // 
            // EditDiverToolStripMenuItem
            // 
            this.EditDiverToolStripMenuItem.Name = "EditDiverToolStripMenuItem";
            this.EditDiverToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.EditDiverToolStripMenuItem.Text = "Redigera hopp";
            this.EditDiverToolStripMenuItem.Click += new System.EventHandler(this.EditDiverToolStripMenuItem_Click);
            // 
            // RemoveDiverToolStripMenuItem
            // 
            this.RemoveDiverToolStripMenuItem.Name = "RemoveDiverToolStripMenuItem";
            this.RemoveDiverToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.RemoveDiverToolStripMenuItem.Text = "Ta bort";
            this.RemoveDiverToolStripMenuItem.Click += new System.EventHandler(this.RemoveDiverToolStripMenuItem_Click);
            // 
            // listViewJudges_contextMenuStrip
            // 
            this.listViewJudges_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveJudge_toolStripMenuItem});
            this.listViewJudges_contextMenuStrip.Name = "listViewJudges_contextMenuStrip";
            this.listViewJudges_contextMenuStrip.Size = new System.Drawing.Size(113, 26);
            // 
            // RemoveJudge_toolStripMenuItem
            // 
            this.RemoveJudge_toolStripMenuItem.Name = "RemoveJudge_toolStripMenuItem";
            this.RemoveJudge_toolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.RemoveJudge_toolStripMenuItem.Text = "Ta bort";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.96465F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.03535F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(293, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(679, 643);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.listViewJudge, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(382, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.97646F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.023548F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(294, 637);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.84507F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.154929F));
            this.tableLayoutPanel5.Controls.Add(this.newJudgeName, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.newJudgeSubmit, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 607);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(288, 27);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.listViewDivers, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.90323F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.096774F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(373, 637);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 468);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 166);
            this.panel1.TabIndex = 29;
            this.panel1.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(367, 166);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DiveTypeInput_dataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(359, 140);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DiveTypeInput_dataGridView
            // 
            this.DiveTypeInput_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DiveTypeInput_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiveTypeInput_dataGridView.Location = new System.Drawing.Point(3, 3);
            this.DiveTypeInput_dataGridView.Name = "DiveTypeInput_dataGridView";
            this.DiveTypeInput_dataGridView.Size = new System.Drawing.Size(353, 134);
            this.DiveTypeInput_dataGridView.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.59162F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.40838F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.Controls.Add(this.newDiverName, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.newDiverCountry, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.newDiverAge, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.newDiverSelectGender, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.AddNewDiverSubmit, 4, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 435);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(367, 27);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // FormNewEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.errorlabel);
            this.Controls.Add(this.successfully);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.EventDate_label);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBoxSingle);
            this.Controls.Add(this.EventName_textBox);
            this.Controls.Add(this.groupBoxDisciplin);
            this.Controls.Add(this.DiveCount_numericUpDown);
            this.Controls.Add(this.DiveCount_label);
            this.Controls.Add(this.EventLocation_textBox);
            this.Controls.Add(this.EventLocation_label);
            this.Controls.Add(this.EventName_label);
            this.Name = "FormNewEvent";
            this.Text = "FormNewEvent";
            this.ResizeEnd += new System.EventHandler(this.FormNewEvent_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.DiveCount_numericUpDown)).EndInit();
            this.groupBoxDisciplin.ResumeLayout(false);
            this.groupBoxDisciplin.PerformLayout();
            this.groupBoxSingle.ResumeLayout(false);
            this.groupBoxSingle.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.listViewDivers_contextMenuStrip.ResumeLayout(false);
            this.listViewJudges_contextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DiveTypeInput_dataGridView)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EventName_label;
        private System.Windows.Forms.Label EventLocation_label;
        private System.Windows.Forms.Label EventDate_label;
        private System.Windows.Forms.Label DiveCount_label;
        private System.Windows.Forms.Label successfully;
        private System.Windows.Forms.Label errorlabel;

        private System.Windows.Forms.TextBox EventName_textBox;
        private System.Windows.Forms.TextBox EventLocation_textBox;
        private System.Windows.Forms.TextBox newDiverName;
        private System.Windows.Forms.TextBox newDiverAge;
        private System.Windows.Forms.TextBox newDiverCountry;
        private System.Windows.Forms.TextBox newJudgeName;

        private System.Windows.Forms.GroupBox groupBoxDisciplin;
        private System.Windows.Forms.GroupBox groupBoxSingle;

        private System.Windows.Forms.RadioButton radioButtonSync;
        private System.Windows.Forms.RadioButton radioButtonSingle;
        private System.Windows.Forms.RadioButton radioButton1meter;
        private System.Windows.Forms.RadioButton radioButton3meter;
        private System.Windows.Forms.RadioButton radioButtonTower;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.RadioButton radioButtonFemale;

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button newJudgeSubmit;
        private System.Windows.Forms.Button AddNewDiverSubmit;

        private System.Windows.Forms.NumericUpDown DiveCount_numericUpDown;

        private System.Windows.Forms.ComboBox newDiverSelectGender;
        
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        
        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        
        private System.Windows.Forms.ListView listViewJudge;
        private System.Windows.Forms.ListView listViewDivers;
        private System.Windows.Forms.ContextMenuStrip listViewDivers_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RemoveDiverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditDiverToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip listViewJudges_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RemoveJudge_toolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DiveTypeInput_dataGridView;
    }
}