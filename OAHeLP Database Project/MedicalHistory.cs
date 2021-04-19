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

                string query = $"select S.OAHeLPID, N.FirstName, N.MiddleNames, N.LastName,S.Sex,S.EthnicGroupID from[Subject].[Subject] S join[Subject].SubjectName SN on S.SubjectID = SN.SubjectID join[Subject].[Name] N on N.NameID = S.SubjectID where N.FirstName = '{selectedName}'";
                //string query = $"select S.OAHeLPID, N.FirstName, N.MiddleNames, N.LastName,S.Sex, EG.EthnicGroupName from[Subject].[Subject] S inner join[Subject].SubjectName SN on S.SubjectID = SN.SubjectID inner join[Subject].[Name] N on N.NameID = S.SubjectID inner join[Subject].EthnicGroup EG on S.EthnicGroupID = EG.EthnicGroupID";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
            }
        }
    }
}
