
namespace OAHeLP_Database_Project
{
    partial class MedicalHistory
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
            this.uxMedicalHistoryDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.uxMedicalHistoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // uxMedicalHistoryDataGridView
            // 
            this.uxMedicalHistoryDataGridView.AllowUserToAddRows = false;
            this.uxMedicalHistoryDataGridView.AllowUserToDeleteRows = false;
            this.uxMedicalHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxMedicalHistoryDataGridView.Location = new System.Drawing.Point(12, 12);
            this.uxMedicalHistoryDataGridView.Name = "uxMedicalHistoryDataGridView";
            this.uxMedicalHistoryDataGridView.ReadOnly = true;
            this.uxMedicalHistoryDataGridView.Size = new System.Drawing.Size(684, 416);
            this.uxMedicalHistoryDataGridView.TabIndex = 0;
            // 
            // MedicalHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 440);
            this.Controls.Add(this.uxMedicalHistoryDataGridView);
            this.Name = "MedicalHistory";
            this.Text = "MedicalHistory";
            ((System.ComponentModel.ISupportInitialize)(this.uxMedicalHistoryDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView uxMedicalHistoryDataGridView;
    }
}