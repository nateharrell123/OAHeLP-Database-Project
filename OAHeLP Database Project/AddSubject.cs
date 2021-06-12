using DataAccess;
using SubjectData;
using SubjectData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAHeLP_Database_Project
{
    /// <summary>
    /// Add a subject to the DB
    /// </summary>
    public partial class AddSubject : Form
    {
        ISubjectRepository repo;
        BindingList<Subject> list;

        public AddSubject(ISubjectRepository subjectRepo, BindingList<Subject> subjectList)
        {
            InitializeComponent();
            uxDOB.CustomFormat = "MMMM yyyy";
            repo = subjectRepo;
            list = subjectList;
        }

        /// <summary>
        /// Load Photo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenPhotoButton_Click(object sender, EventArgs e)
        {
            string imageLocation = string.Empty;
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    uxPictureBox.ImageLocation = imageLocation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add person to DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFinalizeAddButton_Click(object sender, EventArgs e)
        {
            string[] fullName = uxFirstNameTextBox.Text.Split(' ');
            var ethnicGroup = uxEthnicityComboBoxAdd.Text;
            char sex;

            if (uxSexMale.Checked) sex = 'M';
            else sex = 'F';
            if (fullName.Length > 3)
            {
                MessageBox.Show("Please enter up to three (3) names.");
                return;
            }
            var name = $"{uxFirstNameTextBox.Text}";
            if (AllFieldsEntered())
            {
                DialogResult dialogResult = MessageBox.Show($"Add {name} to the database?", "Add Person", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    DateTime timeAdded = DateTime.Now; // Tom said it would be useful to know when the record was submitted
                    // parse name
                    string firstName, middleNames, lastNames;
                    if (fullName.Length == 1)
                    {
                        firstName = fullName[0];
                        Subject subject = repo.AddSubject(firstName, "", "", ethnicGroup, "", sex); // needs an OAHeLP ID assigned on backend
                        list.Add(subject);
                    }
                    else if (fullName.Length == 2)
                    {
                        firstName = fullName[0];
                        middleNames = fullName[1];

                        Subject subject = repo.AddSubject(firstName, middleNames, "", ethnicGroup, "", sex);
                        list.Add(subject);
                    }
                    else if (fullName.Length == 3)
                    {
                        firstName = fullName[0];
                        middleNames = fullName[1];
                        lastNames = fullName[2];

                        Subject subject = repo.AddSubject(firstName, middleNames, lastNames, ethnicGroup, "", sex);
                        list.Add(subject);
                    }
                    MessageBox.Show($"{name} has been registered successfully.");
                }
                else return;
            }
        } // end func

        /// <summary>
        /// Assuming we want criteria for all fields entered
        /// </summary>
        /// <returns></returns>
        private bool AllFieldsEntered()
        {
            if (uxFirstNameTextBox.Text == "" || uxICCardNumberTextBoxAdd.Text == "")
            {
                MessageBox.Show("One of the required fields is missing.", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }
    } // end class
}
