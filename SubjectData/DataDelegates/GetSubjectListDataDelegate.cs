using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using SubjectData.Models;
using System.Data;

namespace SubjectData.DataDelegates
{
    internal class GetSubjectListDataDelegate : DataReaderDelegate<List<Subject>>
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
            DataColumn col = new DataColumn("ids", System.Type.GetType("System.Int32"));
            DataRow row;
            idTable.Columns.Add(col);
            
            foreach (int i in subjectIds){
                row = idTable.NewRow();
                row["ids"] = i;
                idTable.Rows.Add(row);
            }

            var p = command.Parameters.Add("SubjectIds", SqlDbType.Structured);
            p.Value = idTable;
       
        }
        public override List<Subject> Translate(SqlCommand command, IDataRowReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
