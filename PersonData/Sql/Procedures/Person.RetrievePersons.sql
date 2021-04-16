CREATE OR ALTER PROCEDURE Person.RetrievePersons
AS

SELECT P.PersonId, P.FirstName, P.LastName, P.Email
FROM Person.Person P;
GO
