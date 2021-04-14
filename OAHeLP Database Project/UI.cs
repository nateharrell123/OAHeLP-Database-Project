﻿using System;
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
        string connectionString;
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
                
                uxNamesListBox.DataSource = dataTable;
                uxNamesListBox.DisplayMember = "FirstName";
            }
        }
        /// <summary>
        /// Search for person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSearchButton_Click(object sender, EventArgs e)
        {
            SearchAndSort search = new SearchAndSort();
        }

        /// <summary>
        /// Add person to DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddPersonButton_Click(object sender, EventArgs e)
        {
            if (uxNameLookupText.Text == string.Empty) return;

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
        }

        #region UI Stuff
        /// <summary>
        /// I think it's silly I have to do this
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSearchButton_MouseHover(object sender, EventArgs e) {uxSearchButton.ImageIndex = 1;}

        private void uxSearchButton_MouseLeave(object sender, EventArgs e) {uxSearchButton.ImageIndex = 0;}

        private void button3_MouseHover(object sender, EventArgs e) {uxAddPersonButton.ImageIndex = 1;}
        private void uxAddPersonButton_MouseLeave(object sender, EventArgs e) {uxAddPersonButton.ImageIndex = 0;}

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
        #endregion

        private void uxNamesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedName = uxNamesListBox.GetItemText(uxNamesListBox.SelectedItem);

                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"select S.OAHeLPID, N.FirstName, N.MiddleNames, N.LastName,S.Sex " +
                        "from[Subject].[Subject] S " +
                        "join[Subject].SubjectName SN on S.SubjectID = SN.SubjectID " +
                        "join[Subject].[Name] N on N.NameID = S.SubjectID" +
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
                            OpenChildForm(new DetailedView(id, fullName, sex));
                        }
                    }
                }
            }
            catch (Exception)
            {
                return; // this has to change
            }
           
        }
    }
}
