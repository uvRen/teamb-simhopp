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
            this.DiveTypeInput_dataGridView = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.listViewDivers_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditDiverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveDiverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewJudges_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveJudge_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DiveCount_numericUpDown)).BeginInit();
            this.groupBoxDisciplin.SuspendLayout();
            this.groupBoxSingle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiveTypeInput_dataGridView)).BeginInit();
            this.listViewDivers_contextMenuStrip.SuspendLayout();
            this.listViewJudges_contextMenuStrip.SuspendLayout();
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
            this.EventName_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EventName_textBox.Location = new System.Drawing.Point(88, 32);
            this.EventName_textBox.Name = "EventName_textBox";
            this.EventName_textBox.Size = new System.Drawing.Size(181, 20);
            this.EventName_textBox.TabIndex = 1;
            // 
            // EventLocation_textBox
            // 
            this.EventLocation_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.radioButtonSync.Size = new System.Drawing.Size(49, 17);
            this.radioButtonSync.TabIndex = 11;
            this.radioButtonSync.TabStop = true;
            this.radioButtonSync.Text = "Sync";
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
            this.radioButtonTower.Size = new System.Drawing.Size(55, 17);
            this.radioButtonTower.TabIndex = 8;
            this.radioButtonTower.TabStop = true;
            this.radioButtonTower.Text = "Tower";
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
            this.groupBoxSingle.Text = "Single/sync";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(9, 512);
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
            this.groupBox1.Text = "Gender";
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Checked = true;
            this.radioButtonMale.Location = new System.Drawing.Point(6, 19);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(48, 17);
            this.radioButtonMale.TabIndex = 13;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            this.radioButtonMale.CheckedChanged += new System.EventHandler(this.radioButtonMale_CheckedChanged);
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Location = new System.Drawing.Point(95, 19);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(59, 17);
            this.radioButtonFemale.TabIndex = 14;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // successfully
            // 
            this.successfully.AutoSize = true;
            this.successfully.ForeColor = System.Drawing.Color.Green;
            this.successfully.Location = new System.Drawing.Point(107, 517);
            this.successfully.Name = "successfully";
            this.successfully.Size = new System.Drawing.Size(134, 13);
            this.successfully.TabIndex = 24;
            this.successfully.Text = "Event created successfully";
            this.successfully.Visible = false;
            // 
            // errorlabel
            // 
            this.errorlabel.AutoSize = true;
            this.errorlabel.ForeColor = System.Drawing.Color.Firebrick;
            this.errorlabel.Location = new System.Drawing.Point(107, 517);
            this.errorlabel.Name = "errorlabel";
            this.errorlabel.Size = new System.Drawing.Size(138, 13);
            this.errorlabel.TabIndex = 25;
            this.errorlabel.Text = "An error occoured, try again";
            this.errorlabel.Visible = false;
            // 
            // listViewJudge
            // 
            this.listViewJudge.CheckBoxes = true;
            this.listViewJudge.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewJudge.FullRowSelect = true;
            this.listViewJudge.GridLines = true;
            this.listViewJudge.Location = new System.Drawing.Point(710, 7);
            this.listViewJudge.Name = "listViewJudge";
            this.listViewJudge.Size = new System.Drawing.Size(262, 504);
            this.listViewJudge.TabIndex = 21;
            this.listViewJudge.UseCompatibleStateImageBehavior = false;
            this.listViewJudge.View = System.Windows.Forms.View.Details;
            this.listViewJudge.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewJudge_ItemChecked);
            this.listViewJudge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewJudges_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
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
            this.listViewDivers.FullRowSelect = true;
            this.listViewDivers.GridLines = true;
            this.listViewDivers.Location = new System.Drawing.Point(313, 6);
            this.listViewDivers.Name = "listViewDivers";
            this.listViewDivers.Size = new System.Drawing.Size(371, 505);
            this.listViewDivers.TabIndex = 15;
            this.listViewDivers.UseCompatibleStateImageBehavior = false;
            this.listViewDivers.View = System.Windows.Forms.View.Details;
            this.listViewDivers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewDivers_MouseDown);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Name";
            this.columnHeader7.Width = 163;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Country";
            this.columnHeader8.Width = 95;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Age";
            this.columnHeader9.Width = 49;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Gender";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 0;
            // 
            // newDiverName
            // 
            this.newDiverName.Location = new System.Drawing.Point(313, 518);
            this.newDiverName.Name = "newDiverName";
            this.newDiverName.Size = new System.Drawing.Size(121, 20);
            this.newDiverName.TabIndex = 16;
            this.newDiverName.Text = "Name";
            this.newDiverName.Enter += new System.EventHandler(this.textBox3_Enter);
            // 
            // newDiverAge
            // 
            this.newDiverAge.Location = new System.Drawing.Point(550, 518);
            this.newDiverAge.Name = "newDiverAge";
            this.newDiverAge.Size = new System.Drawing.Size(34, 20);
            this.newDiverAge.TabIndex = 18;
            this.newDiverAge.Text = "Age";
            this.newDiverAge.Enter += new System.EventHandler(this.textBox5_Enter);
            // 
            // newDiverCountry
            // 
            this.newDiverCountry.Location = new System.Drawing.Point(440, 518);
            this.newDiverCountry.Name = "newDiverCountry";
            this.newDiverCountry.Size = new System.Drawing.Size(104, 20);
            this.newDiverCountry.TabIndex = 17;
            this.newDiverCountry.Text = "Country";
            this.newDiverCountry.Enter += new System.EventHandler(this.textBox6_Enter);
            // 
            // AddNewDiverSubmit
            // 
            this.AddNewDiverSubmit.Location = new System.Drawing.Point(658, 517);
            this.AddNewDiverSubmit.Name = "AddNewDiverSubmit";
            this.AddNewDiverSubmit.Size = new System.Drawing.Size(26, 23);
            this.AddNewDiverSubmit.TabIndex = 20;
            this.AddNewDiverSubmit.Text = "+";
            this.AddNewDiverSubmit.UseVisualStyleBackColor = true;
            this.AddNewDiverSubmit.Click += new System.EventHandler(this.AddNewDiver_Click);
            // 
            // newJudgeName
            // 
            this.newJudgeName.Location = new System.Drawing.Point(710, 520);
            this.newJudgeName.Name = "newJudgeName";
            this.newJudgeName.Size = new System.Drawing.Size(230, 20);
            this.newJudgeName.TabIndex = 22;
            this.newJudgeName.Text = "Name";
            this.newJudgeName.Enter += new System.EventHandler(this.newJudgeName_Enter);
            // 
            // newJudgeSubmit
            // 
            this.newJudgeSubmit.Location = new System.Drawing.Point(946, 518);
            this.newJudgeSubmit.Name = "newJudgeSubmit";
            this.newJudgeSubmit.Size = new System.Drawing.Size(26, 23);
            this.newJudgeSubmit.TabIndex = 23;
            this.newJudgeSubmit.Text = "+";
            this.newJudgeSubmit.UseVisualStyleBackColor = true;
            this.newJudgeSubmit.Click += new System.EventHandler(this.newJudgeSubmit_Click);
            // 
            // newDiverSelectGender
            // 
            this.newDiverSelectGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.newDiverSelectGender.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.newDiverSelectGender.Location = new System.Drawing.Point(592, 518);
            this.newDiverSelectGender.MaxLength = 100;
            this.newDiverSelectGender.Name = "newDiverSelectGender";
            this.newDiverSelectGender.Size = new System.Drawing.Size(60, 21);
            this.newDiverSelectGender.Sorted = true;
            this.newDiverSelectGender.TabIndex = 19;
            // 
            // DiveTypeInput_dataGridView
            // 
            this.DiveTypeInput_dataGridView.AllowUserToAddRows = false;
            this.DiveTypeInput_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DiveTypeInput_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.Type,
            this.Height,
            this.Position});
            this.DiveTypeInput_dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DiveTypeInput_dataGridView.EnableHeadersVisualStyles = false;
            this.DiveTypeInput_dataGridView.Location = new System.Drawing.Point(23, 315);
            this.DiveTypeInput_dataGridView.Name = "DiveTypeInput_dataGridView";
            this.DiveTypeInput_dataGridView.Size = new System.Drawing.Size(264, 142);
            this.DiveTypeInput_dataGridView.TabIndex = 26;
            this.DiveTypeInput_dataGridView.Visible = false;
            this.DiveTypeInput_dataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.DiveTypeInput_dataGridView.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            // 
            // Code
            // 
            this.Code.HeaderText = "Kod";
            this.Code.Name = "Code";
            this.Code.Width = 51;
            // 
            // Type
            // 
            this.Type.HeaderText = "Name";
            this.Type.Name = "Type";
            this.Type.Width = 60;
            // 
            // Height
            // 
            this.Height.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Height.HeaderText = "Höjd";
            this.Height.Items.AddRange(new object[] {
            "1m",
            "3m",
            "5m",
            "7,5m",
            "10m"});
            this.Height.Name = "Height";
            this.Height.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Height.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Height.ToolTipText = "1m";
            this.Height.Width = 55;
            // 
            // Position
            // 
            this.Position.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Position.HeaderText = "Position";
            this.Position.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.Position.Name = "Position";
            this.Position.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Position.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Position.Width = 55;
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
            this.listViewJudges_contextMenuStrip.Size = new System.Drawing.Size(153, 48);
            // 
            // RemoveJudge_toolStripMenuItem
            // 
            this.RemoveJudge_toolStripMenuItem.Enabled = false;
            this.RemoveJudge_toolStripMenuItem.Name = "RemoveJudge_toolStripMenuItem";
            this.RemoveJudge_toolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RemoveJudge_toolStripMenuItem.Text = "Ta bort";
            // 
            // FormNewEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 552);
            this.Controls.Add(this.DiveTypeInput_dataGridView);
            this.Controls.Add(this.newDiverSelectGender);
            this.Controls.Add(this.newJudgeSubmit);
            this.Controls.Add(this.newJudgeName);
            this.Controls.Add(this.AddNewDiverSubmit);
            this.Controls.Add(this.newDiverCountry);
            this.Controls.Add(this.newDiverAge);
            this.Controls.Add(this.newDiverName);
            this.Controls.Add(this.listViewDivers);
            this.Controls.Add(this.listViewJudge);
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
            ((System.ComponentModel.ISupportInitialize)(this.DiveCount_numericUpDown)).EndInit();
            this.groupBoxDisciplin.ResumeLayout(false);
            this.groupBoxDisciplin.PerformLayout();
            this.groupBoxSingle.ResumeLayout(false);
            this.groupBoxSingle.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiveTypeInput_dataGridView)).EndInit();
            this.listViewDivers_contextMenuStrip.ResumeLayout(false);
            this.listViewJudges_contextMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView DiveTypeInput_dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewComboBoxColumn Height;
        private System.Windows.Forms.DataGridViewComboBoxColumn Position;
        private System.Windows.Forms.ContextMenuStrip listViewDivers_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RemoveDiverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditDiverToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip listViewJudges_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RemoveJudge_toolStripMenuItem;
    }
}