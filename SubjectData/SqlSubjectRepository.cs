using System;
using DataAccess;
using SubjectData.Models;
using SubjectData.DataDelegates;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace SubjectData
{
    public class SqlSubjectRepository : ISubjectRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlSubjectRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

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

        public Subject GetICSubject(string icNum)
        {
            var d = new GetICSubjectDataDelegate(icNum);
            Subject s = executor.ExecuteReader(d);
            s.SetNames(GetNames(s.SubjectID));
            return s;
        }

        public BindingList<Subject> GetSubjectList(List<int> subjectIds)
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


        public Subject AddSubject(string firstName, 
            string middleNames, 
            string lastName, 
            string ethnicGroup, 
            char sex)
        {
            var d = new AddSubjectDataDelegate(firstName, middleNames, lastName, ethnicGroup, sex);
            return executor.ExecuteReader(d);
        }
    }
}
