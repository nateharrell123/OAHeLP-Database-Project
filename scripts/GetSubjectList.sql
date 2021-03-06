--Gets a list of subjects and their related information. Includes subjects with IDs in the table (Col: IDNumber) passed into the stored procedure


CREATE OR ALTER PROCEDURE [Subject].GetSubjectList
    @SubjectIds IdTableType READONLY
AS 

SELECT S.SubjectID, OAHeLPID, DOB, Src.SourceName AS DOBSource, Sex, ICNumber, PhotoFileName, MotherID, FatherID, EG.Name AS EthnicGroup, N.FirstName, N.MiddleNames, N.LastName, R.Date AS ResidenceDate, V.Name AS VillageName
FROM [Subject].[Subject] S 
    LEFT JOIN [Subject].DOBSource Src ON Src.SourceID = S.DOBSourceID
    LEFT JOIN [Subject].EthnicGroup EG ON S.EthnicGroupID = EG.EthnicGroupID
    INNER JOIN [Subject].SubjectName SN ON S.SubjectID = SN.SubjectID
    INNER JOIN [Subject].[Name] N ON SN.NameID = N.NameID
    LEFT JOIN [Subject].Residence R ON S.SubjectID = R.SubjectID
    LEFT JOIN [Subject].Village V ON V.VillageID = R.VillageID
WHERE S.SubjectID IN (
    SELECT IDNumber FROM @SubjectIds
)
GO

