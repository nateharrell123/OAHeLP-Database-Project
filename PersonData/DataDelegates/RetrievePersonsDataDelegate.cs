using DataAccess;
using PersonData.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PersonData.DataDelegates
{
   internal class RetrievePersonsDataDelegate : DataReaderDelegate<IReadOnlyList<Person>>
   {
      public RetrievePersonsDataDelegate()
         : base("Person.RetrievePersons")
      {
      }

      public override IReadOnlyList<Person> Translate(SqlCommand command, IDataRowReader reader)
      {
         var persons = new List<Person>();

         while (reader.Read())
         {
            persons.Add(new Person(
               reader.GetInt32("PersonId"),
               reader.GetString("FirstName"),
               reader.GetString("LastName"),
               reader.GetString("Email")));
         }

         return persons;
      }
   }
}