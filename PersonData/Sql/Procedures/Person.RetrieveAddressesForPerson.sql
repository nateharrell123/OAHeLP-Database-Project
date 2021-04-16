CREATE OR ALTER PROCEDURE Person.RetrieveAddressesForPerson
   @PersonId INT
AS

SELECT PA.PersonId, PA.AddressTypeId, PA.Line1, PA.Line2,
   PA.City, PA.StateCode, PA.ZipCode
FROM Person.PersonAddress PA
WHERE PA.PersonId = @PersonId;
GO
