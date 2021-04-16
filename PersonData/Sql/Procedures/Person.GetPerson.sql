CREATE OR ALTER PROCEDURE Person.GetPerson
   @Email NVARCHAR(128)
AS

SELECT P.PersonId, P.FirstName, P.LastName
FROM Person.Person P
WHERE P.Email = @Email;
GO
