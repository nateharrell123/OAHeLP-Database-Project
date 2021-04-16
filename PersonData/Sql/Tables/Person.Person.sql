IF OBJECT_ID(N'Person.Person') IS NULL
BEGIN
   CREATE TABLE Person.Person
   (
      PersonId INT NOT NULL IDENTITY(1, 1),
      FirstName NVARCHAR(32) NOT NULL,
      LastName NVARCHAR(32) NOT NULL,
      Email NVARCHAR(128) NOT NULL,
      CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
      UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),

      CONSTRAINT [PK_Person_Person_PersonId] PRIMARY KEY CLUSTERED
      (
         PersonId ASC
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
      WHERE kc.parent_object_id = OBJECT_ID(N'Person.Person')
         AND kc.[name] = N'UK_Person_Person_Email'
   )
BEGIN
   ALTER TABLE Person.Person
   ADD CONSTRAINT [UK_Person_Person_Email] UNIQUE NONCLUSTERED
   (
      Email ASC
   )
END;

/****************************
 * Check Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.check_constraints cc
      WHERE cc.parent_object_id = OBJECT_ID(N'Person.Person')
         AND cc.[name] = N'CK_Person_Person_LastName_FirstName'
   )
BEGIN
   ALTER TABLE Person.Person
   ADD CONSTRAINT [CK_Person_Person_LastName_FirstName] CHECK
   (
      FirstName > N'' OR LastName > N''
   )
END;
