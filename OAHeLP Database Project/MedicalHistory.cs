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
            string query = "select * from[Clinic].ClinicVisit CV " +
                "inner join[Subject].[Subject] S on S.SubjectID = CV.SubjectID " +
                "inner join[Subject].[Name] N on N.NameID = S.SubjectID ";
                //$"where N.FirstName = {selectedItem}";
            using (SqlConnection connection = new SqlConnection(UI.connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                var commandBuilder = new SqlCommandBuilder(adapter);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                uxMedicalHistoryDataGridView.DataSource = dataSet.Tables[0];
            }
        }
    }
}
