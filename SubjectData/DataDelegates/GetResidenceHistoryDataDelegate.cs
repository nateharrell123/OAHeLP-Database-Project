using DataAccess;
using SubjectData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SubjectData.DataDelegates
{
    internal class GetResidenceHistoryDataDelegate : DataReaderDelegate<List<Residence>>
    {
        private readonly int subjectId;

        public GetResidenceHistoryDataDelegate(int subjectId) : base("Subject.GetResidenceHistory")
        {
            this.subjectId = subjectId;
        }

        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("SubjectId", SqlDbType.Int);
            p.Value = subjectId;
        }
        public override List<Residence> Translate(SqlCommand command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(subjectId.ToString());
            List<Residence> result = new List<Residence>();
            do
            {
                DateTime date = reader.GetDateTime("Date");
                string village = reader.GetNullableString("VillageName");
                if(village != null) result.Add(new Residence(date,village));
            }
            while (reader.Read());
            return result;
        }
    }
}
