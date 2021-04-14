using DataAccess;
using System.Data;
using System.Data.SqlClient;
using SubjectData.Models;
using System;

namespace SubjectData.DataDelegates
{
    internal class GetSubjectDataDelegate : DataReaderDelegate<Subject>
    {
        private readonly int subjectId;

        public GetSubjectDataDelegate(int subjectId)
           : base("Subject.GetSubject")
        {
            this.subjectId = subjectId;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("SubjectId", SqlDbType.Int);
            p.Value = subjectId;
        }

        public override Subject Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(subjectId.ToString());
            DOBSource source;
            if (reader.GetString("DOBSource") == "NULL") source = DOBSource.none;
            else source = (DOBSource)Enum.Parse(typeof(DOBSource), reader.GetString("DOBSource"));
            return new Subject(
                subjectId,
                (EthnicGroup)Enum.Parse(typeof(EthnicGroup), reader.GetString("EthnicGroup")),
                reader.GetString("OAHeLPID"),
                reader.GetString("Sex")[0],
                reader.GetNullableDateTime("DOB"),
                source,
                reader.GetNullableString("ICNumber"),
                reader.GetNullableInt32("MotherID"),
                reader.GetNullableInt32("FatherID"),
                reader.GetNullableString("PhotoFileName")

                );

            /*
            return new Subject(subjectId,
               (EthnicGroup)Enum.Parse(typeof(EthnicGroup), reader.GetString("EthnicGroup")),
               reader.GetString("OAHeLPID"),
               reader.GetString("Sex")[0]); //better way to do this??
            */
        }
    }
}
