select * from [Clinic].ClinicVisit CV
inner join [Subject].[Subject] S on S.SubjectID = CV.SubjectID
inner join [Subject].[Name] N on N.NameID = S.SubjectID
where N.FirstName = 'nur' and S.SubjectID = CV.SubjectID
--inner join [Subject].[Name] N on N.NameID = SN.NameID