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
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
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
            this.button4 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Starta Event";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(522, 51);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(379, 387);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 517);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Skapa Nytt Event";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(522, 444);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Skriv Ut Resultat";
            this.button3.UseVisualStyleBackColor = true;
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
            this.columnHeader5.Width = 180;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Plats";
            this.columnHeader4.Width = 109;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Datum";
            this.columnHeader3.Width = 80;
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(107, 444);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "REG Resultat";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 552);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.listViewEvent);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
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
        private System.Windows.Forms.Button button4;

    }
}