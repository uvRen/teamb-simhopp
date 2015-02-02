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
            this.SuspendLayout();
            // 
            // listViewDivers
            // 
            this.listViewDivers.CheckBoxes = true;
            this.listViewDivers.Location = new System.Drawing.Point(13, 13);
            this.listViewDivers.Name = "listViewDivers";
            this.listViewDivers.Size = new System.Drawing.Size(259, 237);
            this.listViewDivers.TabIndex = 0;
            this.listViewDivers.UseCompatibleStateImageBehavior = false;
            this.listViewDivers.View = System.Windows.Forms.View.Details;
            // 
            // FormDiverList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.listViewDivers);
            this.Name = "FormDiverList";
            this.Text = "FormDiverList";
            this.Load += new System.EventHandler(this.FormDiverList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewDivers;
    }
}