using System;
using DataAccess;
using SubjectData.Models;
using SubjectData.DataDelegates;
using System.Collections.Generic;


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
            throw new NotImplementedException();
        }

        public Subject GetOASubject(string oaId)
        {
            throw new NotImplementedException();
        }

        public List<Subject> GetSubjects(List<int> subjectIds)
        {
            throw new NotImplementedException();
        }
        
    }
}
