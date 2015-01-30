namespace Simhopp
{
    partial class FormJudgeList
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
            this.listBoxJudges = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // listBoxJudges
            // 
            this.listBoxJudges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxJudges.FormattingEnabled = true;
            this.listBoxJudges.Location = new System.Drawing.Point(12, 18);
            this.listBoxJudges.Name = "listBoxJudges";
            this.listBoxJudges.Size = new System.Drawing.Size(173, 274);
            this.listBoxJudges.TabIndex = 0;
            // 
            // FormJudgeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 313);
            this.Controls.Add(this.listBoxJudges);
            this.Name = "FormJudgeList";
            this.Text = "FormJudgeList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormJudgeList_FormClosing);
            this.Load += new System.EventHandler(this.FormJudgeList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox listBoxJudges;
    }
}