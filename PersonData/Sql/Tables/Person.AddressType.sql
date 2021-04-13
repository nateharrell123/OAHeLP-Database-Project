IF OBJECT_ID(N'Person.AddressType') IS NULL
BEGIN
   CREATE TABLE Person.AddressType
   (
      AddressTypeId TINYINT NOT NULL,
      [Name] VARCHAR(8) NOT NULL,

      CONSTRAINT PK_Person_AddressType_AddressTypeId PRIMARY KEY CLUSTERED
      (
         AddressTypeId ASC
      )
   );
END;

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'Person.AddressType')
         AND kc.[name] = N'UK_Person_AddressType_Name'
   )
BEGIN
   ALTER TABLE Person.AddressType
   ADD CONSTRAINT [UK_Person_AddressType_Name] UNIQUE NONCLUSTERED
   (
      [Name] ASC
   )
END;
