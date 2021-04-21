using System;
using DataAccess;
using SubjectData.Models;
using SubjectData.DataDelegates;
using System.Collections.Generic;
using System.Data;


namespace SubjectData
{
    public class SqlSubjectRepository : ISubjectRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlSubjectRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }
        /*
        public Person FetchPerson(int personId)
        {
            var d = new FetchPersonDataDelegate(personId);
            return executor.ExecuteReader(d);
        }

        public Person GetPerson(string email)
        {
            var d = new GetPersonDataDelegate(email);
            return executor.ExecuteReader(d);
        }
        */

        public Subject GetSubject(int subjectId)
        {
            var d = new GetSubjectDataDelegate(subjectId);
            Subject s = executor.ExecuteReader(d);
            s.SetNames(GetNames(subjectId));
            return s;
        }

        public Subject GetOASubject(string oaId)
        {
            var d = new GetOASubjectDataDelegate(oaId);
            Subject s = executor.ExecuteReader(d);
            s.SetNames(GetNames(s.SubjectID));
            return s;
        }

        public List<Subject> GetSubjectList(List<int> subjectIds)
        {
            var d = new GetSubjectListDataDelegate(subjectIds);
            return executor.ExecuteReader(d);
        }

        public List<Name> GetNames(int subjectId)
        {
            var d = new GetNamesDataDelegate(subjectId);
            return executor.ExecuteReader(d);
        }

        public DataTable GetMedicalHistory(int subjectId)
        {
            var d = new GetMedicalHistoryDataDelegate(subjectId);
            return executor.ExecuteReader(d);
        }

        public bool DeleteSubject(int id)
        {
            var d = new DeleteSubjectDataDelegate(id);
            return executor.ExecuteReader(d);
        }
    }
}
