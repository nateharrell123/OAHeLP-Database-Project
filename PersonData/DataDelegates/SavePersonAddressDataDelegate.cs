using PersonData.Models;
using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace PersonData.DataDelegates
{
   internal class SavePersonAddressDataDelegate : DataDelegate
   {
      private readonly int personId;
      private readonly AddressType addressType;
      private readonly string line1;
      private readonly string line2;
      private readonly string city;
      private readonly string stateCode;
      private readonly string zipCode;

      public SavePersonAddressDataDelegate(int personId, AddressType addressType, string line1, string line2, string city, string stateCode, string zipCode)
         : base("Person.SavePersonAddress")
      {
         this.personId = personId;
         this.addressType = addressType;
         this.line1 = line1;
         this.line2 = line2;
         this.city = city;
         this.stateCode = stateCode;
         this.zipCode = zipCode;
      }

      public override void PrepareCommand(SqlCommand command)
      {
         base.PrepareCommand(command);

         command.Parameters.AddWithValue("PersonId", personId);
         command.Parameters.AddWithValue("AddressTypeId", addressType);
         command.Parameters.AddWithValue("Line1", line1);
         command.Parameters.AddWithValue("Line2", line2);
         command.Parameters.AddWithValue("City", city);
         command.Parameters.AddWithValue("StateCode", stateCode);
         command.Parameters.AddWithValue("ZipCode", zipCode);
      }
   }
}