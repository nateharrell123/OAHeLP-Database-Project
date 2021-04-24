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
    internal class GetMedicalHistoryDataDelegate : DataReaderDelegate<DataTable>
    {
        private readonly int subjectId;

        public GetMedicalHistoryDataDelegate(int id) : base("Subject.GetMedicalHistory")
        {
            this.subjectId = id;
        }
        public override DataTable Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
            {
                throw new RecordNotFoundException(subjectId.ToString());
            }
            DataTable result = new DataTable();
            //still need implementation code here...
            return result;

        }
    }
}
