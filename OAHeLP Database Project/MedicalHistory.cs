using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OAHeLP_Database_Project
{
    public partial class MedicalHistory : Form
    {
        SqlConnection connection;
        public MedicalHistory(string selectedItem)
        {
            InitializeComponent();
            using (connection = new SqlConnection(UI.connectionString))
            {
                connection.Open();

                string query = 

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
            }
        }
    }
}
