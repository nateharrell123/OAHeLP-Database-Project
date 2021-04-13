using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubjectData.Models;

namespace SubjectData
{
    public interface ISubjectRepository
    {
        //Subject CreateSubject(...)


        /// <summary>
        /// Gets the subject specified by the provided subjectId
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        Subject GetSubject(int subjectId);

        /// <summary>
        /// Gets the subject specified by the provided OAHeLP id string
        /// </summary>
        /// <param name="oaId"></param>
        /// <returns></returns>
        Subject GetOASubject(string oaId);
       
        /// <summary>
        /// Gets a list of subjects provided an ordered list of id numbers resulting from search
        /// </summary>
        /// <param name="subjectIds"></param>
        /// <returns></returns>
        List<Subject> GetSubjects(List<int> subjectIds);
    }
}
