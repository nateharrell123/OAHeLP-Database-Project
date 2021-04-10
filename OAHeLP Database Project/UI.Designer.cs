
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
            this.database1DataSet = new OAHeLP_Database_Project.Database1DataSet();
            this.table1TableAdapter = new OAHeLP_Database_Project.Database1DataSetTableAdapters.Table1TableAdapter();
            this.uxAddPerson = new System.Windows.Forms.Button();
            this.uxNameTextBox = new System.Windows.Forms.TextBox();
            this.tableAdapterManager = new OAHeLP_Database_Project.Database1DataSetTableAdapters.TableAdapterManager();
            this.label1 = new System.Windows.Forms.Label();
            this.uxDataGridView = new System.Windows.Forms.DataGridView();
            this.database1DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uxMedicalHistoryButton = new System.Windows.Forms.Button();
            this.uxFeature1Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.database1DataSet1 = new OAHeLP_Database_Project.Database1DataSet();
            this.uxNameLookupText = new System.Windows.Forms.TextBox();
            this.uxDetailedViewPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // table1TableAdapter
            // 
            this.table1TableAdapter.ClearBeforeFill = true;
            // 
            // uxAddPerson
            // 
            this.uxAddPerson.Location = new System.Drawing.Point(300, 131);
            this.uxAddPerson.Name = "uxAddPerson";
            this.uxAddPerson.Size = new System.Drawing.Size(89, 20);
            this.uxAddPerson.TabIndex = 4;
            this.uxAddPerson.Text = "Add:";
            this.uxAddPerson.UseVisualStyleBackColor = true;
            this.uxAddPerson.Click += new System.EventHandler(this.uxAddPerson_Click);
            // 
            // uxNameTextBox
            // 
            this.uxNameTextBox.Location = new System.Drawing.Point(192, 131);
            this.uxNameTextBox.Name = "uxNameTextBox";
            this.uxNameTextBox.Size = new System.Drawing.Size(102, 20);
            this.uxNameTextBox.TabIndex = 5;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.Table1TableAdapter = null;
            this.tableAdapterManager.UpdateOrder = OAHeLP_Database_Project.Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "placeholder";
            // 
            // uxDataGridView
            // 
            this.uxDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.uxDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxDataGridView.Location = new System.Drawing.Point(12, 157);
            this.uxDataGridView.Name = "uxDataGridView";
            this.uxDataGridView.ReadOnly = true;
            this.uxDataGridView.Size = new System.Drawing.Size(406, 373);
            this.uxDataGridView.TabIndex = 6;
            this.uxDataGridView.SelectionChanged += new System.EventHandler(this.uxDataGridView_SelectionChanged);
            // 
            // database1DataSetBindingSource
            // 
            this.database1DataSetBindingSource.DataSource = this.database1DataSet;
            this.database1DataSetBindingSource.Position = 0;
            // 
            // uxMedicalHistoryButton
            // 
            this.uxMedicalHistoryButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.uxMedicalHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxMedicalHistoryButton.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.uxMedicalHistoryButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uxMedicalHistoryButton.Location = new System.Drawing.Point(12, 558);
            this.uxMedicalHistoryButton.Name = "uxMedicalHistoryButton";
            this.uxMedicalHistoryButton.Size = new System.Drawing.Size(194, 55);
            this.uxMedicalHistoryButton.TabIndex = 7;
            this.uxMedicalHistoryButton.Text = "Medical History";
            this.uxMedicalHistoryButton.UseVisualStyleBackColor = false;
            // 
            // uxFeature1Button
            // 
            this.uxFeature1Button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.uxFeature1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxFeature1Button.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.uxFeature1Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uxFeature1Button.Location = new System.Drawing.Point(224, 558);
            this.uxFeature1Button.Name = "uxFeature1Button";
            this.uxFeature1Button.Size = new System.Drawing.Size(194, 55);
            this.uxFeature1Button.TabIndex = 8;
            this.uxFeature1Button.Text = "Feature 1";
            this.uxFeature1Button.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(434, 558);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 55);
            this.button1.TabIndex = 9;
            this.button1.Text = "Feature 2";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(645, 558);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 55);
            this.button2.TabIndex = 10;
            this.button2.Text = "Feature 3";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // database1DataSet1
            // 
            this.database1DataSet1.DataSetName = "Database1DataSet";
            this.database1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uxNameLookupText
            // 
            this.uxNameLookupText.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.uxNameLookupText.Location = new System.Drawing.Point(434, 35);
            this.uxNameLookupText.Multiline = true;
            this.uxNameLookupText.Name = "uxNameLookupText";
            this.uxNameLookupText.Size = new System.Drawing.Size(178, 32);
            this.uxNameLookupText.TabIndex = 12;
            // 
            // uxDetailedViewPanel
            // 
            this.uxDetailedViewPanel.Location = new System.Drawing.Point(434, 157);
            this.uxDetailedViewPanel.Name = "uxDetailedViewPanel";
            this.uxDetailedViewPanel.Size = new System.Drawing.Size(405, 373);
            this.uxDetailedViewPanel.TabIndex = 13;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 625);
            this.Controls.Add(this.uxDetailedViewPanel);
            this.Controls.Add(this.uxNameLookupText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uxFeature1Button);
            this.Controls.Add(this.uxMedicalHistoryButton);
            this.Controls.Add(this.uxDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxNameTextBox);
            this.Controls.Add(this.uxAddPerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OaHeLP Database Tool";
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Database1DataSet database1DataSet;
        private Database1DataSetTableAdapters.Table1TableAdapter table1TableAdapter;
        private System.Windows.Forms.Button uxAddPerson;
        private System.Windows.Forms.TextBox uxNameTextBox;
        private Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView uxDataGridView;
        private System.Windows.Forms.Button uxMedicalHistoryButton;
        private System.Windows.Forms.Button uxFeature1Button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox uxNameLookup;
        private Database1DataSet database1DataSet1;
        private System.Windows.Forms.TextBox uxNameLookupText;
        private System.Windows.Forms.Panel uxDetailedViewPanel;
        private System.Windows.Forms.BindingSource database1DataSetBindingSource;
    }
}

