CREATE OR ALTER PROCEDURE [Subject].GetMedicalHistory
    @SubjectId INT
AS
DELETE FROM [Subject].[Subject]
WHERE SubjectID = @SubjectId;