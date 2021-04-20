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

--GetNames procedure for retrieving the list of name(s) associated with a given subjectID
CREATE OR ALTER PROCEDURE [Subject].GetNames
    @SubjectId INT
AS
SELECT FirstName,MiddleNames,LastName,SubjectID
FROM [Subject].[Name] N
    LEFT JOIN [Subject].[SubjectName] SN ON N.NameID = SN.NameID
WHERE SubjectID = @SubjectId
GO 

--Gets a subject from the OAHeLP project ID 
CREATE OR ALTER PROCEDURE [Subject].GetOASubject
    @OAId NVARCHAR
AS
SELECT SubjectID, OAHeLPID, DOB, Src.SourceName AS DOBSource, Sex, ICNumber, PhotoFileName, MotherID, FatherID, EG.Name AS EthnicGroup
FROM [Subject].[Subject] S 
    LEFT JOIN [Subject].DOBSource Src ON Src.SourceID = S.DOBSourceID
    LEFT JOIN [Subject].EthnicGroup EG ON S.EthnicGroupID = EG.EthnicGroupID
WHERE S.OAHeLPID = @OAId
GO

--Gets a list of subjects and their related information. Includes subjects with IDs in the table (Col: IDNumber) passed into the stored procedure
IF TYPE_ID(N'MyType') IS NOT NULL CREATE TYPE IdTableType AS TABLE
(
        IDNumber int primary key
)
GO

CREATE OR ALTER PROCEDURE [Subject].GetSubjectList
    @SubjectIds IdTableType READONLY
AS 

SELECT S.SubjectID, OAHeLPID, DOB, Src.SourceName AS DOBSource, Sex, ICNumber, PhotoFileName, MotherID, FatherID, EG.Name AS EthnicGroup, N.FirstName, N.MiddleNames, N.LastName
FROM [Subject].[Subject] S 
    LEFT JOIN [Subject].DOBSource Src ON Src.SourceID = S.DOBSourceID
    LEFT JOIN [Subject].EthnicGroup EG ON S.EthnicGroupID = EG.EthnicGroupID
    INNER JOIN [Subject].SubjectName SN ON S.SubjectID = SN.SubjectID
    INNER JOIN [Subject].[Name] N ON SN.NameID = N.NameID
WHERE S.SubjectID IN (
    SELECT IDNumber FROM @SubjectIds
)
GO



