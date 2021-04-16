using DataAccess;
using PersonData.Models;
using System.Data;
using System.Data.SqlClient;

namespace PersonData.DataDelegates
{
   internal class FetchPersonDataDelegate : DataReaderDelegate<Person>
   {
      private readonly int personId;

      public FetchPersonDataDelegate(int personId)
         : base("Person.FetchPerson")
      {
         this.personId = personId;
      }

      public override void PrepareCommand(SqlCommand command)
      {
         base.PrepareCommand(command);

         var p = command.Parameters.Add("PersonId", SqlDbType.Int);
         p.Value = personId;
      }

      public override Person Translate(SqlCommand command, IDataRowReader reader)
      {
         if (!reader.Read())
            throw new RecordNotFoundException(personId.ToString());

         return new Person(personId,
            reader.GetString("FirstName"),
            reader.GetString("LastName"),
            reader.GetString("Email"));
      }
   }
}