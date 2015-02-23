namespace Simhopp
{
    partial class FormMain
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
            this.StartEvent_btn = new System.Windows.Forms.Button();
            this.listViewResult = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreateNewEvent_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PrintResult_btn = new System.Windows.Forms.Button();
            this.listViewEvent = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startaTävlingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stoppaTävlingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taBortEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegisterResult_btn = new System.Windows.Forms.Button();
            this.ResultsToFullScreen_btn = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartEvent_btn
            // 
            this.StartEvent_btn.Enabled = false;
            this.StartEvent_btn.Location = new System.Drawing.Point(26, 444);
            this.StartEvent_btn.Name = "StartEvent_btn";
            this.StartEvent_btn.Size = new System.Drawing.Size(75, 23);
            this.StartEvent_btn.TabIndex = 1;
            this.StartEvent_btn.Text = "Starta Event";
            this.StartEvent_btn.UseVisualStyleBackColor = true;
            this.StartEvent_btn.Click += new System.EventHandler(this.StartEventClick);
            // 
            // listViewResult
            // 
            this.listViewResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1});
            this.listViewResult.GridLines = true;
            this.listViewResult.Location = new System.Drawing.Point(522, 51);
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.Size = new System.Drawing.Size(379, 387);
            this.listViewResult.TabIndex = 3;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            this.listViewResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "Resultat";
            this.columnHeader2.Width = 81;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 0;
            this.columnHeader1.Text = "Namn";
            this.columnHeader1.Width = 290;
            // 
            // CreateNewEvent_btn
            // 
            this.CreateNewEvent_btn.Location = new System.Drawing.Point(26, 517);
            this.CreateNewEvent_btn.Name = "CreateNewEvent_btn";
            this.CreateNewEvent_btn.Size = new System.Drawing.Size(122, 23);
            this.CreateNewEvent_btn.TabIndex = 4;
            this.CreateNewEvent_btn.Text = "Skapa Nytt Event";
            this.CreateNewEvent_btn.UseVisualStyleBackColor = true;
            this.CreateNewEvent_btn.Click += new System.EventHandler(this.CreateEventClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Event";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Resultat";
            // 
            // PrintResult_btn
            // 
            this.PrintResult_btn.Location = new System.Drawing.Point(522, 444);
            this.PrintResult_btn.Name = "PrintResult_btn";
            this.PrintResult_btn.Size = new System.Drawing.Size(100, 23);
            this.PrintResult_btn.TabIndex = 8;
            this.PrintResult_btn.Text = "Skriv Ut Resultat";
            this.PrintResult_btn.UseVisualStyleBackColor = true;
            // 
            // listViewEvent
            // 
            this.listViewEvent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader5,
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader8});
            this.listViewEvent.FullRowSelect = true;
            this.listViewEvent.GridLines = true;
            this.listViewEvent.HideSelection = false;
            this.listViewEvent.Location = new System.Drawing.Point(26, 51);
            this.listViewEvent.Name = "listViewEvent";
            this.listViewEvent.Size = new System.Drawing.Size(472, 387);
            this.listViewEvent.TabIndex = 9;
            this.listViewEvent.UseCompatibleStateImageBehavior = false;
            this.listViewEvent.View = System.Windows.Forms.View.Details;
            this.listViewEvent.ItemActivate += new System.EventHandler(this.listViewEvent_ItemActivate);
            this.listViewEvent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewEvent_MouseDown);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "";
            this.columnHeader7.Width = 20;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Namn";
            this.columnHeader5.Width = 193;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Plats";
            this.columnHeader4.Width = 124;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Datum";
            this.columnHeader3.Width = 81;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Gender";
            this.columnHeader6.Width = 50;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "";
            this.columnHeader8.Width = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startaTävlingToolStripMenuItem,
            this.stoppaTävlingToolStripMenuItem,
            this.taBortEventToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 70);
            // 
            // startaTävlingToolStripMenuItem
            // 
            this.startaTävlingToolStripMenuItem.Name = "startaTävlingToolStripMenuItem";
            this.startaTävlingToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.startaTävlingToolStripMenuItem.Text = "Starta tävling";
            this.startaTävlingToolStripMenuItem.Click += new System.EventHandler(this.startaTävlingToolStripMenuItem_Click);
            // 
            // stoppaTävlingToolStripMenuItem
            // 
            this.stoppaTävlingToolStripMenuItem.Name = "stoppaTävlingToolStripMenuItem";
            this.stoppaTävlingToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.stoppaTävlingToolStripMenuItem.Text = "Stoppa tävling";
            this.stoppaTävlingToolStripMenuItem.Click += new System.EventHandler(this.stoppaTävlingToolStripMenuItem_Click);
            // 
            // taBortEventToolStripMenuItem
            // 
            this.taBortEventToolStripMenuItem.Name = "taBortEventToolStripMenuItem";
            this.taBortEventToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.taBortEventToolStripMenuItem.Text = "Ta bort event";
            this.taBortEventToolStripMenuItem.Click += new System.EventHandler(this.taBortEventToolStripMenuItem_Click);
            // 
            // RegisterResult_btn
            // 
            this.RegisterResult_btn.Location = new System.Drawing.Point(107, 444);
            this.RegisterResult_btn.Name = "RegisterResult_btn";
            this.RegisterResult_btn.Size = new System.Drawing.Size(106, 23);
            this.RegisterResult_btn.TabIndex = 10;
            this.RegisterResult_btn.Text = "Registrera Resultat";
            this.RegisterResult_btn.UseVisualStyleBackColor = true;
            this.RegisterResult_btn.Click += new System.EventHandler(this.RegisterResultClick);
            // 
            // ResultsToFullScreen_btn
            // 
            this.ResultsToFullScreen_btn.Location = new System.Drawing.Point(655, 444);
            this.ResultsToFullScreen_btn.Name = "ResultsToFullScreen_btn";
            this.ResultsToFullScreen_btn.Size = new System.Drawing.Size(100, 23);
            this.ResultsToFullScreen_btn.TabIndex = 11;
            this.ResultsToFullScreen_btn.Text = "Visa Fullskärm";
            this.ResultsToFullScreen_btn.UseVisualStyleBackColor = true;
            this.ResultsToFullScreen_btn.Click += new System.EventHandler(this.ResultsToFullScreen_btn_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 552);
            this.Controls.Add(this.ResultsToFullScreen_btn);
            this.Controls.Add(this.RegisterResult_btn);
            this.Controls.Add(this.listViewEvent);
            this.Controls.Add(this.PrintResult_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateNewEvent_btn);
            this.Controls.Add(this.listViewResult);
            this.Controls.Add(this.StartEvent_btn);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartEvent_btn;
        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button CreateNewEvent_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PrintResult_btn;
        private System.Windows.Forms.ListView listViewEvent;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startaTävlingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stoppaTävlingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taBortEventToolStripMenuItem;
        private System.Windows.Forms.Button RegisterResult_btn;
        private System.Windows.Forms.Button ResultsToFullScreen_btn;

    }
}