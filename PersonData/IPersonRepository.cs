using System.Collections.Generic;
using PersonData.Models;

namespace PersonData
{
   public interface IPersonRepository
   {
      /// <summary>
      /// Retrieves all persons in the database.
      /// </summary>
      /// <returns>
      /// <see cref="IReadOnlyList{Person}"/> containing all persons.
      /// </returns>
      IReadOnlyList<Person> RetrievePersons();

      /// <summary>
      /// Fetches the person with the given <paramref name="personId"/> if it exists.
      /// </summary>
      /// <param name="personId">Identifier of the person to fetch.</param>
      /// <returns>
      /// An instance of <see cref="Person"/> containing the information of the requested person.
      /// </returns>
      /// <exception cref="DataAccess.RecordNotFoundException">
      /// Thrown if <paramref name="personId"/> does not exist.
      /// </exception>
      Person FetchPerson(int personId);

      /// <summary>
      /// Gets the person with the given <paramref name="personId"/> if it exists.
      /// </summary>
      /// <param name="email">Email of the person to get.</param>
      /// <returns>
      /// An instance of <see cref="Person"/> containing the information of the requested person
      /// if one exists with with the provided <paramref name="email"/>.
      /// If one is not found, <c>null</c> is returned.
      /// </returns>
      Person GetPerson(string email);

      /// <summary>
      /// Creates a new person in the repository.
      /// </summary>
      /// <param name="firstName">First name of the person to create.</param>
      /// <param name="lastName">Last name of the person to create.</param>
      /// <param name="email">Email of the person to create.</param>
      /// <returns>
      /// The resulting instance of <see cref="Person"/>.
      /// </returns>
      Person CreatePerson(string firstName, string lastName, string email);
   }
}
