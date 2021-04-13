IF OBJECT_ID(N'Person.PersonAddress') IS NULL
BEGIN
   CREATE TABLE Person.PersonAddress
   (
      PersonAddressId INT NOT NULL IDENTITY(1, 1),
      PersonId INT NOT NULL,
      AddressTypeId TINYINT NOT NULL,
      Line1 NVARCHAR(32) NOT NULL,
      Line2 NVARCHAR(32) NULL,
      City NVARCHAR(64) NOT NULL,
      StateCode CHAR(2) NOT NULL,
      ZipCode CHAR(5) NOT NULL,
      CreatedOn DATETIMEOFFSET NOT NULL
         CONSTRAINT DF_Person_PersonAddress_CreatedOn DEFAULT(SYSDATETIMEOFFSET()),
      UpdatedOn DATETIMEOFFSET NOT NULL
         CONSTRAINT DF_Person_PersonAddress_UpdatedOn DEFAULT(SYSDATETIMEOFFSET()),

      CONSTRAINT [PK_Person_PersonAddress_PersonAddressId] PRIMARY KEY CLUSTERED
      (
         PersonAddressId ASC
      ),

      CONSTRAINT FK_Person_PersonAddress_Person_Person FOREIGN KEY(PersonId)
      REFERENCES Person.Person(PersonId),

      CONSTRAINT FK_Person_PersonAddress_Person_AddressType FOREIGN KEY(AddressTypeId)
      REFERENCES Person.AddressType(AddressTypeId)
   );
END

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'Person.PersonAddress')
         AND kc.[name] = N'UK_Person_PersonAddress_PersonId_AddressTypeId'
   )
BEGIN
   ALTER TABLE Person.PersonAddress
   ADD CONSTRAINT [UK_Person_PersonAddress_PersonId_AddressTypeId] UNIQUE NONCLUSTERED
   (
      PersonId,
      AddressTypeId
   )
END;

/****************************
 * Foreign Keys Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Person.PersonAddress')
         AND fk.referenced_object_id = OBJECT_ID(N'Person.Person')
         AND fk.[name] = N'FK_Person_PersonAddress_Person_Person'
   )
BEGIN
   ALTER TABLE Person.PersonAddress
   ADD CONSTRAINT [FK_Person_PersonAddress_Person_Person] FOREIGN KEY
   (
      PersonId
   )
   REFERENCES Person.Person
   (
      PersonId
   );
END;

IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Person.PersonAddress')
         AND fk.referenced_object_id = OBJECT_ID(N'Person.AddressType')
         AND fk.[name] = N'FK_Person_PersonAddress_Person_AddressType'
   )
BEGIN
   ALTER TABLE Person.PersonAddress
   ADD CONSTRAINT [FK_Person_PersonAddress_Person_AddressType] FOREIGN KEY
   (
      AddressTypeId
   )
   REFERENCES Person.AddressType
   (
      AddressTypeId
   );
END;
