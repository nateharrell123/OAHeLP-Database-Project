
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
            this.database1DataSet = new OAHeLP_Database_Project.Database1DataSet();
            this.table1TableAdapter = new OAHeLP_Database_Project.Database1DataSetTableAdapters.Table1TableAdapter();
            this.uxAddPerson = new System.Windows.Forms.Button();
            this.uxNameTextBox = new System.Windows.Forms.TextBox();
            this.tableAdapterManager = new OAHeLP_Database_Project.Database1DataSetTableAdapters.TableAdapterManager();
            this.label1 = new System.Windows.Forms.Label();
            this.uxDataGridView = new System.Windows.Forms.DataGridView();
            this.uxMedicalHistoryButton = new System.Windows.Forms.Button();
            this.uxFeature1Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridView)).BeginInit();
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
            this.uxAddPerson.Location = new System.Drawing.Point(609, 42);
            this.uxAddPerson.Name = "uxAddPerson";
            this.uxAddPerson.Size = new System.Drawing.Size(102, 23);
            this.uxAddPerson.TabIndex = 4;
            this.uxAddPerson.Text = "Add:";
            this.uxAddPerson.UseVisualStyleBackColor = true;
            this.uxAddPerson.Click += new System.EventHandler(this.uxAddPerson_Click);
            // 
            // uxNameTextBox
            // 
            this.uxNameTextBox.Location = new System.Drawing.Point(485, 42);
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
            this.label1.Location = new System.Drawing.Point(566, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "placeholder";
            // 
            // uxDataGridView
            // 
            this.uxDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxDataGridView.Location = new System.Drawing.Point(12, 42);
            this.uxDataGridView.Name = "uxDataGridView";
            this.uxDataGridView.Size = new System.Drawing.Size(435, 373);
            this.uxDataGridView.TabIndex = 6;
            // 
            // uxMedicalHistoryButton
            // 
            this.uxMedicalHistoryButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.uxMedicalHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxMedicalHistoryButton.Font = new System.Drawing.Font("Nachlieli CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.uxMedicalHistoryButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uxMedicalHistoryButton.Location = new System.Drawing.Point(12, 435);
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
            this.uxFeature1Button.Font = new System.Drawing.Font("Nachlieli CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.uxFeature1Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uxFeature1Button.Location = new System.Drawing.Point(224, 435);
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
            this.button1.Font = new System.Drawing.Font("Nachlieli CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(434, 435);
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
            this.button2.Font = new System.Drawing.Font("Nachlieli CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(645, 435);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 55);
            this.button2.TabIndex = 10;
            this.button2.Text = "Feature 3";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(850, 502);
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
            this.Text = "OaHeLP ";
            this.Load += new System.EventHandler(this.UI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridView)).EndInit();
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
    }
}

