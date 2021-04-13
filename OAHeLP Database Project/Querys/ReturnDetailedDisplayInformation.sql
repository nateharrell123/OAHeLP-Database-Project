select S.OAHeLPID, N.FirstName, N.MiddleNames, N.LastName,S.Sex
from [Subject].[Subject] S
join [Subject].SubjectName SN on S.SubjectID = SN.SubjectID
join [Subject].[Name] N on N.NameID = S.SubjectID;