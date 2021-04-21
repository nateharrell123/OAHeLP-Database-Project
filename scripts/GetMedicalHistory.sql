CREATE OR ALTER PROCEDURE [Subject].GetMedicalHistory
    @SubjectId INT
AS
SELECT V.Name AS Village, CV.[Date], Cn.Code AS Clinician, BodyTempDegC AS Temp, WeightKG AS Wt, PercentBodyFat AS BodyFat, 
    HeightCM AS Ht, WBCCount,
    IsPregnant, TobaccoUse, AlcoholUse
FROM Clinic.ClinicVisit CV
    INNER JOIN Clinic.Clinic C ON CV.ClinicID = C.ClinicID
    INNER JOIN Clinic.VillageSite VS ON C.SiteName = VS.SiteName
    INNER JOIN [Subject].Village V ON VS.VillageID = V.VillageID 
    INNER JOIN Clinic.Clinician Cn ON Cn.ClinicianID = CV.ClinicianID
WHERE CV.SubjectID = @SubjectId
ORDER BY CV.[Date] DESC