using DataAccess;
using PersonData.Models;
using System.Data.SqlClient;

namespace PersonData.DataDelegates
{
   internal class GetPersonDataDelegate : DataReaderDelegate<Person>
   {
      private readonly string email;

      public GetPersonDataDelegate(string email)
         : base("Person.GetPerson")
      {
         this.email = email;
      }

      public override void PrepareCommand(SqlCommand command)
      {
         base.PrepareCommand(command);

         command.Parameters.AddWithValue("Email", email);
      }

      public override Person Translate(SqlCommand command, IDataRowReader reader)
      {
         if (!reader.Read())
            return null;

         return new Person(
            reader.GetInt32("PersonId"),
            reader.GetString("FirstName"),
            reader.GetString("LastName"),
            email);
      }
   }
}