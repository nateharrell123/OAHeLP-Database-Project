--Provides a summary of data existing on a given village to include the number of subjects associated (through most recent residence)
--and number of clinics completed in each village
CREATE OR ALTER PROCEDURE [Subject].GetVillageSummary AS

WITH RecentResidenceCTE(SubjectID, RecentResDate, RecentVillageID) AS
(
    SELECT DISTINCT R.SubjectID,
    FIRST_VALUE(R.[Date]) OVER(PARTITION BY R.SubjectID ORDER BY R.Date DESC),
    FIRST_VALUE(R.VillageID) OVER(PARTITION BY R.SubjectID ORDER BY R.Date DESC)
FROM [Subject].[Residence] R
)

SELECT V.Name AS Village, COUNT(DISTINCT Recent.SubjectID) AS TotalSubjects, COUNT(DISTINCT C.ClinicID) AS ClinicsCompleted
FROM RecentResidenceCTE Recent 
    LEFT JOIN [Subject].[Village] V ON Recent.RecentVillageID = V.VillageID
    LEFT JOIN [Subject].[Subject] S ON Recent.SubjectID = S.SubjectID
    LEFT JOIN Clinic.VillageSite VS ON VS.VillageID = V.VillageID
    LEFT JOIN Clinic.Clinic C ON C.SiteName = VS.SiteName
GROUP BY V.VillageID, V.Name