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
            else MessageBox.Show($"Cancelled adding {uxNameLookupText.Text} to the database.");


        }

        /// <summary>
        /// Search for person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSearchButton_Click_1(object sender, EventArgs e)
        {
            SearchAndSort search = new SearchAndSort();
            string inputName = uxNameLookupText.Text;
            string inputEthnicGroup = uxEthnicGroupComboBox.SelectedItem.ToString();
            //this doesn't work yet since the village combo box doesn't have anything in it
            //string inputVillageID = uxVillageComboBox.SelectedItem.ToString();
            string inputVillageID = "n684972815913";
            string inputSex = uxSexComboBox.SelectedItem.ToString();
            
            //find our potential matches to the input data with their respective ranks
            Dictionary<int, int> potentialMatchesIDsAndRanks = search.SearchDB(inputName,inputEthnicGroup,inputVillageID,inputSex);
            //just get the keys so that we can grab all of the names associated with these IDs
            List<int> subjectIDs = potentialMatchesIDsAndRanks.Keys.ToList<int>();

            //make a string of all of the IDs for the query
            string IDs = "";
            foreach(int i in subjectIDs)
            {
                IDs += ("'" + i.ToString() + "',");
            }//foreach

            IDs = IDs.Remove(IDs.Length - 1, 1);

            //dictionary for IDs and Names
            Dictionary<int, string> SubjectIDsAndNames = new Dictionary<int, string>();

            connectionString = ConfigurationManager.ConnectionStrings["OAHeLP_Database_Project.Properties.Settings.Database1ConnectionString"].ConnectionString;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //I DON'T KNOW WHY THIS QUERY DOESN'T WORK
                string query = 
                    "SELECT S.SubjectID," +
                    " FROM [Subject].[Subject] S" +
                    " LEFT JOIN" + 
                    " (" +
                            " SELECT N.FirstName" +
                            " FROM [Subject].[Subject] S" +
                            $"LEFT JOIN [Subject].[Name] N ON N.NameID = S.SubjectID " +
                        " )" +
                    " WHERE S.SubjectID" + 
                    " IN (" + IDs + ")";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                string firstName;
                string id;

                //add names to the dictionary with the id as the key
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        firstName = reader.GetString(1);
                        id = reader.GetString(0);
                        SubjectIDsAndNames[int.Parse(id)] = firstName;
                        
                    }//while
                }//if

                connection.Close();
            }//using

            //now this dictionary will associate the names and the ranks for display in the listbox
            Dictionary<string, int> SubjectNamesAndRanks = new Dictionary<string, int>();

            foreach(KeyValuePair<int,int> i in potentialMatchesIDsAndRanks)
            {
                int id = i.Key;
                int rank = i.Value;
                string name = SubjectIDsAndNames[id];

                SubjectNamesAndRanks[name] = rank;
            }//foreach

            //first we clear out the listbox
            uxNamesListBox.Items.Clear();

            //while the dict still has entries
            while(SubjectNamesAndRanks.Count > 0)
            {

                KeyValuePair<string, int> maxRank = SubjectNamesAndRanks.Max();
                string displayRankAndName = maxRank.Value + "   " + maxRank.Key;
                uxNamesListBox.Items.Add(displayRankAndName);

            }//while
            

        }//SearchButtonClick



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
            MedicalHistory medicalHistory = new MedicalHistory(selectedName);
            medicalHistory.Show();
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
