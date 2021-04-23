CREATE OR ALTER PROCEDURE [Subject].GetResidenceHistory
    @SubjectId INT
AS
SELECT [Date], V.Name AS VillageName
FROM [Subject].[Subject] S 
    LEFT JOIN [Subject].Residence R ON S.SubjectID = R.SubjectID
    LEFT JOIN [Subject].[Village] V ON V.VillageID = R.VillageID
WHERE S.SubjectID = @SubjectId
GO 