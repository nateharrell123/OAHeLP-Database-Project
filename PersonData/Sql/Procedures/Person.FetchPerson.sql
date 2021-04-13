CREATE OR ALTER PROCEDURE Person.FetchPerson
   @PersonId INT
AS

SELECT P.FirstName, P.LastName, P.Email
FROM Person.Person P
WHERE P.PersonId = @PersonId;
GO
