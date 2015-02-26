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
            this.listViewJudge = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddJudgeToEvent = new System.Windows.Forms.Button();
            this.ExitForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewJudge
            // 
            this.listViewJudge.CheckBoxes = true;
            this.listViewJudge.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewJudge.Location = new System.Drawing.Point(0, 0);
            this.listViewJudge.Name = "listViewJudge";
            this.listViewJudge.Size = new System.Drawing.Size(208, 314);
            this.listViewJudge.TabIndex = 0;
            this.listViewJudge.UseCompatibleStateImageBehavior = false;
            this.listViewJudge.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 160;
            // 
            // AddJudgeToEvent
            // 
            this.AddJudgeToEvent.Location = new System.Drawing.Point(0, 320);
            this.AddJudgeToEvent.Name = "AddJudgeToEvent";
            this.AddJudgeToEvent.Size = new System.Drawing.Size(75, 23);
            this.AddJudgeToEvent.TabIndex = 1;
            this.AddJudgeToEvent.Text = "Add";
            this.AddJudgeToEvent.UseVisualStyleBackColor = true;
            this.AddJudgeToEvent.Click += new System.EventHandler(this.AddJudgeToEvent_Click);
            // 
            // ExitForm
            // 
            this.ExitForm.Location = new System.Drawing.Point(81, 320);
            this.ExitForm.Name = "ExitForm";
            this.ExitForm.Size = new System.Drawing.Size(75, 23);
            this.ExitForm.TabIndex = 2;
            this.ExitForm.Text = "Exit";
            this.ExitForm.UseVisualStyleBackColor = true;
            this.ExitForm.Click += new System.EventHandler(this.ExitForm_Click);
            // 
            // FormJudgeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 350);
            this.Controls.Add(this.ExitForm);
            this.Controls.Add(this.AddJudgeToEvent);
            this.Controls.Add(this.listViewJudge);
            this.Name = "FormJudgeList";
            this.Text = "FormJudgeList";
            this.Load += new System.EventHandler(this.FormJudgeList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewJudge;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button AddJudgeToEvent;
        private System.Windows.Forms.Button ExitForm;

    }
}