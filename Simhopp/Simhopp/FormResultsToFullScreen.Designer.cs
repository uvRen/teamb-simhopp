namespace Simhopp
{
    partial class FormResultsToFullScreen
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
            this.listViewResult = new System.Windows.Forms.ListView();
            this.ResultatHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NamnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewResult
            // 
            this.listViewResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ResultatHeader,
            this.NamnHeader});
            this.listViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResult.GridLines = true;
            this.listViewResult.Location = new System.Drawing.Point(0, 0);
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.Size = new System.Drawing.Size(772, 405);
            this.listViewResult.TabIndex = 4;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            this.listViewResult.View = System.Windows.Forms.View.Details;
            this.listViewResult.SelectedIndexChanged += new System.EventHandler(this.listViewResult_SelectedIndexChanged);
            // 
            // ResultatHeader
            // 
            this.ResultatHeader.DisplayIndex = 1;
            this.ResultatHeader.Text = "Resultat";
            this.ResultatHeader.Width = 492;
            // 
            // NamnHeader
            // 
            this.NamnHeader.DisplayIndex = 0;
            this.NamnHeader.Text = "Namn";
            this.NamnHeader.Width = 481;
            // 
            // FormResultsToFullScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(772, 405);
            this.Controls.Add(this.listViewResult);
            this.Name = "FormResultsToFullScreen";
            this.ShowIcon = false;
            this.Text = "FormResultsToFullScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.ColumnHeader ResultatHeader;
        private System.Windows.Forms.ColumnHeader NamnHeader;

    }
}