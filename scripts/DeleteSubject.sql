CREATE OR ALTER PROCEDURE [Subject].DeleteSubject
    @SubjectId INT
AS
UPDATE [Subject].Marriage 
    SET SpouseID = NULL 
    WHERE SpouseID = @SubjectId;
UPDATE [Subject].[Subject]
    SET MotherID = NULL 
    WHERE MotherID = @SubjectId;
UPDATE [Subject].[Subject]
    SET FatherID = NULL
    WHERE FatherID = @SubjectId;
DELETE FROM [Subject].[Subject]
WHERE SubjectID = @SubjectId;