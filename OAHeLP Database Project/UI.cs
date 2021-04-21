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
using System.Threading;

namespace OAHeLP_Database_Project
{
    /// <summary>
    /// User Interface
    /// </summary>
    public partial class UI : Form
    {
        SqlConnection connection;
        /// <summary>
        /// The connection string.
        /// </summary>
        public static string connectionString; // might be a bad idea
        /// <summary>
        /// Connect to DB
        /// </summary>
        public UI()
        {
            //DisplaySplashScreen();
            connectionString = ConfigurationManager.ConnectionStrings["OAHeLP_Database_Project.Properties.Settings.Database1ConnectionString"].ConnectionString;
            InitializeComponent();
            PopulateTable();
        }

        /// <summary>
        /// Load Screen for 2 sec
        /// </summary>
        private void DisplaySplashScreen()
        {
            Thread thread = new Thread(new ThreadStart(StartScreen));
            thread.Start();
            Thread.Sleep(2000);
            thread.Abort();
            this.Show();
        }

        /// <summary>
        /// For Splash Screen
        /// </summary>
        public void StartScreen()
        {
            Application.Run(new SplashScreen());
        }

        /// <summary>
        /// Fill/Update table
        /// </summary>
        private void PopulateTable()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select FirstName from [Subject].[Name]", connection)) // select query goes here
            {
                var commandBuilder = new SqlCommandBuilder(adapter);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                
                string firstName, middleNames, lastName;
                firstName = "FirstName";
                middleNames = "MiddleNames";
                lastName = "LastName";
                Person person = new Person(firstName, middleNames, lastName);
                //uxNamesListBox.DisplayMember = person.ToString();
                // make a list of people, add people to list show in table
                
                uxNamesListBox.DataSource = dataTable;
                uxNamesListBox.DisplayMember = "FirstName";
            }
        }

        /// <summary>
        /// Add person to DB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddPersonButton_Click_1(object sender, EventArgs e)
        {
            if (uxNameLookupText.Text == string.Empty) return;

            DialogResult dialogResult = MessageBox.Show($"Add {uxNameLookupText.Text} to the database?", "Add Person", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                string query = "insert into [Subject].[Name] values (@PersonName, 'Middle', 'Last')";
                // Get Sex, Village and Ethnic Group

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("PersonName", uxNameLookupText.Text);

                    command.ExecuteNonQuery();
                }
                uxNameLookupText.Clear();
                PopulateTable();
                MessageBox.Show($"Added {uxNameLookupText.Text} to the database.");
            }
        }

        /// <summary>
        /// Search for person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSearchButton_Click_1(object sender, EventArgs e)
        {
            SearchAndSort search = new SearchAndSort();
        }
        /// <summary>
        /// Load Detailed View with information from query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNamesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedName = uxNamesListBox.GetItemText(uxNamesListBox.SelectedItem);
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"select S.OAHeLPID, N.FirstName, N.MiddleNames, N.LastName,S.Sex, EG.EthnicGroupName from[Subject].[Subject] S " +
                    $"inner join[Subject].SubjectName SN on S.SubjectID = SN.SubjectID " +
                    $"inner join[Subject].[Name] N on N.NameID = S.SubjectID " +
                    $"inner join[Subject].EthnicGroup EG on S.EthnicGroupID = EG.EthnicGroupID " +
                    $"where N.FirstName = '{selectedName}'";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // FIX THIS
                        var id = reader.GetString(0);
                        var fullName = reader.GetString(1) + reader.GetString(2) + reader.GetString(3);
                        var sex = reader.GetString(4);
                        var ethnicGroup = reader.GetString(5);
                        OpenChildForm(new DetailedView(id, fullName, sex, ethnicGroup));
                    }
                }
            }
        }

        /// <summary>
        /// Search for person based on Project ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void uxProjectIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var projectID = uxProjectIDTextBox.Text;
                if (projectID == "" || projectID == null) return;

                string query = $"select N.FirstName, S.OaHeLPID from[Subject].[Subject] S " +
                    "inner join[Subject].SubjectName SN on S.SubjectID = SN.SubjectID " +
                    "inner join[Subject].[Name] N on N.NameID = S.SubjectID " +
                    $"where S.OaHeLPID = '{projectID}'";

                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection)) // select query goes here
                {
                    var commandBuilder = new SqlCommandBuilder(adapter);
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    uxNamesListBox.DataSource = dataTable;
                }
                uxProjectIDTextBox.Clear();
            }
        }

        /// <summary>
        /// Show everyone in table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void everyoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateTable();
        }
        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateTable();
        }

        /// <summary>
        /// Pull up medical history for individual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMedicalHistoryButton_Click(object sender, EventArgs e)
        {
            var selectedName = uxNamesListBox.GetItemText(uxNamesListBox.SelectedItem);
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // FIX THIS
                        var id = reader.GetString(0);
                        MedicalHistory medicalHistory = new MedicalHistory(id);
                        medicalHistory.Show();
                    }
                }
            }


        }

        #region UI Stuff
        /// <summary>
        /// Opens a form and places it into the Panel
        /// </summary>
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            uxDetailedViewPanel.Controls.Add(childForm);
            uxDetailedViewPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        /// <summary>
        /// Clear Text on entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNameLookupText_Enter(object sender, EventArgs e) { uxNameLookupText.Clear(); }

        /// <summary>
        /// Reset text when leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNameLookupText_Leave(object sender, EventArgs e) { uxNameLookupText.Text = "Name"; }

        private void uxProjectIDTextBox_Enter(object sender, EventArgs e) { uxProjectIDTextBox.Clear(); uxProjectIDTextBox.ForeColor = Color.Black; }

        private void uxProjectIDTextBox_Leave(object sender, EventArgs e) { uxProjectIDTextBox.Text = "Project ID:"; uxProjectIDTextBox.ForeColor = Color.Silver; }
        private void uxICCardNumberTextBox_Enter(object sender, EventArgs e) { uxICCardNumberTextBox.Clear(); uxICCardNumberTextBox.ForeColor = Color.Black;  }
        private void uxICCardNumberTextBox_Leave(object sender, EventArgs e) { uxICCardNumberTextBox.Text = "IC Card Number:"; uxICCardNumberTextBox.ForeColor = Color.Silver; }
        #endregion
        /// <summary>
        /// Populate Table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void uxSearchProjectIDButton_Click(object sender, EventArgs e)
        {
            PopulateTable();
        }
    }
}
