
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
            this.uxDataGridView = new System.Windows.Forms.DataGridView();
            this.database1DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.table1TableAdapter = new OAHeLP_Database_Project.Database1DataSetTableAdapters.Table1TableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uxAddPerson = new System.Windows.Forms.Button();
            this.uxNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uxDataGridView
            // 
            this.uxDataGridView.AutoGenerateColumns = false;
            this.uxDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn});
            this.uxDataGridView.DataSource = this.table1BindingSource;
            this.uxDataGridView.Location = new System.Drawing.Point(12, 50);
            this.uxDataGridView.Name = "uxDataGridView";
            this.uxDataGridView.Size = new System.Drawing.Size(289, 140);
            this.uxDataGridView.TabIndex = 3;
            // 
            // database1DataSetBindingSource
            // 
            this.database1DataSetBindingSource.DataSource = this.database1DataSet;
            this.database1DataSetBindingSource.Position = 0;
            // 
            // table1BindingSource
            // 
            this.table1BindingSource.DataMember = "Table1";
            this.table1BindingSource.DataSource = this.database1DataSetBindingSource;
            // 
            // table1TableAdapter
            // 
            this.table1TableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            // 
            // uxAddPerson
            // 
            this.uxAddPerson.Location = new System.Drawing.Point(12, 222);
            this.uxAddPerson.Name = "uxAddPerson";
            this.uxAddPerson.Size = new System.Drawing.Size(102, 23);
            this.uxAddPerson.TabIndex = 4;
            this.uxAddPerson.Text = "Add:";
            this.uxAddPerson.UseVisualStyleBackColor = true;
            this.uxAddPerson.Click += new System.EventHandler(this.uxAddPerson_Click);
            // 
            // uxNameTextBox
            // 
            this.uxNameTextBox.Location = new System.Drawing.Point(12, 196);
            this.uxNameTextBox.Name = "uxNameTextBox";
            this.uxNameTextBox.Size = new System.Drawing.Size(102, 20);
            this.uxNameTextBox.TabIndex = 5;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 348);
            this.Controls.Add(this.uxNameTextBox);
            this.Controls.Add(this.uxAddPerson);
            this.Controls.Add(this.uxDataGridView);
            this.Name = "UI";
            this.Text = "OaHeLP ";
            this.Load += new System.EventHandler(this.UI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Database1DataSet database1DataSet;
        private System.Windows.Forms.DataGridView uxDataGridView;
        private System.Windows.Forms.BindingSource database1DataSetBindingSource;
        private System.Windows.Forms.BindingSource table1BindingSource;
        private Database1DataSetTableAdapters.Table1TableAdapter table1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button uxAddPerson;
        private System.Windows.Forms.TextBox uxNameTextBox;
    }
}

