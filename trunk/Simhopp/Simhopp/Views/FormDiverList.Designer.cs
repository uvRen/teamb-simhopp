namespace Simhopp
{
    partial class FormDiverList
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
            this.listViewDivers = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addDiverToEvent = new System.Windows.Forms.Button();
            this.ExitForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewDivers
            // 
            this.listViewDivers.CheckBoxes = true;
            this.listViewDivers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listViewDivers.Location = new System.Drawing.Point(1, 0);
            this.listViewDivers.Name = "listViewDivers";
            this.listViewDivers.Size = new System.Drawing.Size(453, 413);
            this.listViewDivers.TabIndex = 0;
            this.listViewDivers.UseCompatibleStateImageBehavior = false;
            this.listViewDivers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            this.columnHeader6.Width = 40;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Name";
            this.columnHeader7.Width = 160;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Country";
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Age";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Gender";
            // 
            // addDiverToEvent
            // 
            this.addDiverToEvent.Location = new System.Drawing.Point(12, 419);
            this.addDiverToEvent.Name = "addDiverToEvent";
            this.addDiverToEvent.Size = new System.Drawing.Size(75, 23);
            this.addDiverToEvent.TabIndex = 1;
            this.addDiverToEvent.Text = "Add";
            this.addDiverToEvent.UseVisualStyleBackColor = true;
            this.addDiverToEvent.Click += new System.EventHandler(this.addDiverToEvent_Click);
            // 
            // ExitForm
            // 
            this.ExitForm.Location = new System.Drawing.Point(93, 419);
            this.ExitForm.Name = "ExitForm";
            this.ExitForm.Size = new System.Drawing.Size(75, 23);
            this.ExitForm.TabIndex = 2;
            this.ExitForm.Text = "Exit";
            this.ExitForm.UseVisualStyleBackColor = true;
            this.ExitForm.Click += new System.EventHandler(this.ExitForm_Click);
            // 
            // FormDiverList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 449);
            this.Controls.Add(this.ExitForm);
            this.Controls.Add(this.addDiverToEvent);
            this.Controls.Add(this.listViewDivers);
            this.Name = "FormDiverList";
            this.Text = "FormDiverList";
            this.Load += new System.EventHandler(this.FormDiverList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewDivers;
        private System.Windows.Forms.Button addDiverToEvent;
        private System.Windows.Forms.Button ExitForm;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}