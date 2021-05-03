--Generates a summary of clinics completed including the date(s), location, and number of participating clinicians and completed visits
CREATE OR ALTER PROCEDURE Clinic.GetClinicsSummary
AS
SELECT C.DateStarted, C.DateCompleted, V.Name AS Village, COUNT(DISTINCT CV.ClinicianID) AS Clinicians, COUNT(CV.ClinicVisitID) AS PatientsSeen
FROM Clinic.ClinicVisit CV 
    INNER JOIN Clinic.Clinic C ON C.ClinicID = CV.ClinicID
    INNER JOIN Clinic.Clinician CN ON CV.ClinicianID = CN.ClinicianID
    LEFT JOIN Clinic.VillageSite VS ON C.SiteName = VS.SiteName
    LEFT JOIN [Subject].Village V ON VS.VillageID = V.VillageID
GROUP BY C.DateStarted, C.DateCompleted, V.Name