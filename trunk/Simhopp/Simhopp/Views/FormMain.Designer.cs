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
            this.Event_label = new System.Windows.Forms.Label();
            this.Resultat_label = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartEvent_btn
            // 
            this.StartEvent_btn.Enabled = false;
            this.StartEvent_btn.Location = new System.Drawing.Point(3, 3);
            this.StartEvent_btn.Name = "StartEvent_btn";
            this.StartEvent_btn.Size = new System.Drawing.Size(100, 23);
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
            this.listViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResult.GridLines = true;
            this.listViewResult.Location = new System.Drawing.Point(495, 36);
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.Size = new System.Drawing.Size(486, 435);
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
            this.CreateNewEvent_btn.Location = new System.Drawing.Point(3, 3);
            this.CreateNewEvent_btn.Name = "CreateNewEvent_btn";
            this.CreateNewEvent_btn.Size = new System.Drawing.Size(100, 23);
            this.CreateNewEvent_btn.TabIndex = 4;
            this.CreateNewEvent_btn.Text = "Skapa Nytt Event";
            this.CreateNewEvent_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateNewEvent_btn.UseVisualStyleBackColor = true;
            this.CreateNewEvent_btn.Click += new System.EventHandler(this.CreateEventClick);
            // 
            // Event_label
            // 
            this.Event_label.AutoSize = true;
            this.Event_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Event_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Event_label.Location = new System.Drawing.Point(3, 0);
            this.Event_label.Name = "Event_label";
            this.Event_label.Size = new System.Drawing.Size(486, 33);
            this.Event_label.TabIndex = 5;
            this.Event_label.Text = "Event";
            this.Event_label.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Resultat_label
            // 
            this.Resultat_label.AutoSize = true;
            this.Resultat_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Resultat_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resultat_label.Location = new System.Drawing.Point(495, 0);
            this.Resultat_label.Name = "Resultat_label";
            this.Resultat_label.Size = new System.Drawing.Size(486, 33);
            this.Resultat_label.TabIndex = 6;
            this.Resultat_label.Text = "Resultat";
            this.Resultat_label.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // PrintResult_btn
            // 
            this.PrintResult_btn.Location = new System.Drawing.Point(3, 3);
            this.PrintResult_btn.Name = "PrintResult_btn";
            this.PrintResult_btn.Size = new System.Drawing.Size(100, 23);
            this.PrintResult_btn.TabIndex = 8;
            this.PrintResult_btn.Text = "Skriv Ut Resultat";
            this.PrintResult_btn.UseVisualStyleBackColor = true;
            this.PrintResult_btn.Click += new System.EventHandler(this.PrintResult_btn_Click);
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
            this.listViewEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEvent.FullRowSelect = true;
            this.listViewEvent.GridLines = true;
            this.listViewEvent.HideSelection = false;
            this.listViewEvent.Location = new System.Drawing.Point(3, 36);
            this.listViewEvent.Name = "listViewEvent";
            this.listViewEvent.Size = new System.Drawing.Size(486, 435);
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
            this.RegisterResult_btn.Location = new System.Drawing.Point(109, 3);
            this.RegisterResult_btn.Name = "RegisterResult_btn";
            this.RegisterResult_btn.Size = new System.Drawing.Size(108, 23);
            this.RegisterResult_btn.TabIndex = 10;
            this.RegisterResult_btn.Text = "Registrera Resultat";
            this.RegisterResult_btn.UseVisualStyleBackColor = true;
            this.RegisterResult_btn.Click += new System.EventHandler(this.RegisterResultClick);
            // 
            // ResultsToFullScreen_btn
            // 
            this.ResultsToFullScreen_btn.Location = new System.Drawing.Point(109, 3);
            this.ResultsToFullScreen_btn.Name = "ResultsToFullScreen_btn";
            this.ResultsToFullScreen_btn.Size = new System.Drawing.Size(92, 23);
            this.ResultsToFullScreen_btn.TabIndex = 11;
            this.ResultsToFullScreen_btn.Text = "Visa Fullskärm";
            this.ResultsToFullScreen_btn.UseVisualStyleBackColor = true;
            this.ResultsToFullScreen_btn.Click += new System.EventHandler(this.ResultsToFullScreen_btn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.listViewEvent, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Resultat_label, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listViewResult, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Event_label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.03125F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.96875F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 552);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.21429F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.78571F));
            this.tableLayoutPanel2.Controls.Add(this.StartEvent_btn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.RegisterResult_btn, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 477);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(221, 30);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.96078F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.03922F));
            this.tableLayoutPanel3.Controls.Add(this.PrintResult_btn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ResultsToFullScreen_btn, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(495, 477);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(204, 30);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.CreateNewEvent_btn, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 513);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 36);
            this.tableLayoutPanel4.TabIndex = 12;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 552);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartEvent_btn;
        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button CreateNewEvent_btn;
        private System.Windows.Forms.Label Event_label;
        private System.Windows.Forms.Label Resultat_label;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;

    }
}