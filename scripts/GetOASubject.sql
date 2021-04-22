--Gets a subject from the OAHeLP project ID 
CREATE OR ALTER PROCEDURE [Subject].GetOASubject
    @OAId NVARCHAR(6)
AS
SELECT SubjectID, OAHeLPID, DOB, Src.SourceName AS DOBSource, Sex, ICNumber, PhotoFileName, MotherID, FatherID, EG.Name AS EthnicGroup
FROM [Subject].[Subject] S 
    LEFT JOIN [Subject].DOBSource Src ON Src.SourceID = S.DOBSourceID
    LEFT JOIN [Subject].EthnicGroup EG ON S.EthnicGroupID = EG.EthnicGroupID
WHERE S.OAHeLPID = @OAId
GO
