using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using SubjectData.Models;

namespace SubjectData.DataDelegates
{
    internal class GetOASubjectDataDelegate : DataReaderDelegate<Subject>
    {
        private readonly string oaId;

        public GetOASubjectDataDelegate(string oaId): base("Subject.GetOASubject")
        {
            this.oaId = oaId;
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("OAId", SqlDbType.NVarChar);
            p.Value = oaId;
        }
        public override Subject Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(oaId);
            DOBSource source;
            if (reader.GetString("DOBSource") == "NULL") source = DOBSource.none;
            else source = (DOBSource)Enum.Parse(typeof(DOBSource), reader.GetString("DOBSource"));
            return new Subject(
                reader.GetInt32("SubjectID"),
                (EthnicGroup)Enum.Parse(typeof(EthnicGroup), reader.GetString("EthnicGroup")),
                oaId,
                reader.GetString("Sex")[0],
                reader.GetNullableDateTime("DOB"),
                source,
                reader.GetNullableString("ICNumber"),
                reader.GetNullableInt32("MotherID"),
                reader.GetNullableInt32("FatherID"),
                reader.GetNullableString("PhotoFileName")
                );
        }
    }
}
