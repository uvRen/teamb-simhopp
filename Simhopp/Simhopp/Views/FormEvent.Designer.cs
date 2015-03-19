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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEvent));
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
            this.contextMenuJudges = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.judgeMenuKick = new System.Windows.Forms.ToolStripMenuItem();
            this.judgeMenuRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.listIcons = new System.Windows.Forms.ImageList(this.components);
            this.panelEventInfo = new System.Windows.Forms.Panel();
            this.FormEventHelp_label = new System.Windows.Forms.Label();
            this.labelSummary = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxSeverLog = new System.Windows.Forms.TextBox();
            this.panelServer = new System.Windows.Forms.Panel();
            this.checkBoxNewConnections = new System.Windows.Forms.CheckBox();
            this.labelClientServerTitle = new System.Windows.Forms.Label();
            this.btnServerKick = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.labelServerStatus = new System.Windows.Forms.Label();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.panelControls.SuspendLayout();
            this.contextMenuJudges.SuspendLayout();
            this.panelEventInfo.SuspendLayout();
            this.panelServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsRounds
            // 
            this.tabsRounds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsRounds.Location = new System.Drawing.Point(302, 12);
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
            this.listViewLeaderboard.Location = new System.Drawing.Point(738, 12);
            this.listViewLeaderboard.Name = "listViewLeaderboard";
            this.listViewLeaderboard.Size = new System.Drawing.Size(208, 187);
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
            this.labelDiver.Location = new System.Drawing.Point(6, 16);
            this.labelDiver.Name = "labelDiver";
            this.labelDiver.Size = new System.Drawing.Size(86, 72);
            this.labelDiver.TabIndex = 6;
            this.labelDiver.Text = "Runda\r\n1 av 2";
            this.labelDiver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRound
            // 
            this.labelRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRound.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRound.ForeColor = System.Drawing.Color.White;
            this.labelRound.Location = new System.Drawing.Point(844, 16);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(83, 72);
            this.labelRound.TabIndex = 5;
            this.labelRound.Text = "Runda\r\n1 av 2";
            this.labelRound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pagePanelContainer
            // 
            this.pagePanelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pagePanelContainer.Location = new System.Drawing.Point(302, 32);
            this.pagePanelContainer.Name = "pagePanelContainer";
            this.pagePanelContainer.Size = new System.Drawing.Size(430, 309);
            this.pagePanelContainer.TabIndex = 6;
            // 
            // listViewJudges
            // 
            this.listViewJudges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewJudges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listViewJudges.ContextMenuStrip = this.contextMenuJudges;
            this.listViewJudges.ForeColor = System.Drawing.Color.White;
            this.listViewJudges.Location = new System.Drawing.Point(738, 205);
            this.listViewJudges.Name = "listViewJudges";
            this.listViewJudges.Size = new System.Drawing.Size(208, 136);
            this.listViewJudges.SmallImageList = this.listIcons;
            this.listViewJudges.TabIndex = 9;
            this.listViewJudges.UseCompatibleStateImageBehavior = false;
            this.listViewJudges.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Domare";
            this.columnHeader3.Width = 192;
            // 
            // contextMenuJudges
            // 
            this.contextMenuJudges.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.judgeMenuKick,
            this.judgeMenuRequest});
            this.contextMenuJudges.Name = "contextMenuJudges";
            this.contextMenuJudges.Size = new System.Drawing.Size(146, 48);
            // 
            // judgeMenuKick
            // 
            this.judgeMenuKick.Name = "judgeMenuKick";
            this.judgeMenuKick.Size = new System.Drawing.Size(145, 22);
            this.judgeMenuKick.Text = "Sparka ut";
            this.judgeMenuKick.Click += new System.EventHandler(this.judgeMenuKick_Click);
            // 
            // judgeMenuRequest
            // 
            this.judgeMenuRequest.Name = "judgeMenuRequest";
            this.judgeMenuRequest.Size = new System.Drawing.Size(145, 22);
            this.judgeMenuRequest.Text = "Be om poäng";
            this.judgeMenuRequest.Visible = false;
            this.judgeMenuRequest.Click += new System.EventHandler(this.judgeMenuRequest_Click);
            // 
            // listIcons
            // 
            this.listIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listIcons.ImageStream")));
            this.listIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.listIcons.Images.SetKeyName(0, "Status-Online-32.png");
            this.listIcons.Images.SetKeyName(1, "Status-Offline-32.png");
            this.listIcons.Images.SetKeyName(2, "Online-256.png");
            this.listIcons.Images.SetKeyName(3, "Judge.ico");
            this.listIcons.Images.SetKeyName(4, "Internet-64.png");
            this.listIcons.Images.SetKeyName(5, "Computer-32.png");
            // 
            // panelEventInfo
            // 
            this.panelEventInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelEventInfo.Controls.Add(this.FormEventHelp_label);
            this.panelEventInfo.Controls.Add(this.labelSummary);
            this.panelEventInfo.Controls.Add(this.labelTitle);
            this.panelEventInfo.Controls.Add(this.textBoxSeverLog);
            this.panelEventInfo.Location = new System.Drawing.Point(12, 12);
            this.panelEventInfo.Name = "panelEventInfo";
            this.panelEventInfo.Size = new System.Drawing.Size(284, 240);
            this.panelEventInfo.TabIndex = 10;
            // 
            // FormEventHelp_label
            // 
            this.FormEventHelp_label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.FormEventHelp_label.AutoSize = true;
            this.FormEventHelp_label.ForeColor = System.Drawing.Color.Gainsboro;
            this.FormEventHelp_label.Location = new System.Drawing.Point(15, 139);
            this.FormEventHelp_label.Name = "FormEventHelp_label";
            this.FormEventHelp_label.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.FormEventHelp_label.Size = new System.Drawing.Size(209, 82);
            this.FormEventHelp_label.TabIndex = 2;
            this.FormEventHelp_label.Text = "HOTKEYS\r\n - SPACE: Bedöm nästa hopp/Nästa runda\r\n - §:                0 p \r\n - 1-" +
    "9:          1-9 p\r\n - 0:              10 p\r\n - SHIFT:   +0,5 p";
            this.FormEventHelp_label.Visible = false;
            // 
            // labelSummary
            // 
            this.labelSummary.AutoSize = true;
            this.labelSummary.ForeColor = System.Drawing.Color.White;
            this.labelSummary.Location = new System.Drawing.Point(15, 60);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(72, 13);
            this.labelSummary.TabIndex = 1;
            this.labelSummary.Text = "labelSummary";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(14, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(54, 19);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "label1";
            // 
            // textBoxSeverLog
            // 
            this.textBoxSeverLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSeverLog.Location = new System.Drawing.Point(0, 42);
            this.textBoxSeverLog.Multiline = true;
            this.textBoxSeverLog.Name = "textBoxSeverLog";
            this.textBoxSeverLog.Size = new System.Drawing.Size(278, 77);
            this.textBoxSeverLog.TabIndex = 0;
            this.textBoxSeverLog.Visible = false;
            // 
            // panelServer
            // 
            this.panelServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelServer.Controls.Add(this.checkBoxNewConnections);
            this.panelServer.Controls.Add(this.labelClientServerTitle);
            this.panelServer.Controls.Add(this.btnServerKick);
            this.panelServer.Controls.Add(this.btnStopServer);
            this.panelServer.Controls.Add(this.labelServerStatus);
            this.panelServer.Controls.Add(this.btnStartServer);
            this.panelServer.Location = new System.Drawing.Point(12, 258);
            this.panelServer.Name = "panelServer";
            this.panelServer.Size = new System.Drawing.Size(284, 83);
            this.panelServer.TabIndex = 11;
            // 
            // checkBoxNewConnections
            // 
            this.checkBoxNewConnections.AutoSize = true;
            this.checkBoxNewConnections.Enabled = false;
            this.checkBoxNewConnections.Location = new System.Drawing.Point(173, 53);
            this.checkBoxNewConnections.Name = "checkBoxNewConnections";
            this.checkBoxNewConnections.Size = new System.Drawing.Size(105, 17);
            this.checkBoxNewConnections.TabIndex = 7;
            this.checkBoxNewConnections.Text = "Nya anslutningar";
            this.checkBoxNewConnections.UseVisualStyleBackColor = true;
            this.checkBoxNewConnections.CheckedChanged += new System.EventHandler(this.checkBoxNewConnections_CheckedChanged);
            // 
            // labelClientServerTitle
            // 
            this.labelClientServerTitle.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.labelClientServerTitle.ForeColor = System.Drawing.Color.White;
            this.labelClientServerTitle.Location = new System.Drawing.Point(10, 8);
            this.labelClientServerTitle.Name = "labelClientServerTitle";
            this.labelClientServerTitle.Size = new System.Drawing.Size(260, 19);
            this.labelClientServerTitle.TabIndex = 6;
            this.labelClientServerTitle.Text = "Klientinloggning";
            // 
            // btnServerKick
            // 
            this.btnServerKick.BackgroundImage = global::Simhopp.Properties.Resources.Cut_32;
            this.btnServerKick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnServerKick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnServerKick.Location = new System.Drawing.Point(246, 16);
            this.btnServerKick.Name = "btnServerKick";
            this.btnServerKick.Size = new System.Drawing.Size(24, 24);
            this.btnServerKick.TabIndex = 5;
            this.btnServerKick.Text = " ";
            this.btnServerKick.UseVisualStyleBackColor = true;
            this.btnServerKick.Visible = false;
            // 
            // btnStopServer
            // 
            this.btnStopServer.BackgroundImage = global::Simhopp.Properties.Resources.Controls_stop_32;
            this.btnStopServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStopServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnStopServer.Location = new System.Drawing.Point(216, 16);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(24, 24);
            this.btnStopServer.TabIndex = 4;
            this.btnStopServer.Text = " ";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Visible = false;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // labelServerStatus
            // 
            this.labelServerStatus.AutoSize = true;
            this.labelServerStatus.ForeColor = System.Drawing.Color.White;
            this.labelServerStatus.Location = new System.Drawing.Point(42, 54);
            this.labelServerStatus.Name = "labelServerStatus";
            this.labelServerStatus.Size = new System.Drawing.Size(109, 13);
            this.labelServerStatus.TabIndex = 2;
            this.labelServerStatus.Text = "Klientserver avstängd";
            // 
            // btnStartServer
            // 
            this.btnStartServer.BackgroundImage = global::Simhopp.Properties.Resources.Controls_play_32;
            this.btnStartServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnStartServer.Location = new System.Drawing.Point(12, 48);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(24, 24);
            this.btnStartServer.TabIndex = 1;
            this.btnStartServer.Text = " ";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // FormEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 524);
            this.Controls.Add(this.panelServer);
            this.Controls.Add(this.panelEventInfo);
            this.Controls.Add(this.listViewJudges);
            this.Controls.Add(this.listViewLeaderboard);
            this.Controls.Add(this.pagePanelContainer);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.tabsRounds);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormEvent";
            this.Text = "Tävling";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEvent_FormClosing);
            this.Load += new System.EventHandler(this.FormEvent_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormEvent_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormEvent_KeyUp);
            this.panelControls.ResumeLayout(false);
            this.contextMenuJudges.ResumeLayout(false);
            this.panelEventInfo.ResumeLayout(false);
            this.panelEventInfo.PerformLayout();
            this.panelServer.ResumeLayout(false);
            this.panelServer.PerformLayout();
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
        private System.Windows.Forms.Panel panelEventInfo;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelServer;
        private System.Windows.Forms.TextBox textBoxSeverLog;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Label labelServerStatus;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Label labelClientServerTitle;
        private System.Windows.Forms.Button btnServerKick;
        private System.Windows.Forms.Label FormEventHelp_label;
        private System.Windows.Forms.ImageList listIcons;
        private System.Windows.Forms.ContextMenuStrip contextMenuJudges;
        private System.Windows.Forms.ToolStripMenuItem judgeMenuKick;
        private System.Windows.Forms.ToolStripMenuItem judgeMenuRequest;
        private System.Windows.Forms.CheckBox checkBoxNewConnections;
    }
}