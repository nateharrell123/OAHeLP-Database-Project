CREATE OR ALTER PROCEDURE Person.SavePersonAddress
   @PersonId INT,
   @AddressTypeId TINYINT,
   @Line1 NVARCHAR(32),
   @Line2 NVARCHAR(32),
   @City NVARCHAR(64),
   @StateCode CHAR(2),
   @ZipCode CHAR(5)
AS

MERGE Person.PersonAddress T
USING
      (
         VALUES(@PersonId, @AddressTypeId, @Line1, @Line2, @City, @StateCode, @ZipCode)
      ) S(PersonId, AddressTypeId, Line1, Line2, City, StateCode, ZipCode)
   ON S.PersonId = T.PersonId
      AND S.AddressTypeId = T.AddressTypeId
WHEN MATCHED AND NOT EXISTS
      (
         SELECT S.Line1, S.Line2, S.City, S.StateCode, S.ZipCode
         INTERSECT
         SELECT  T.Line1, T.Line2, T.City, T.StateCode, T.ZipCode
      ) THEN
   UPDATE
   SET
      Line1 = S.Line1,
      Line2 = S.Line2,
      City = S.City,
      StateCode = S.StateCode,
      ZipCode = S.ZipCode,
      UpdatedOn = SYSDATETIMEOFFSET()
WHEN NOT MATCHED THEN
   INSERT(PersonId, AddressTypeId, Line1, Line2, City, StateCode, ZipCode)
   VALUES(S.PersonId, S.AddressTypeId, S.Line1, S.Line2, S.City, S.StateCode, S.ZipCode);
GO
