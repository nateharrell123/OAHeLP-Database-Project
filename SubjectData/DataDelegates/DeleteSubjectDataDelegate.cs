using DataAccess;
using System.Data;
using System.Data.SqlClient;
using SubjectData.Models;
using System;

namespace SubjectData.DataDelegates
{
    internal class DeleteSubjectDataDelegate : DataReaderDelegate<bool>
    {
        private readonly int subjectId;

        public DeleteSubjectDataDelegate(int subjectId)
           : base("Subject.DeleteSubject")
        {
            this.subjectId = subjectId;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("SubjectId", SqlDbType.Int);
            p.Value = subjectId;
        }

        public override bool Translate(SqlCommand command, IDataRowReader reader)
        {
            return true;
        }
    }
}
