using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient; // need this for SQL
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAHeLP_Database_Project
{
    /// <summary>
    /// User Interface
    /// </summary>
    public partial class UI : Form
    {
        SqlConnection connection;
        string connectionString;
        public UI()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["OAHeLP_Database_Project.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

        private void UI_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Table1' table. You can move, or remove it, as needed.
            this.table1TableAdapter.Fill(this.database1DataSet.Table1);
            PopulateTable();
        }

        private void PopulateTable()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Table1", connection))
            {
                var commandBuilder = new SqlCommandBuilder(adapter);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                uxDataGridView.DataSource = dataSet.Tables[0];
            }
        }

        /// <summary>
        /// Insert person into DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddPerson_Click(object sender, EventArgs e)
        {
            string query = "insert into Table1 values (@PersonName, 23)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("PersonName", uxNameTextBox.Text);
                command.ExecuteNonQuery();
            }

            PopulateTable();
        }
    }
}
