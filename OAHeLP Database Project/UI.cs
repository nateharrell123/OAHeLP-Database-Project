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
        /// <summary>
        /// Connect to DB
        /// </summary>
        public UI()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["OAHeLP_Database_Project.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

        private void UI_Load(object sender, EventArgs e)
        {
            PopulateTable();
        }

        /// <summary>
        /// Fill/Update table
        /// </summary>
        private void PopulateTable()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Name", connection))
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
            if (uxNameTextBox.Text == string.Empty) return;

            string query = "insert into Name values (@PersonName, 'Middle', 'Last')";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("PersonName", uxNameTextBox.Text);
                command.ExecuteNonQuery();
            }

            PopulateTable();
            uxNameTextBox.Clear();
        }

        /// <summary>
        /// Iterates through column to find match
        /// </summary>
        /// <returns>true if duplicate is found, else false.</returns>
        private bool IsDuplicate()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "select FirstName from Name";

            return false;
        }
    }
}
