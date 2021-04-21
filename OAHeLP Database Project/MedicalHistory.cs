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
        public MedicalHistory(int subjectID)
        {
            InitializeComponent();
            using (SqlConnection connection = new SqlConnection(UI.connectionString))
            using (SqlCommand command = new SqlCommand("[Subject].[GetMedicalHistory]", connection))
            {
                connection.Open();

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("SubjectID", subjectID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                uxMedicalHistoryDataGridView.DataSource = dataSet.Tables[0];
            }
        }
    }
}
