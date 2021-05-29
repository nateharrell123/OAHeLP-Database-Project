
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
            this.uxProjectIDTextBoxAdd = new System.Windows.Forms.TextBox();
            this.uxOaHeLPIDLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.uxVillageLabelAdd = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.uxSexLabelAdd = new System.Windows.Forms.Label();
            this.uxSexComboBoxAdd = new System.Windows.Forms.ComboBox();
            this.uxEthnicityLabelAdd = new System.Windows.Forms.Label();
            this.uxEthnicityComboBoxAdd = new System.Windows.Forms.ComboBox();
            this.uxICCardNumberLabelAdd = new System.Windows.Forms.Label();
            this.uxICCardNumberTextBoxAdd = new System.Windows.Forms.TextBox();
            this.uxDOBLabelAdd = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
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
            this.uxEthnicGroupComboBoxAdd.Location = new System.Drawing.Point(171, 180);
            this.uxEthnicGroupComboBoxAdd.Name = "uxEthnicGroupComboBoxAdd";
            this.uxEthnicGroupComboBoxAdd.Size = new System.Drawing.Size(283, 29);
            this.uxEthnicGroupComboBoxAdd.TabIndex = 0;
            // 
            // uxEthnicGroupLabel
            // 
            this.uxEthnicGroupLabel.AutoSize = true;
            this.uxEthnicGroupLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 18F);
            this.uxEthnicGroupLabel.ForeColor = System.Drawing.Color.White;
            this.uxEthnicGroupLabel.Location = new System.Drawing.Point(2, 178);
            this.uxEthnicGroupLabel.Name = "uxEthnicGroupLabel";
            this.uxEthnicGroupLabel.Size = new System.Drawing.Size(163, 31);
            this.uxEthnicGroupLabel.TabIndex = 1;
            this.uxEthnicGroupLabel.Text = "Ethnic Group:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.uxDOBLabelAdd);
            this.panel1.Controls.Add(this.uxICCardNumberTextBoxAdd);
            this.panel1.Controls.Add(this.uxICCardNumberLabelAdd);
            this.panel1.Controls.Add(this.uxEthnicityComboBoxAdd);
            this.panel1.Controls.Add(this.uxEthnicityLabelAdd);
            this.panel1.Controls.Add(this.uxSexComboBoxAdd);
            this.panel1.Controls.Add(this.uxSexLabelAdd);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.uxVillageLabelAdd);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.uxProjectIDTextBoxAdd);
            this.panel1.Controls.Add(this.uxOaHeLPIDLabel);
            this.panel1.Controls.Add(this.uxEthnicGroupLabel);
            this.panel1.Controls.Add(this.uxEthnicGroupComboBoxAdd);
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 601);
            this.panel1.TabIndex = 2;
            // 
            // uxProjectIDTextBoxAdd
            // 
            this.uxProjectIDTextBoxAdd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F);
            this.uxProjectIDTextBoxAdd.Location = new System.Drawing.Point(134, 67);
            this.uxProjectIDTextBoxAdd.Name = "uxProjectIDTextBoxAdd";
            this.uxProjectIDTextBoxAdd.Size = new System.Drawing.Size(320, 29);
            this.uxProjectIDTextBoxAdd.TabIndex = 22;
            // 
            // uxOaHeLPIDLabel
            // 
            this.uxOaHeLPIDLabel.AutoSize = true;
            this.uxOaHeLPIDLabel.Font = new System.Drawing.Font("Microsoft YaHei Light", 18F);
            this.uxOaHeLPIDLabel.ForeColor = System.Drawing.Color.White;
            this.uxOaHeLPIDLabel.Location = new System.Drawing.Point(2, 62);
            this.uxOaHeLPIDLabel.Name = "uxOaHeLPIDLabel";
            this.uxOaHeLPIDLabel.Size = new System.Drawing.Size(126, 31);
            this.uxOaHeLPIDLabel.TabIndex = 21;
            this.uxOaHeLPIDLabel.Text = "Project ID:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.button4.ForeColor = System.Drawing.Color.CadetBlue;
            this.button4.Location = new System.Drawing.Point(-1, -1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(242, 34);
            this.button4.TabIndex = 26;
            this.button4.Text = "Add Subject:";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // uxVillageLabelAdd
            // 
            this.uxVillageLabelAdd.AutoSize = true;
            this.uxVillageLabelAdd.Font = new System.Drawing.Font("Microsoft YaHei Light", 18F);
            this.uxVillageLabelAdd.ForeColor = System.Drawing.Color.White;
            this.uxVillageLabelAdd.Location = new System.Drawing.Point(3, 234);
            this.uxVillageLabelAdd.Name = "uxVillageLabelAdd";
            this.uxVillageLabelAdd.Size = new System.Drawing.Size(92, 31);
            this.uxVillageLabelAdd.TabIndex = 27;
            this.uxVillageLabelAdd.Text = "Village:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Kuala Lumpur",
            "Klang",
            "Ipoh",
            "Butterworth",
            "George Town",
            "Petaling Jaya",
            "Kuantan",
            "Shah Alam",
            "Johor Bahru",
            "Kota Bharu",
            "Melaka",
            "Kota Kinabalu",
            "Seremban",
            "Sandakan"});
            this.comboBox1.Location = new System.Drawing.Point(134, 234);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(320, 29);
            this.comboBox1.TabIndex = 28;
            // 
            // uxSexLabelAdd
            // 
            this.uxSexLabelAdd.AutoSize = true;
            this.uxSexLabelAdd.Font = new System.Drawing.Font("Microsoft YaHei Light", 18F);
            this.uxSexLabelAdd.ForeColor = System.Drawing.Color.White;
            this.uxSexLabelAdd.Location = new System.Drawing.Point(3, 291);
            this.uxSexLabelAdd.Name = "uxSexLabelAdd";
            this.uxSexLabelAdd.Size = new System.Drawing.Size(57, 31);
            this.uxSexLabelAdd.TabIndex = 29;
            this.uxSexLabelAdd.Text = "Sex:";
            // 
            // uxSexComboBoxAdd
            // 
            this.uxSexComboBoxAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxSexComboBoxAdd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F);
            this.uxSexComboBoxAdd.FormattingEnabled = true;
            this.uxSexComboBoxAdd.Items.AddRange(new object[] {
            "M",
            "F"});
            this.uxSexComboBoxAdd.Location = new System.Drawing.Point(134, 291);
            this.uxSexComboBoxAdd.Name = "uxSexComboBoxAdd";
            this.uxSexComboBoxAdd.Size = new System.Drawing.Size(320, 29);
            this.uxSexComboBoxAdd.TabIndex = 30;
            // 
            // uxEthnicityLabelAdd
            // 
            this.uxEthnicityLabelAdd.AutoSize = true;
            this.uxEthnicityLabelAdd.Font = new System.Drawing.Font("Microsoft YaHei Light", 18F);
            this.uxEthnicityLabelAdd.ForeColor = System.Drawing.Color.White;
            this.uxEthnicityLabelAdd.Location = new System.Drawing.Point(2, 336);
            this.uxEthnicityLabelAdd.Name = "uxEthnicityLabelAdd";
            this.uxEthnicityLabelAdd.Size = new System.Drawing.Size(111, 31);
            this.uxEthnicityLabelAdd.TabIndex = 31;
            this.uxEthnicityLabelAdd.Text = "Ethnicity:";
            // 
            // uxEthnicityComboBoxAdd
            // 
            this.uxEthnicityComboBoxAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxEthnicityComboBoxAdd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F);
            this.uxEthnicityComboBoxAdd.FormattingEnabled = true;
            this.uxEthnicityComboBoxAdd.Items.AddRange(new object[] {
            "Ethnicities go here:"});
            this.uxEthnicityComboBoxAdd.Location = new System.Drawing.Point(134, 341);
            this.uxEthnicityComboBoxAdd.Name = "uxEthnicityComboBoxAdd";
            this.uxEthnicityComboBoxAdd.Size = new System.Drawing.Size(320, 29);
            this.uxEthnicityComboBoxAdd.TabIndex = 32;
            // 
            // uxICCardNumberLabelAdd
            // 
            this.uxICCardNumberLabelAdd.AutoSize = true;
            this.uxICCardNumberLabelAdd.Font = new System.Drawing.Font("Microsoft YaHei Light", 18F);
            this.uxICCardNumberLabelAdd.ForeColor = System.Drawing.Color.White;
            this.uxICCardNumberLabelAdd.Location = new System.Drawing.Point(3, 118);
            this.uxICCardNumberLabelAdd.Name = "uxICCardNumberLabelAdd";
            this.uxICCardNumberLabelAdd.Size = new System.Drawing.Size(199, 31);
            this.uxICCardNumberLabelAdd.TabIndex = 33;
            this.uxICCardNumberLabelAdd.Text = "IC Card Number:";
            // 
            // uxICCardNumberTextBoxAdd
            // 
            this.uxICCardNumberTextBoxAdd.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F);
            this.uxICCardNumberTextBoxAdd.Location = new System.Drawing.Point(208, 123);
            this.uxICCardNumberTextBoxAdd.Name = "uxICCardNumberTextBoxAdd";
            this.uxICCardNumberTextBoxAdd.Size = new System.Drawing.Size(246, 29);
            this.uxICCardNumberTextBoxAdd.TabIndex = 34;
            // 
            // uxDOBLabelAdd
            // 
            this.uxDOBLabelAdd.AutoSize = true;
            this.uxDOBLabelAdd.Font = new System.Drawing.Font("Microsoft YaHei Light", 18F);
            this.uxDOBLabelAdd.ForeColor = System.Drawing.Color.White;
            this.uxDOBLabelAdd.Location = new System.Drawing.Point(3, 389);
            this.uxDOBLabelAdd.Name = "uxDOBLabelAdd";
            this.uxDOBLabelAdd.Size = new System.Drawing.Size(157, 31);
            this.uxDOBLabelAdd.TabIndex = 35;
            this.uxDOBLabelAdd.Text = "Date of Birth:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F);
            this.dateTimePicker1.Location = new System.Drawing.Point(166, 389);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(288, 29);
            this.dateTimePicker1.TabIndex = 36;
            // 
            // AddSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
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
        private System.Windows.Forms.Label uxOaHeLPIDLabel;
        private System.Windows.Forms.TextBox uxProjectIDTextBoxAdd;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label uxVillageLabelAdd;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label uxSexLabelAdd;
        private System.Windows.Forms.ComboBox uxSexComboBoxAdd;
        private System.Windows.Forms.Label uxEthnicityLabelAdd;
        private System.Windows.Forms.ComboBox uxEthnicityComboBoxAdd;
        private System.Windows.Forms.Label uxICCardNumberLabelAdd;
        private System.Windows.Forms.TextBox uxICCardNumberTextBoxAdd;
        private System.Windows.Forms.Label uxDOBLabelAdd;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}