--GetNames procedure for retrieving the list of name(s) associated with a given subjectID
CREATE OR ALTER PROCEDURE [Subject].GetNames
    @SubjectId INT
AS
SELECT FirstName,MiddleNames,LastName,SubjectID
FROM [Subject].[Name] N
    LEFT JOIN [Subject].[SubjectName] SN ON N.NameID = SN.NameID
WHERE SubjectID = @SubjectId
GO 