namespace Simhopp
{
    partial class FormEvent
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
            this.tabsRounds = new System.Windows.Forms.TabControl();
            this.btnDoDive = new System.Windows.Forms.Button();
            this.btnNextRound = new System.Windows.Forms.Button();
            this.listViewLeaderboard = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelControls = new System.Windows.Forms.Panel();
            this.labelDiver = new System.Windows.Forms.Label();
            this.labelRound = new System.Windows.Forms.Label();
            this.pagePanelContainer = new System.Windows.Forms.Panel();
            this.listViewJudges = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsRounds
            // 
            this.tabsRounds.Location = new System.Drawing.Point(12, 12);
            this.tabsRounds.Name = "tabsRounds";
            this.tabsRounds.SelectedIndex = 0;
            this.tabsRounds.Size = new System.Drawing.Size(430, 21);
            this.tabsRounds.TabIndex = 0;
            // 
            // btnDoDive
            // 
            this.btnDoDive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDoDive.Location = new System.Drawing.Point(14, 91);
            this.btnDoDive.Name = "btnDoDive";
            this.btnDoDive.Size = new System.Drawing.Size(66, 58);
            this.btnDoDive.TabIndex = 2;
            this.btnDoDive.Text = "Bedöm nästa hopp";
            this.btnDoDive.UseVisualStyleBackColor = true;
            this.btnDoDive.Click += new System.EventHandler(this.btnDoDive_Click);
            // 
            // btnNextRound
            // 
            this.btnNextRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextRound.Enabled = false;
            this.btnNextRound.Location = new System.Drawing.Point(853, 91);
            this.btnNextRound.Name = "btnNextRound";
            this.btnNextRound.Size = new System.Drawing.Size(66, 58);
            this.btnNextRound.TabIndex = 3;
            this.btnNextRound.Text = "Nästa runda";
            this.btnNextRound.UseVisualStyleBackColor = true;
            this.btnNextRound.Click += new System.EventHandler(this.btnNextRound_Click);
            // 
            // listViewLeaderboard
            // 
            this.listViewLeaderboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLeaderboard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewLeaderboard.ForeColor = System.Drawing.Color.White;
            this.listViewLeaderboard.Location = new System.Drawing.Point(738, 26);
            this.listViewLeaderboard.Name = "listViewLeaderboard";
            this.listViewLeaderboard.Size = new System.Drawing.Size(208, 200);
            this.listViewLeaderboard.TabIndex = 4;
            this.listViewLeaderboard.UseCompatibleStateImageBehavior = false;
            this.listViewLeaderboard.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tävlande";
            this.columnHeader1.Width = 144;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Poäng";
            // 
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls.Controls.Add(this.labelDiver);
            this.panelControls.Controls.Add(this.labelRound);
            this.panelControls.Controls.Add(this.btnDoDive);
            this.panelControls.Controls.Add(this.btnNextRound);
            this.panelControls.Location = new System.Drawing.Point(12, 347);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(934, 165);
            this.panelControls.TabIndex = 5;
            // 
            // labelDiver
            // 
            this.labelDiver.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiver.ForeColor = System.Drawing.Color.White;
            this.labelDiver.Location = new System.Drawing.Point(14, 16);
            this.labelDiver.Name = "labelDiver";
            this.labelDiver.Size = new System.Drawing.Size(66, 72);
            this.labelDiver.TabIndex = 6;
            this.labelDiver.Text = "Runda\r\n1 av 2";
            this.labelDiver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRound
            // 
            this.labelRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRound.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRound.ForeColor = System.Drawing.Color.White;
            this.labelRound.Location = new System.Drawing.Point(853, 16);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(66, 72);
            this.labelRound.TabIndex = 5;
            this.labelRound.Text = "Runda\r\n1 av 2";
            this.labelRound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pagePanelContainer
            // 
            this.pagePanelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pagePanelContainer.Location = new System.Drawing.Point(12, 32);
            this.pagePanelContainer.Name = "pagePanelContainer";
            this.pagePanelContainer.Size = new System.Drawing.Size(430, 309);
            this.pagePanelContainer.TabIndex = 6;
            // 
            // listViewJudges
            // 
            this.listViewJudges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewJudges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listViewJudges.ForeColor = System.Drawing.Color.White;
            this.listViewJudges.Location = new System.Drawing.Point(738, 232);
            this.listViewJudges.Name = "listViewJudges";
            this.listViewJudges.Size = new System.Drawing.Size(208, 109);
            this.listViewJudges.TabIndex = 9;
            this.listViewJudges.UseCompatibleStateImageBehavior = false;
            this.listViewJudges.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Domare";
            this.columnHeader3.Width = 192;
            // 
            // FormEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 524);
            this.Controls.Add(this.listViewJudges);
            this.Controls.Add(this.listViewLeaderboard);
            this.Controls.Add(this.pagePanelContainer);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.tabsRounds);
            this.Name = "FormEvent";
            this.Text = "FormEvent";
            this.Load += new System.EventHandler(this.FormEvent_Load);
            this.panelControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsRounds;
        private System.Windows.Forms.Button btnDoDive;
        private System.Windows.Forms.Button btnNextRound;
        private System.Windows.Forms.ListView listViewLeaderboard;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Panel pagePanelContainer;
        private System.Windows.Forms.Label labelRound;
        private System.Windows.Forms.ListView listViewJudges;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label labelDiver;
    }
}