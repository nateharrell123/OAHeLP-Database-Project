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
        public AddSubject()
        {
            InitializeComponent();
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
            DialogResult dialogResult = MessageBox.Show($"Add {uxFirstNameTextBoxAdd.Text} to the database?", "Add Person", MessageBoxButtons.YesNo);
        }

        private bool AllFieldsEntered()
        {
            return false;
        }
    }
}
