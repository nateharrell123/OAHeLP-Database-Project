
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
            this.uxFeature1Button = new System.Windows.Forms.Button();
            this.uxMedicalHistoryButton = new System.Windows.Forms.Button();
            this.database1DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterManager = new OAHeLP_Database_Project.Database1DataSetTableAdapters.TableAdapterManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uxAddPersonButton = new System.Windows.Forms.Button();
            this.uxSearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uxPipeOne = new System.Windows.Forms.Label();
            this.uxProjectIDTextBox = new System.Windows.Forms.TextBox();
            this.uxICCardNumberTextBox = new System.Windows.Forms.TextBox();
            this.uxAddImageList = new System.Windows.Forms.ImageList(this.components);
            this.uxSearchImageList = new System.Windows.Forms.ImageList(this.components);
            this.uxNamesListBox = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.uxEthnicGroupComboBox.Location = new System.Drawing.Point(741, 27);
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
            "Male",
            "Female"});
            this.uxSexComboBox.Location = new System.Drawing.Point(741, 70);
            this.uxSexComboBox.Name = "uxSexComboBox";
            this.uxSexComboBox.Size = new System.Drawing.Size(171, 28);
            this.uxSexComboBox.TabIndex = 15;
            // 
            // uxVillageComboBox
            // 
            this.uxVillageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxVillageComboBox.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.uxVillageComboBox.FormattingEnabled = true;
            this.uxVillageComboBox.Location = new System.Drawing.Point(564, 71);
            this.uxVillageComboBox.Name = "uxVillageComboBox";
            this.uxVillageComboBox.Size = new System.Drawing.Size(171, 28);
            this.uxVillageComboBox.TabIndex = 15;
            // 
            // uxDetailedViewPanel
            // 
            this.uxDetailedViewPanel.Location = new System.Drawing.Point(499, 207);
            this.uxDetailedViewPanel.Name = "uxDetailedViewPanel";
            this.uxDetailedViewPanel.Size = new System.Drawing.Size(617, 404);
            this.uxDetailedViewPanel.TabIndex = 13;
            // 
            // uxNameLookupText
            // 
            this.uxNameLookupText.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.uxNameLookupText.ForeColor = System.Drawing.Color.Silver;
            this.uxNameLookupText.Location = new System.Drawing.Point(564, 27);
            this.uxNameLookupText.Multiline = true;
            this.uxNameLookupText.Name = "uxNameLookupText";
            this.uxNameLookupText.Size = new System.Drawing.Size(171, 28);
            this.uxNameLookupText.TabIndex = 12;
            this.uxNameLookupText.Text = "Name";
            this.uxNameLookupText.Enter += new System.EventHandler(this.uxNameLookupText_Enter);
            this.uxNameLookupText.Leave += new System.EventHandler(this.uxNameLookupText_Leave);
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
            this.button2.Location = new System.Drawing.Point(879, 635);
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
            this.button1.Location = new System.Drawing.Point(608, 635);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 55);
            this.button1.TabIndex = 9;
            this.button1.Text = "Feature 2";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // uxFeature1Button
            // 
            this.uxFeature1Button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.uxFeature1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxFeature1Button.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.uxFeature1Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uxFeature1Button.Location = new System.Drawing.Point(336, 635);
            this.uxFeature1Button.Name = "uxFeature1Button";
            this.uxFeature1Button.Size = new System.Drawing.Size(194, 55);
            this.uxFeature1Button.TabIndex = 8;
            this.uxFeature1Button.Text = "Feature 1";
            this.uxFeature1Button.UseVisualStyleBackColor = false;
            // 
            // uxMedicalHistoryButton
            // 
            this.uxMedicalHistoryButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.uxMedicalHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxMedicalHistoryButton.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.uxMedicalHistoryButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uxMedicalHistoryButton.Location = new System.Drawing.Point(32, 635);
            this.uxMedicalHistoryButton.Name = "uxMedicalHistoryButton";
            this.uxMedicalHistoryButton.Size = new System.Drawing.Size(194, 55);
            this.uxMedicalHistoryButton.TabIndex = 7;
            this.uxMedicalHistoryButton.Text = "Medical History";
            this.uxMedicalHistoryButton.UseVisualStyleBackColor = false;
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
            this.panel1.Controls.Add(this.uxAddPersonButton);
            this.panel1.Controls.Add(this.uxSearchButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.uxPipeOne);
            this.panel1.Controls.Add(this.uxEthnicGroupComboBox);
            this.panel1.Controls.Add(this.uxProjectIDTextBox);
            this.panel1.Controls.Add(this.uxICCardNumberTextBox);
            this.panel1.Controls.Add(this.uxNameLookupText);
            this.panel1.Controls.Add(this.uxSexComboBox);
            this.panel1.Controls.Add(this.uxVillageComboBox);
            this.panel1.Location = new System.Drawing.Point(12, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 126);
            this.panel1.TabIndex = 16;
            // 
            // uxAddPersonButton
            // 
            this.uxAddPersonButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uxAddPersonButton.BackgroundImage")));
            this.uxAddPersonButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uxAddPersonButton.Location = new System.Drawing.Point(1013, 28);
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
            this.uxSearchButton.Location = new System.Drawing.Point(928, 28);
            this.uxSearchButton.Name = "uxSearchButton";
            this.uxSearchButton.Size = new System.Drawing.Size(69, 71);
            this.uxSearchButton.TabIndex = 18;
            this.uxSearchButton.UseVisualStyleBackColor = true;
            this.uxSearchButton.Click += new System.EventHandler(this.uxSearchButton_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei Light", 40F);
            this.label1.Location = new System.Drawing.Point(224, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 70);
            this.label1.TabIndex = 18;
            this.label1.Text = "|";
            // 
            // uxPipeOne
            // 
            this.uxPipeOne.AutoSize = true;
            this.uxPipeOne.Font = new System.Drawing.Font("Microsoft YaHei Light", 40F);
            this.uxPipeOne.Location = new System.Drawing.Point(474, 19);
            this.uxPipeOne.Name = "uxPipeOne";
            this.uxPipeOne.Size = new System.Drawing.Size(43, 70);
            this.uxPipeOne.TabIndex = 18;
            this.uxPipeOne.Text = "|";
            // 
            // uxProjectIDTextBox
            // 
            this.uxProjectIDTextBox.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.uxProjectIDTextBox.ForeColor = System.Drawing.Color.Silver;
            this.uxProjectIDTextBox.Location = new System.Drawing.Point(35, 49);
            this.uxProjectIDTextBox.Multiline = true;
            this.uxProjectIDTextBox.Name = "uxProjectIDTextBox";
            this.uxProjectIDTextBox.Size = new System.Drawing.Size(171, 28);
            this.uxProjectIDTextBox.TabIndex = 12;
            this.uxProjectIDTextBox.Text = "Project ID:";
            this.uxProjectIDTextBox.Enter += new System.EventHandler(this.uxProjectIDTextBox_Enter);
            this.uxProjectIDTextBox.Leave += new System.EventHandler(this.uxProjectIDTextBox_Leave);
            // 
            // uxICCardNumberTextBox
            // 
            this.uxICCardNumberTextBox.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.uxICCardNumberTextBox.ForeColor = System.Drawing.Color.Silver;
            this.uxICCardNumberTextBox.Location = new System.Drawing.Point(278, 49);
            this.uxICCardNumberTextBox.Multiline = true;
            this.uxICCardNumberTextBox.Name = "uxICCardNumberTextBox";
            this.uxICCardNumberTextBox.Size = new System.Drawing.Size(171, 28);
            this.uxICCardNumberTextBox.TabIndex = 12;
            this.uxICCardNumberTextBox.Text = "IC Card Number:";
            this.uxICCardNumberTextBox.Enter += new System.EventHandler(this.uxICCardNumberTextBox_Enter);
            this.uxICCardNumberTextBox.Leave += new System.EventHandler(this.uxICCardNumberTextBox_Leave);
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
            this.uxNamesListBox.Location = new System.Drawing.Point(12, 207);
            this.uxNamesListBox.Name = "uxNamesListBox";
            this.uxNamesListBox.Size = new System.Drawing.Size(465, 404);
            this.uxNamesListBox.TabIndex = 17;
            this.uxNamesListBox.SelectedIndexChanged += new System.EventHandler(this.uxNamesListBox_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(19, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 34);
            this.button3.TabIndex = 19;
            this.button3.Text = "Subject Search";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(499, 173);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 34);
            this.button4.TabIndex = 20;
            this.button4.Text = "Details";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1128, 711);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.uxNamesListBox);
            this.Controls.Add(this.uxDetailedViewPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uxFeature1Button);
            this.Controls.Add(this.uxMedicalHistoryButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OaHeLP Database Tool";
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button uxFeature1Button;
        private System.Windows.Forms.Button uxMedicalHistoryButton;
        private System.Windows.Forms.BindingSource database1DataSetBindingSource;
        private Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList uxSearchImageList;
        private System.Windows.Forms.ImageList uxAddImageList;
        private System.Windows.Forms.ListBox uxNamesListBox;
        private System.Windows.Forms.Label uxPipeOne;
        private System.Windows.Forms.TextBox uxProjectIDTextBox;
        private System.Windows.Forms.TextBox uxICCardNumberTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uxSearchButton;
        private System.Windows.Forms.Button uxAddPersonButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

