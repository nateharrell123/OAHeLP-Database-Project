using System.Collections.Generic;
using DataAccess;
using PersonData.Models;
using PersonData.DataDelegates;
using System;

namespace PersonData
{
   public class SqlPersonRepository : IPersonRepository
   {
      private readonly SqlCommandExecutor executor;

      public SqlPersonRepository(string connectionString)
      {
         executor = new SqlCommandExecutor(connectionString);
      }

      public Person CreatePerson(string firstName, string lastName, string email)
      {
         if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("The parameter cannot be null or empty.", nameof(firstName));

         if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("The parameter cannot be null or empty.", nameof(lastName));

         if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("The parameter cannot be null or empty.", nameof(email));

         var d = new CreatePersonDataDelegate(firstName, lastName, email);
         return executor.ExecuteNonQuery(d);
      }

      public Person FetchPerson(int personId)
      {
         var d = new FetchPersonDataDelegate(personId);
         return executor.ExecuteReader(d);
      }

      public Person GetPerson(string email)
      {
         var d = new GetPersonDataDelegate(email);
         return executor.ExecuteReader(d);
      }

      public IReadOnlyList<Person> RetrievePersons()
      {
         return executor.ExecuteReader(new RetrievePersonsDataDelegate());
      }
   }
}
