﻿
namespace OAHeLP_Database_Project
{
    partial class DetailedView
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
            this.uxProjectIDLabel = new System.Windows.Forms.Label();
            this.uxPictureBox = new System.Windows.Forms.PictureBox();
            this.uxNameLabel = new System.Windows.Forms.Label();
            this.uxSexLabel = new System.Windows.Forms.Label();
            this.uxAgeLabel = new System.Windows.Forms.Label();
            this.uxEthnicityLabel = new System.Windows.Forms.Label();
            this.uxResidenceHistory = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uxProjectIDLabel
            // 
            this.uxProjectIDLabel.AutoSize = true;
            this.uxProjectIDLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 18F);
            this.uxProjectIDLabel.ForeColor = System.Drawing.Color.White;
            this.uxProjectIDLabel.Location = new System.Drawing.Point(6, 9);
            this.uxProjectIDLabel.Name = "uxProjectIDLabel";
            this.uxProjectIDLabel.Size = new System.Drawing.Size(185, 31);
            this.uxProjectIDLabel.TabIndex = 0;
            this.uxProjectIDLabel.Text = "Project ID Label";
            // 
            // uxPictureBox
            // 
            this.uxPictureBox.Location = new System.Drawing.Point(12, 43);
            this.uxPictureBox.Name = "uxPictureBox";
            this.uxPictureBox.Size = new System.Drawing.Size(193, 187);
            this.uxPictureBox.TabIndex = 1;
            this.uxPictureBox.TabStop = false;
            // 
            // uxNameLabel
            // 
            this.uxNameLabel.AutoSize = true;
            this.uxNameLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.uxNameLabel.ForeColor = System.Drawing.Color.White;
            this.uxNameLabel.Location = new System.Drawing.Point(211, 52);
            this.uxNameLabel.Name = "uxNameLabel";
            this.uxNameLabel.Size = new System.Drawing.Size(147, 25);
            this.uxNameLabel.TabIndex = 2;
            this.uxNameLabel.Text = "Project ID Label";
            // 
            // uxSexLabel
            // 
            this.uxSexLabel.AutoSize = true;
            this.uxSexLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.uxSexLabel.ForeColor = System.Drawing.Color.White;
            this.uxSexLabel.Location = new System.Drawing.Point(211, 90);
            this.uxSexLabel.Name = "uxSexLabel";
            this.uxSexLabel.Size = new System.Drawing.Size(92, 25);
            this.uxSexLabel.TabIndex = 3;
            this.uxSexLabel.Text = "Sex Label";
            // 
            // uxAgeLabel
            // 
            this.uxAgeLabel.AutoSize = true;
            this.uxAgeLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.uxAgeLabel.ForeColor = System.Drawing.Color.White;
            this.uxAgeLabel.Location = new System.Drawing.Point(211, 128);
            this.uxAgeLabel.Name = "uxAgeLabel";
            this.uxAgeLabel.Size = new System.Drawing.Size(98, 25);
            this.uxAgeLabel.TabIndex = 3;
            this.uxAgeLabel.Text = "Age Label";
            // 
            // uxEthnicityLabel
            // 
            this.uxEthnicityLabel.AutoSize = true;
            this.uxEthnicityLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.uxEthnicityLabel.ForeColor = System.Drawing.Color.White;
            this.uxEthnicityLabel.Location = new System.Drawing.Point(211, 170);
            this.uxEthnicityLabel.Name = "uxEthnicityLabel";
            this.uxEthnicityLabel.Size = new System.Drawing.Size(133, 25);
            this.uxEthnicityLabel.TabIndex = 3;
            this.uxEthnicityLabel.Text = "Ethnicity Label";
            // 
            // uxResidenceHistory
            // 
            this.uxResidenceHistory.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.uxResidenceHistory.FormattingEnabled = true;
            this.uxResidenceHistory.ItemHeight = 20;
            this.uxResidenceHistory.Location = new System.Drawing.Point(12, 268);
            this.uxResidenceHistory.Name = "uxResidenceHistory";
            this.uxResidenceHistory.Size = new System.Drawing.Size(381, 124);
            this.uxResidenceHistory.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Enabled = false;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.button5.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.button5.Location = new System.Drawing.Point(12, 236);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(381, 34);
            this.button5.TabIndex = 22;
            this.button5.Text = "Residence History";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // DetailedView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(617, 404);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.uxResidenceHistory);
            this.Controls.Add(this.uxEthnicityLabel);
            this.Controls.Add(this.uxAgeLabel);
            this.Controls.Add(this.uxSexLabel);
            this.Controls.Add(this.uxNameLabel);
            this.Controls.Add(this.uxPictureBox);
            this.Controls.Add(this.uxProjectIDLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DetailedView";
            this.Text = "DetailedView";
            ((System.ComponentModel.ISupportInitialize)(this.uxPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label uxProjectIDLabel;
        private System.Windows.Forms.PictureBox uxPictureBox;
        private System.Windows.Forms.Label uxNameLabel;
        private System.Windows.Forms.Label uxSexLabel;
        private System.Windows.Forms.Label uxAgeLabel;
        private System.Windows.Forms.Label uxEthnicityLabel;
        private System.Windows.Forms.ListBox uxResidenceHistory;
        private System.Windows.Forms.Button button5;
    }
}