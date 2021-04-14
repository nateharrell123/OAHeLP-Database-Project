CREATE OR ALTER PROCEDURE [Subject].GetSubject
    @SubjectId INT
AS

SELECT OAHeLPID, DOB, Sex, ICNumber, PhotoFileName, MotherID, FatherID, EG.Name AS EthnicGroup
FROM [Subject].[Subject] S 
    INNER JOIN [Subject].DOBSource Src ON Src.SourceID = S.DOBSourceID
    INNER JOIN [Subject].EthnicGroup EG ON S.EthnicGroupID = EG.EthnicGroupID
WHERE S.SubjectID = @SubjectId;
GO