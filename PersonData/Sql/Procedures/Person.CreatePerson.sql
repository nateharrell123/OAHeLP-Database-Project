CREATE OR ALTER PROCEDURE Person.CreatePerson
   @FirstName NVARCHAR(32),
   @LastName NVARCHAR(32),
   @Email NVARCHAR(128),
   @PersonId INT OUTPUT
AS

INSERT Person.Person(FirstName, LastName, Email)
VALUES(@FirstName, @LastName, @Email);

SET @PersonId = SCOPE_IDENTITY();
GO
