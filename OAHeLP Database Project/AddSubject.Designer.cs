
namespace OAHeLP_Database_Project
{
    partial class AddSubject
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
            this.uxEthnicGroupComboBoxAdd = new System.Windows.Forms.ComboBox();
            this.uxEthnicGroupLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.uxOaHeLPIDLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxEthnicGroupComboBoxAdd
            // 
            this.uxEthnicGroupComboBoxAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxEthnicGroupComboBoxAdd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F);
            this.uxEthnicGroupComboBoxAdd.FormattingEnabled = true;
            this.uxEthnicGroupComboBoxAdd.Items.AddRange(new object[] {
            "Batek",
            "Jahai",
            "Jakun",
            "Lanoh",
            "Malay",
            "Mendriq",
            "Semai",
            "Temiar",
            "Temuan"});
            this.uxEthnicGroupComboBoxAdd.Location = new System.Drawing.Point(180, 134);
            this.uxEthnicGroupComboBoxAdd.Name = "uxEthnicGroupComboBoxAdd";
            this.uxEthnicGroupComboBoxAdd.Size = new System.Drawing.Size(208, 29);
            this.uxEthnicGroupComboBoxAdd.TabIndex = 0;
            // 
            // uxEthnicGroupLabel
            // 
            this.uxEthnicGroupLabel.AutoSize = true;
            this.uxEthnicGroupLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 18F);
            this.uxEthnicGroupLabel.ForeColor = System.Drawing.Color.White;
            this.uxEthnicGroupLabel.Location = new System.Drawing.Point(11, 132);
            this.uxEthnicGroupLabel.Name = "uxEthnicGroupLabel";
            this.uxEthnicGroupLabel.Size = new System.Drawing.Size(163, 31);
            this.uxEthnicGroupLabel.TabIndex = 1;
            this.uxEthnicGroupLabel.Text = "Ethnic Group:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.uxOaHeLPIDLabel);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.uxEthnicGroupLabel);
            this.panel1.Controls.Add(this.uxEthnicGroupComboBoxAdd);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 542);
            this.panel1.TabIndex = 2;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(104)))), ((int)(((byte)(138)))));
            this.button6.Enabled = false;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(0, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(125, 34);
            this.button6.TabIndex = 20;
            this.button6.Text = "Add Subject";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // uxOaHeLPIDLabel
            // 
            this.uxOaHeLPIDLabel.AutoSize = true;
            this.uxOaHeLPIDLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 18F);
            this.uxOaHeLPIDLabel.ForeColor = System.Drawing.Color.White;
            this.uxOaHeLPIDLabel.Location = new System.Drawing.Point(11, 59);
            this.uxOaHeLPIDLabel.Name = "uxOaHeLPIDLabel";
            this.uxOaHeLPIDLabel.Size = new System.Drawing.Size(126, 31);
            this.uxOaHeLPIDLabel.TabIndex = 21;
            this.uxOaHeLPIDLabel.Text = "Project ID:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F);
            this.textBox1.Location = new System.Drawing.Point(143, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 29);
            this.textBox1.TabIndex = 22;
            // 
            // AddSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(104)))), ((int)(((byte)(112)))));
            this.ClientSize = new System.Drawing.Size(1028, 660);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "AddSubject";
            this.Text = "Add Subject";
            this.Load += new System.EventHandler(this.AddSubject_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox uxEthnicGroupComboBoxAdd;
        private System.Windows.Forms.Label uxEthnicGroupLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label uxOaHeLPIDLabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}