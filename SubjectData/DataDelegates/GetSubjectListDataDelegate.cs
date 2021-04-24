using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using SubjectData.Models;
using System.Data;
using System.ComponentModel;

namespace SubjectData.DataDelegates
{
    internal class GetSubjectListDataDelegate : DataReaderDelegate<BindingList<Subject>>
    {
        private readonly List<int> subjectIds;

        public GetSubjectListDataDelegate(List<int> ids):base("Subject.GetSubjectList")
        {
            this.subjectIds = ids;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            DataTable idTable = new DataTable("SubjectIds");
            DataColumn col = new DataColumn("IDNumber", System.Type.GetType("System.Int32"));
            DataRow row;
            idTable.Columns.Add(col);
            
            foreach (int i in subjectIds){
                row = idTable.NewRow();
                row["IDNumber"] = i;
                idTable.Rows.Add(row);
            }

            var p = command.Parameters.Add("SubjectIds", SqlDbType.Structured);
            p.Value = idTable; 
        }
        public override BindingList<Subject> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
            {
                throw new RecordNotFoundException(subjectIds.ToString());
            }
            BindingList<Subject> result = new BindingList<Subject>();
            do
            {
                DOBSource source;
                if (reader.GetNullableString("DOBSource") == null) source = DOBSource.none;
                else source = (DOBSource)Enum.Parse(typeof(DOBSource), reader.GetString("DOBSource"));
                Subject next = new Subject(
                    reader.GetInt32("SubjectID"),
                    (EthnicGroup)Enum.Parse(typeof(EthnicGroup), reader.GetString("EthnicGroup")),
                    reader.GetString("OAHeLPID"),
                    reader.GetString("Sex")[0], //there is a GetChar function to use instead of this
                    reader.GetNullableDateTime("DOB"),
                    source,
                    reader.GetNullableString("ICNumber"),
                    reader.GetNullableInt32("MotherID"),
                    reader.GetNullableInt32("FatherID"),
                    reader.GetNullableString("PhotoFileName")
                    );
                Name name = new Name(
                    reader.GetString("FirstName"),
                    reader.GetString("MiddleNames"),
                    reader.GetString("LastName"));
                Residence residence = null;
                if (!reader.IsNull("ResidenceDate") || !reader.IsNull("Villagename"))
                {
                    residence = new Residence(reader.GetDateTime("ResidenceDate"), reader.GetString("VillageName"));
                }
                if (result.Contains(next))
                {
                    result[result.IndexOf(next)].AddName(name);
                    result[result.IndexOf(next)].AddResidence(residence);
                }
                else
                {
                    next.AddName(name);
                    next.AddResidence(residence);
                    result.Add(next);
                }
            }
            while (reader.Read());
            return result;
        }
    }
}
