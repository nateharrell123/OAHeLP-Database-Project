﻿using DataAccess;
using SubjectData;
using SubjectData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient; // need this for SQL
using System.Drawing;
using System.Linq;
using System.Threading;
using SubjectData.Models;
using SubjectData;
using System.Windows.Forms;
using System.Configuration;

namespace OAHeLP_Database_Project
{
    /// <summary>
    /// User Interface
    /// </summary>
    public partial class UI : Form
    {
        SqlConnection connection;
        private ISubjectRepository repo;

        /// <summary>
        /// The connection string.
        /// </summary>
        public static string connectionString; // might be a bad idea
        BindingList<Subject> subjectList;
        DetailedView detailedView;

        /// <summary>
        /// Connect to DB
        /// </summary>
        public UI()
        {
            
            //DisplaySplashScreen();
            connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'C:\Users\Jack\source\repos\OAHeLP-Database-Project\OAHeLP Database Project\Database1.mdf'; Integrated Security = True";
            //connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=OAHELP;Integrated Security=SSPI;";
            //connectionString = ConfigurationManager.ConnectionStrings["OAHeLP_Database_Project.Properties.Settings.Database1ConnectionString"].ConnectionString;
            repo = new SqlSubjectRepository(connectionString);
            subjectList = new BindingList<Subject>();
            InitializeComponent();
            PopulateTable();
            uxNamesListBox.DataSource = subjectList;
            detailedView = new DetailedView(subjectList[uxNamesListBox.SelectedIndex]);
            OpenChildForm(detailedView);
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
            List<int> ids = new List<int>();
            for (int i = 0; i < 30; i++) ids.Add(i);
            subjectList = repo.GetSubjectList(ids);
            uxNamesListBox.DataSource = subjectList;
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
                /*
                 * CODE TO HOOK UP ADD SUJECT DATA DELEGATE
                 * Need to retrieve Name (with parsing), Village, Ethnic Group and Sex from drop downs
                 *Subject s = repo.AddSubject(firstName, middleNames, lastNames, ethnicGroup, sex);
                 *subjectList.Add(s);
                 *Might also need to refresh data binding? Not sure if it will do this automatically
                 */


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


            //create a rank property inside of subject and just manage all of this info using subject objects
            //then you can just clear out the datasource on the listbox and add them in ranked order

            subjectList = repo.GetSubjectList(subjectIDs);

            //we add each subject's rank to the object
            foreach(Subject s in subjectList)
            {
                int id = s.SubjectID;
                int rank = potentialMatchesIDsAndRanks[id];

                s.Rank = rank;

            }//foreach

            //now we need to sort these by rank
            BindingList<Subject> subjectListSorted = new BindingList<Subject>(subjectList.OrderByDescending(x => x.Rank).ToList());

            //settin up the new sorted list as the datasource
            subjectList = subjectListSorted;

            uxNamesListBox.DataSource = subjectList;
            uxNamesListBox.Refresh();
            

        }//SearchButtonClick



        /// <summary>
        /// Load Detailed View with information from query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNamesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (detailedView == null) detailedView = new DetailedView(subjectList[uxNamesListBox.SelectedIndex]);

                detailedView.UpdateSubject(subjectList[uxNamesListBox.SelectedIndex]);
                detailedView.UpdateView();

            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                //this exception is thrown between when list is cleared and repopulated
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
                if (projectID == "" || projectID == null) PopulateTable();
                else if (projectID.Length != 6) MessageBox.Show("Enter a valid project ID");
                else
                {
                    try
                    {
                        Subject result = repo.GetOASubject(projectID);
                        subjectList.Clear();
                        subjectList.Add(result);
                        uxNamesListBox.DataSource = subjectList;
                        detailedView.UpdateSubject(subjectList[uxNamesListBox.SelectedIndex]);
                        detailedView.UpdateView();
                    }
                    catch (RecordNotFoundException ex)
                    {
                        MessageBox.Show("No records found");
                    }
                }
            }
        }
        private void uxICCardNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var icNum = uxICCardNumberTextBox.Text;
                if (icNum == "" || icNum == null) PopulateTable();
                else if (icNum.Length != 12) MessageBox.Show("Enter a valid project ID"); //could also check and make sure they are all digits
                else
                {
                    icNum = 'n' + icNum;
                    try
                    {
                        Subject result = repo.GetICSubject(icNum);
                        subjectList.Clear();
                        subjectList.Add(result);
                        uxNamesListBox.DataSource = subjectList;
                        detailedView.UpdateSubject(subjectList[uxNamesListBox.SelectedIndex]);
                        detailedView.UpdateView();
                    }
                    catch (RecordNotFoundException ex)
                    {
                        MessageBox.Show("No records found");
                    }
                }
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
                        //MedicalHistory medicalHistory = new MedicalHistory(id);
                        //medicalHistory.Show();
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
        private void uxICCardNumberTextBox_Enter(object sender, EventArgs e) { uxICCardNumberTextBox.Clear(); uxICCardNumberTextBox.ForeColor = Color.Black; }
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

        private void uxDeleteButton_Click(object sender, EventArgs e)
        {
            int id = subjectList[uxNamesListBox.SelectedIndex].SubjectID;
            repo.DeleteSubject(id);
            subjectList.Remove(subjectList[uxNamesListBox.SelectedIndex]);
            if(subjectList.Count > 0)
            {
                detailedView.UpdateSubject(subjectList[uxNamesListBox.SelectedIndex]);
                detailedView.UpdateView();
            }

        }
    }
}
