using DataAccess;
using PersonData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PersonData.DataDelegates
{
   internal class RetrieveAddressesForPersonDataDelegate : DataReaderDelegate<IReadOnlyList<Address>>
   {
      private readonly int personId;

      public RetrieveAddressesForPersonDataDelegate(int personId)
         : base("Person.RetrieveAddressesForPerson")
      {
         this.personId = personId;
      }

      public override void PrepareCommand(SqlCommand command)
      {
         base.PrepareCommand(command);

         var p = command.Parameters.Add("PersonId", SqlDbType.Int);
         p.Value = personId;
      }
      public override IReadOnlyList<Address> Translate(SqlCommand command, IDataRowReader reader)
      {
         var addresses = new List<Address>();

         while (reader.Read())
         {
            addresses.Add(new Address(
               reader.GetInt32("PersonId"),
               (AddressType)reader.GetByte("AddressTypeId"),
               reader.GetString("Line1"),
               reader.GetString("Line2"),
               reader.GetString("City"),
               reader.GetString("StateCode"),
               reader.GetString("ZipCode")));
         }

         return addresses;
      }
   }
}