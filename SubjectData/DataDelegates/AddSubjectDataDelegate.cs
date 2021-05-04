using DataAccess;
using SubjectData.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SubjectData.DataDelegates
{
    internal class AddSubjectDataDelegate : NonQueryDataDelegate<Subject>
    {
        public readonly string firstName;
        public readonly string middleNames;
        public readonly string lastName;
        public readonly string ethnicGroup;
        public readonly string village;
        public readonly char sex;

        public AddSubjectDataDelegate(string firstName, string middleNames, string lastName, string ethnicGroup, string village, char sex)
           : base("Subject.AddSubject")
        {
            this.firstName = firstName;
            this.middleNames = middleNames;
            this.lastName = lastName;
            this.ethnicGroup = ethnicGroup;
            this.village = village;
            this.sex = sex;
        }
        public override void PrepareCommand(SqlCommand command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("FirstName", SqlDbType.NVarChar);
            p.Value = firstName;

            p = command.Parameters.Add("MiddleNames", SqlDbType.NVarChar);
            p.Value = middleNames;

            p = command.Parameters.Add("LastName", SqlDbType.NVarChar);
            p.Value = lastName;

            p = command.Parameters.Add("EthnicGroupName", SqlDbType.NVarChar);
            p.Value = ethnicGroup;

            p = command.Parameters.Add("Sex", SqlDbType.Char);
            p.Value = sex;

            p = command.Parameters.Add("VillageName", SqlDbType.NVarChar);
            p.Value = village;

            p = command.Parameters.Add("SubjectId", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Subject Translate(SqlCommand command)
        {
            Subject result = new Subject((int)command.Parameters["SubjectId"].Value,
                (EthnicGroup)Enum.Parse(typeof(EthnicGroup), ethnicGroup),
                null, sex, null, null, null, null, null, null);
            Name n = new Name(firstName, middleNames, lastName);
            Residence r = new Residence(DateTime.Now, village);
            result.AddName(n);
            result.AddResidence(r);
            return result;
        }
    }
}
