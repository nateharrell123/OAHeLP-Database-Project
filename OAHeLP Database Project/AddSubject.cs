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
            var name = $"{uxFirstNameTextBox.Text} {uxMiddleNameTextBox.Text} {uxLastNameTextBox.Text}";
            if (AllFieldsEntered())
            {
                DialogResult dialogResult = MessageBox.Show($"Add {name} to the database?", "Add Person", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Subject subject = repo.AddSubject(uxFirstNameTextBox.Text, uxMiddleNameTextBox.Text, uxLastNameTextBox.Text, uxEthnicGroupComboBoxAdd.Text, uxVillageComboBox.Text, Convert.ToChar(uxSexComboBoxAdd.Text));
                    list.Add(subject);

                    MessageBox.Show($"{name} has been registered successfully.");
                }
                else if (dialogResult == DialogResult.No) return;
            }
        }

        /// <summary>
        /// Assuming we want criteria for all fields entered
        /// </summary>
        /// <returns></returns>
        private bool AllFieldsEntered()
        {
            if (uxFirstNameTextBox.Text == "" || uxMiddleNameTextBox.Text == "" || uxLastNameTextBox.Text == "" || string.IsNullOrEmpty(uxEthnicGroupComboBoxAdd.Text) || uxProjectIDTextBoxAdd.Text == "" || uxICCardNumberTextBoxAdd.Text == "")
            {
                MessageBox.Show("One of the required fields is missing.");
                return false;
            }
            else return true;
        }
    }
}
