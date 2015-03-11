namespace Simhopp_JudgeClient
{
    partial class FormJudgeClientView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJudgeClientView));
            this.listBoxJudges = new System.Windows.Forms.ListBox();
            this.panelSelectJudge = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelJudgeList = new System.Windows.Forms.Label();
            this.imgLoading = new System.Windows.Forms.PictureBox();
            this.panelSelectJudge.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxJudges
            // 
            this.listBoxJudges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxJudges.FormattingEnabled = true;
            this.listBoxJudges.Location = new System.Drawing.Point(15, 51);
            this.listBoxJudges.Name = "listBoxJudges";
            this.listBoxJudges.Size = new System.Drawing.Size(226, 199);
            this.listBoxJudges.TabIndex = 2;
            this.listBoxJudges.SelectedIndexChanged += new System.EventHandler(this.listBoxJudges_SelectedIndexChanged);
            // 
            // panelSelectJudge
            // 
            this.panelSelectJudge.Controls.Add(this.labelTitle);
            this.panelSelectJudge.Location = new System.Drawing.Point(12, 12);
            this.panelSelectJudge.Name = "panelSelectJudge";
            this.panelSelectJudge.Size = new System.Drawing.Size(258, 62);
            this.panelSelectJudge.TabIndex = 3;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(3, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(252, 41);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.Text = "Söker efter tävling...";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Location = new System.Drawing.Point(15, 13);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(226, 36);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Logga in";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(285, 12);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(572, 421);
            this.textBoxLog.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Location = new System.Drawing.Point(12, 371);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 62);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelJudgeList);
            this.panel2.Controls.Add(this.imgLoading);
            this.panel2.Controls.Add(this.listBoxJudges);
            this.panel2.Location = new System.Drawing.Point(12, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 267);
            this.panel2.TabIndex = 5;
            // 
            // labelJudgeList
            // 
            this.labelJudgeList.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJudgeList.ForeColor = System.Drawing.Color.White;
            this.labelJudgeList.Location = new System.Drawing.Point(3, 12);
            this.labelJudgeList.Name = "labelJudgeList";
            this.labelJudgeList.Size = new System.Drawing.Size(252, 26);
            this.labelJudgeList.TabIndex = 8;
            this.labelJudgeList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgLoading
            // 
            this.imgLoading.Image = global::Simhopp_JudgeClient.Properties.Resources.loading;
            this.imgLoading.Location = new System.Drawing.Point(95, 94);
            this.imgLoading.Name = "imgLoading";
            this.imgLoading.Size = new System.Drawing.Size(66, 66);
            this.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgLoading.TabIndex = 3;
            this.imgLoading.TabStop = false;
            // 
            // FormJudgeClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 445);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSelectJudge);
            this.Controls.Add(this.textBoxLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormJudgeClientView";
            this.Text = "Domarklient";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelSelectJudge.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxJudges;
        private System.Windows.Forms.Panel panelSelectJudge;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox imgLoading;
        private System.Windows.Forms.Label labelJudgeList;
    }
}

