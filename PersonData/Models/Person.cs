using System;

namespace PersonData.Models
{
   public class Person
   {
      public int PersonId { get; }
      public string FirstName { get; }
      public string LastName { get; }
      public string Email { get; }

      public Person(int personId, string firstName, string lastName, string email)
      {
         PersonId = personId;
         FirstName = firstName;
         LastName = lastName;
         Email = email;
      }
   }
}
