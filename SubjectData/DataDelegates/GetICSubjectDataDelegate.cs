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
    internal class GetICSubjectDataDelegate : DataReaderDelegate<Subject>
    {
        private readonly string icNumber;

        public GetICSubjectDataDelegate(string ic) : base("Subject.GetICSubject")
        {
            this.icNumber = ic;
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("ICNumber", SqlDbType.NVarChar);
            p.Value = icNumber;
        }
        public override Subject Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(icNumber);
            DOBSource source;
            if (reader.GetNullableString("DOBSource") == null) source = DOBSource.none;
            else source = (DOBSource)Enum.Parse(typeof(DOBSource), reader.GetString("DOBSource"));
            return new Subject(
                reader.GetInt32("SubjectID"),
                (EthnicGroup)Enum.Parse(typeof(EthnicGroup), reader.GetString("EthnicGroup")),
                reader.GetString("OAHeLPID"),
                reader.GetString("Sex")[0],
                reader.GetNullableDateTime("DOB"),
                source,
                icNumber,
                reader.GetNullableInt32("MotherID"),
                reader.GetNullableInt32("FatherID"),
                reader.GetNullableString("PhotoFileName")
                ); ;
        }
    }
}
