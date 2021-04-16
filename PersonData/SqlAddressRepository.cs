using System.Collections.Generic;
using DataAccess;
using PersonData.Models;
using PersonData.DataDelegates;
using System;

namespace PersonData
{
   public class SqlAddressRepository : IAddressRepository
   {
      private readonly SqlCommandExecutor executor;

      public SqlAddressRepository(string connectionString)
      {
         executor = new SqlCommandExecutor(connectionString);
      }

      public void SaveAddress(int personId, AddressType addressType, string line1, string line2, string city, string stateCode, string zipCode)
      {
         if (line1 == null)
            throw new ArgumentNullException(nameof(line1));

         if (city == null)
            throw new ArgumentNullException(nameof(city));

         if (stateCode == null)
            throw new ArgumentNullException(nameof(stateCode));

         if (stateCode.Length != 2)
            throw new ArgumentException("State code must be two characters.", nameof(stateCode));

         if (zipCode == null)
            throw new ArgumentNullException(nameof(zipCode));

         if (zipCode.Length != 5)
            throw new ArgumentException("Zip code must be five characters.", nameof(stateCode));

         var d = new SavePersonAddressDataDelegate(personId, addressType, line1, line2 ?? "", city, stateCode, zipCode);
         executor.ExecuteNonQuery(d);
      }

      public IReadOnlyList<Address> RetrieveAdresses(int personId)
      {
         var d = new RetrieveAddressesForPersonDataDelegate(personId);
         return executor.ExecuteReader(d);
      }
   }
}
