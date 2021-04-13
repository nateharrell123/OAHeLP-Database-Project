using System.Collections.Generic;
using PersonData.Models;

namespace PersonData
{
   public interface IAddressRepository
   {
      IReadOnlyList<Address> RetrieveAdresses(int personId);

      void SaveAddress(int personId, AddressType addressType, string line1, string line2, string city, string stateCode, string zipCode);
   }
}
