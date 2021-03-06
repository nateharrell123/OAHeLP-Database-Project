
namespace OAHeLP_Database_Project
{
    partial class UI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            this.uxEthnicGroupComboBox = new System.Windows.Forms.ComboBox();
            this.uxSexComboBox = new System.Windows.Forms.ComboBox();
            this.uxVillageComboBox = new System.Windows.Forms.ComboBox();
            this.uxDetailedViewPanel = new System.Windows.Forms.Panel();
            this.uxNameLookupText = new System.Windows.Forms.TextBox();
            this.database1DataSet1 = new OAHeLP_Database_Project.Database1DataSet();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.uxDeleteButton = new System.Windows.Forms.Button();
            this.uxMedicalHistoryButton = new System.Windows.Forms.Button();
            this.database1DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterManager = new OAHeLP_Database_Project.Database1DataSetTableAdapters.TableAdapterManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uxProjectIDTextBox = new System.Windows.Forms.TextBox();
            this.uxICCardNumberTextBox = new System.Windows.Forms.TextBox();
            this.uxSearchProjectIDButton = new System.Windows.Forms.Button();
            this.uxAddPersonButton = new System.Windows.Forms.Button();
            this.uxSearchButton = new System.Windows.Forms.Button();
            this.uxAddImageList = new System.Windows.Forms.ImageList(this.components);
            this.uxSearchImageList = new System.Windows.Forms.ImageList(this.components);
            this.uxNamesListBox = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.everyoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxEthnicGroupComboBox
            // 
            this.uxEthnicGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxEthnicGroupComboBox.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.uxEthnicGroupComboBox.ForeColor = System.Drawing.Color.Black;
            this.uxEthnicGroupComboBox.FormattingEnabled = true;
            this.uxEthnicGroupComboBox.Items.AddRange(new object[] {
            "Batek",
            "Jahai",
            "Jakun",
            "Lanoh",
            "Malay",
            "Mendriq",
            "Semai",
            "Temiar",
            "Temuan"});
            this.uxEthnicGroupComboBox.Location = new System.Drawing.Point(224, 39);
            this.uxEthnicGroupComboBox.Name = "uxEthnicGroupComboBox";
            this.uxEthnicGroupComboBox.Size = new System.Drawing.Size(171, 28);
            this.uxEthnicGroupComboBox.TabIndex = 15;
            // 
            // uxSexComboBox
            // 
            this.uxSexComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxSexComboBox.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.uxSexComboBox.FormattingEnabled = true;
            this.uxSexComboBox.Items.AddRange(new object[] {
            "M",
            "F"});
            this.uxSexComboBox.Location = new System.Drawing.Point(224, 82);
            this.uxSexComboBox.Name = "uxSexComboBox";
            this.uxSexComboBox.Size = new System.Drawing.Size(171, 28);
            this.uxSexComboBox.TabIndex = 15;
            // 
            // uxVillageComboBox
            // 
            this.uxVillageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxVillageComboBox.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.uxVillageComboBox.FormattingEnabled = true;
            this.uxVillageComboBox.Items.AddRange(new object[] {
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
            "Sandakan",
            "Sungai Petani",
            "Kuching",
            "Kuala Terengganu",
            "Alor Setar",
            "Putrajaya",
            "Kangar",
            "Labuan",
            "Pasir Mas",
            "Tumpat",
            "Ketereh",
            "Kampung Lemal",
            "Pulai Chondong"});
            this.uxVillageComboBox.Location = new System.Drawing.Point(47, 83);
            this.uxVillageComboBox.Name = "uxVillageComboBox";
            this.uxVillageComboBox.Size = new System.Drawing.Size(171, 28);
            this.uxVillageComboBox.TabIndex = 15;
            // 
            // uxDetailedViewPanel
            // 
            this.uxDetailedViewPanel.Location = new System.Drawing.Point(499, 211);
            this.uxDetailedViewPanel.Name = "uxDetailedViewPanel";
            this.uxDetailedViewPanel.Size = new System.Drawing.Size(617, 404);
            this.uxDetailedViewPanel.TabIndex = 13;
            // 
            // uxNameLookupText
            // 
            this.uxNameLookupText.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.uxNameLookupText.ForeColor = System.Drawing.Color.Black;
            this.uxNameLookupText.Location = new System.Drawing.Point(47, 39);
            this.uxNameLookupText.Multiline = true;
            this.uxNameLookupText.Name = "uxNameLookupText";
            this.uxNameLookupText.Size = new System.Drawing.Size(171, 28);
            this.uxNameLookupText.TabIndex = 12;
            this.uxNameLookupText.Text = "Name";
            // 
            // database1DataSet1
            // 
            this.database1DataSet1.DataSetName = "Database1DataSet";
            this.database1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(862, 639);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 55);
            this.button2.TabIndex = 10;
            this.button2.Text = "Feature 3";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(584, 639);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 55);
            this.button1.TabIndex = 9;
            this.button1.Text = "Feature 2";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // uxDeleteButton
            // 
            this.uxDeleteButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.uxDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxDeleteButton.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.uxDeleteButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uxDeleteButton.Location = new System.Drawing.Point(308, 639);
            this.uxDeleteButton.Name = "uxDeleteButton";
            this.uxDeleteButton.Size = new System.Drawing.Size(194, 55);
            this.uxDeleteButton.TabIndex = 8;
            this.uxDeleteButton.Text = "Remove Subject";
            this.uxDeleteButton.UseVisualStyleBackColor = false;
            this.uxDeleteButton.Click += new System.EventHandler(this.uxDeleteButton_Click);
            // 
            // uxMedicalHistoryButton
            // 
            this.uxMedicalHistoryButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.uxMedicalHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxMedicalHistoryButton.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.uxMedicalHistoryButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uxMedicalHistoryButton.Location = new System.Drawing.Point(32, 639);
            this.uxMedicalHistoryButton.Name = "uxMedicalHistoryButton";
            this.uxMedicalHistoryButton.Size = new System.Drawing.Size(194, 55);
            this.uxMedicalHistoryButton.TabIndex = 7;
            this.uxMedicalHistoryButton.Text = "Medical History";
            this.uxMedicalHistoryButton.UseVisualStyleBackColor = false;
            this.uxMedicalHistoryButton.Click += new System.EventHandler(this.uxMedicalHistoryButton_Click);
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.Table1TableAdapter = null;
            this.tableAdapterManager.UpdateOrder = OAHeLP_Database_Project.Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.uxProjectIDTextBox);
            this.panel1.Controls.Add(this.uxICCardNumberTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 134);
            this.panel1.TabIndex = 16;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(-1, -1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 34);
            this.button3.TabIndex = 19;
            this.button3.Text = "Subject Search";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei Light", 40F);
            this.label1.Location = new System.Drawing.Point(208, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 70);
            this.label1.TabIndex = 18;
            this.label1.Text = "|";
            // 
            // uxProjectIDTextBox
            // 
            this.uxProjectIDTextBox.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.uxProjectIDTextBox.ForeColor = System.Drawing.Color.Silver;
            this.uxProjectIDTextBox.Location = new System.Drawing.Point(19, 57);
            this.uxProjectIDTextBox.Name = "uxProjectIDTextBox";
            this.uxProjectIDTextBox.Size = new System.Drawing.Size(160, 27);
            this.uxProjectIDTextBox.TabIndex = 12;
            this.uxProjectIDTextBox.Text = "Project ID:";
            this.uxProjectIDTextBox.Enter += new System.EventHandler(this.uxProjectIDTextBox_Enter);
            this.uxProjectIDTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uxProjectIDTextBox_KeyPress);
            this.uxProjectIDTextBox.Leave += new System.EventHandler(this.uxProjectIDTextBox_Leave);
            // 
            // uxICCardNumberTextBox
            // 
            this.uxICCardNumberTextBox.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.uxICCardNumberTextBox.ForeColor = System.Drawing.Color.Silver;
            this.uxICCardNumberTextBox.Location = new System.Drawing.Point(269, 57);
            this.uxICCardNumberTextBox.Name = "uxICCardNumberTextBox";
            this.uxICCardNumberTextBox.Size = new System.Drawing.Size(171, 27);
            this.uxICCardNumberTextBox.TabIndex = 12;
            this.uxICCardNumberTextBox.Text = "IC Card Number:";
            this.uxICCardNumberTextBox.Enter += new System.EventHandler(this.uxICCardNumberTextBox_Enter);
            this.uxICCardNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uxICCardNumberTextBox_KeyPress);
            this.uxICCardNumberTextBox.Leave += new System.EventHandler(this.uxICCardNumberTextBox_Leave);
            // 
            // uxSearchProjectIDButton
            // 
            this.uxSearchProjectIDButton.BackColor = System.Drawing.Color.Gainsboro;
            this.uxSearchProjectIDButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uxSearchProjectIDButton.BackgroundImage")));
            this.uxSearchProjectIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uxSearchProjectIDButton.Location = new System.Drawing.Point(436, 177);
            this.uxSearchProjectIDButton.Name = "uxSearchProjectIDButton";
            this.uxSearchProjectIDButton.Size = new System.Drawing.Size(41, 34);
            this.uxSearchProjectIDButton.TabIndex = 22;
            this.uxSearchProjectIDButton.UseVisualStyleBackColor = false;
            this.uxSearchProjectIDButton.Click += new System.EventHandler(this.uxSearchProjectIDButton_Click);
            // 
            // uxAddPersonButton
            // 
            this.uxAddPersonButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uxAddPersonButton.BackgroundImage")));
            this.uxAddPersonButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uxAddPersonButton.Location = new System.Drawing.Point(504, 40);
            this.uxAddPersonButton.Name = "uxAddPersonButton";
            this.uxAddPersonButton.Size = new System.Drawing.Size(69, 71);
            this.uxAddPersonButton.TabIndex = 18;
            this.uxAddPersonButton.UseVisualStyleBackColor = true;
            this.uxAddPersonButton.Click += new System.EventHandler(this.uxAddPersonButton_Click_1);
            // 
            // uxSearchButton
            // 
            this.uxSearchButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uxSearchButton.BackgroundImage")));
            this.uxSearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uxSearchButton.Location = new System.Drawing.Point(413, 39);
            this.uxSearchButton.Name = "uxSearchButton";
            this.uxSearchButton.Size = new System.Drawing.Size(69, 71);
            this.uxSearchButton.TabIndex = 18;
            this.uxSearchButton.UseVisualStyleBackColor = true;
            this.uxSearchButton.Click += new System.EventHandler(this.uxSearchButton_Click_1);
            // 
            // uxAddImageList
            // 
            this.uxAddImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("uxAddImageList.ImageStream")));
            this.uxAddImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.uxAddImageList.Images.SetKeyName(0, "Plus.png");
            this.uxAddImageList.Images.SetKeyName(1, "Plus Highlight.png.png");
            // 
            // uxSearchImageList
            // 
            this.uxSearchImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("uxSearchImageList.ImageStream")));
            this.uxSearchImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.uxSearchImageList.Images.SetKeyName(0, "magnifying glass.jpg");
            this.uxSearchImageList.Images.SetKeyName(1, "magnifying glass highlight.jpg.png");
            // 
            // uxNamesListBox
            // 
            this.uxNamesListBox.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.uxNamesListBox.FormattingEnabled = true;
            this.uxNamesListBox.ItemHeight = 25;
            this.uxNamesListBox.Location = new System.Drawing.Point(12, 211);
            this.uxNamesListBox.Name = "uxNamesListBox";
            this.uxNamesListBox.Size = new System.Drawing.Size(465, 404);
            this.uxNamesListBox.TabIndex = 17;
            this.uxNamesListBox.SelectedIndexChanged += new System.EventHandler(this.uxNamesListBox_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Enabled = false;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.button5.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.button5.Location = new System.Drawing.Point(12, 177);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(465, 34);
            this.button5.TabIndex = 21;
            this.button5.Text = "Subjects";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.showToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1146, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.everyoneToolStripMenuItem});
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.showToolStripMenuItem.Text = "Show";
            // 
            // everyoneToolStripMenuItem
            // 
            this.everyoneToolStripMenuItem.Name = "everyoneToolStripMenuItem";
            this.everyoneToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.everyoneToolStripMenuItem.Text = "Everyone";
            this.everyoneToolStripMenuItem.Click += new System.EventHandler(this.everyoneToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.uxNameLookupText);
            this.panel3.Controls.Add(this.uxVillageComboBox);
            this.panel3.Controls.Add(this.uxSexComboBox);
            this.panel3.Controls.Add(this.uxAddPersonButton);
            this.panel3.Controls.Add(this.uxEthnicGroupComboBox);
            this.panel3.Controls.Add(this.uxSearchButton);
            this.panel3.Location = new System.Drawing.Point(499, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(617, 134);
            this.panel3.TabIndex = 24;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button6.Enabled = false;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(-1, -1);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(125, 34);
            this.button6.TabIndex = 19;
            this.button6.Text = "Lookup/Add";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.button4.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.button4.Location = new System.Drawing.Point(499, 176);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(617, 34);
            this.button4.TabIndex = 25;
            this.button4.Text = "Details";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1146, 712);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.uxSearchProjectIDButton);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.uxNamesListBox);
            this.Controls.Add(this.uxDetailedViewPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uxDeleteButton);
            this.Controls.Add(this.uxMedicalHistoryButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OaHeLP Database Tool";
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox uxNameLookup;
        private System.Windows.Forms.ComboBox uxEthnicGroupComboBox;
        private System.Windows.Forms.ComboBox uxSexComboBox;
        private System.Windows.Forms.ComboBox uxVillageComboBox;
        private System.Windows.Forms.Panel uxDetailedViewPanel;
        private System.Windows.Forms.TextBox uxNameLookupText;
        private Database1DataSet database1DataSet1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button uxDeleteButton;
        private System.Windows.Forms.Button uxMedicalHistoryButton;
        private System.Windows.Forms.BindingSource database1DataSetBindingSource;
        private Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList uxSearchImageList;
        private System.Windows.Forms.ImageList uxAddImageList;
        private System.Windows.Forms.ListBox uxNamesListBox;
        private System.Windows.Forms.TextBox uxProjectIDTextBox;
        private System.Windows.Forms.TextBox uxICCardNumberTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uxSearchButton;
        private System.Windows.Forms.Button uxAddPersonButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem everyoneToolStripMenuItem;
        private System.Windows.Forms.Button uxSearchProjectIDButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
    }
}

