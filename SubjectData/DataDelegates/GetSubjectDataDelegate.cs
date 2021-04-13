using DataAccess;
using System.Data;
using System.Data.SqlClient;
using SubjectData.Models;

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

            return new Subject(subjectId,
               reader.GetValue<EthnicGroup>("EthnicGroup"),
               reader.GetString("OAHeLPID"),
               reader.GetString("Sex")[0]); //better way to do this??
        }
    }
}
