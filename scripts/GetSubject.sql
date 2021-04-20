--GetSubject procedure to retrieve information about a subject from a subjectID
CREATE OR ALTER PROCEDURE [Subject].GetSubject
    @SubjectId INT
AS

SELECT SubjectID, OAHeLPID, DOB, Src.SourceName AS DOBSource, Sex, ICNumber, PhotoFileName, MotherID, FatherID, EG.Name AS EthnicGroup
FROM [Subject].[Subject] S 
    LEFT JOIN [Subject].DOBSource Src ON Src.SourceID = S.DOBSourceID
    LEFT JOIN [Subject].EthnicGroup EG ON S.EthnicGroupID = EG.EthnicGroupID
WHERE S.SubjectID = @SubjectId;
GO