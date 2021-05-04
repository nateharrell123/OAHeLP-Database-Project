CREATE OR ALTER PROCEDURE [Subject].AddSubject
    @FirstName NVARCHAR(15),
    @MiddleNames NVARCHAR(40),
    @LastName NVARCHAR(15),
    @EthnicGroupName NVARCHAR(15),
    @VillageName NVARCHAR(20),
    @Sex CHAR,
    @OAid NVARCHAR = N'000000',
    @SubjectId INT OUTPUT
AS
INSERT INTO [Subject].[Subject] (EthnicGroupID, OAHeLPID, Sex)
SELECT (
    SELECT EG.EthnicGroupID
    FROM [Subject].EthnicGroup EG 
    WHERE EG.Name = @EthnicGroupName
), @OAid, @Sex

SET @SubjectId = SCOPE_IDENTITY();

INSERT INTO [Subject].Residence (VillageID, [Date], SubjectID)
SELECT(
    SELECT V.VillageID
    FROM [Subject].[Village] V
    WHERE V.Name = @VillageName
),
GETUTCDATE(),
@SubjectId;


INSERT INTO [Subject].[Name] (FirstName, MiddleNames,LastName)
VALUES(@FirstName,@MiddleNames,@LastName);

DECLARE @NameId INT = SCOPE_IDENTITY();

INSERT INTO [Subject].[SubjectName]([SubjectID], NameID)
VALUES(@SubjectId,@NameId);