using DataAccess;
using SubjectData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SubjectData.DataDelegates
{
    internal class GetNamesDataDelegate : DataReaderDelegate<List<Name>>
    {
        private readonly int subjectId;

        public GetNamesDataDelegate(int subjectId): base("Subject.GetNames")
        {
            this.subjectId = subjectId;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("SubjectId", SqlDbType.Int);
            p.Value = subjectId;
        }
        public override List<Name> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(subjectId.ToString());
            List<Name> result = new List<Name>();
            do
            {
                string first = reader.GetString("FirstName");
                string middles = reader.GetString("MiddleNames");
                string last = reader.GetString("LastName");
                result.Add(new SubjectData.Models.Name(first, middles, last));
            }
            while (reader.Read());
            return result;
        }
    }
}
