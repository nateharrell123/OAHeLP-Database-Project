using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubjectData;
using SubjectData.Models;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace ISubjectRepoTests
{
    [TestClass]
    public class SqlSubjectRepositoryTest
    {
        const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=OAHELP;Integrated Security=SSPI;";

        private ISubjectRepository repo;
        private TransactionScope transaction;

        [TestInitialize]
        public void InitializeTest()
        {
            repo = new SqlSubjectRepository(connectionString);

            transaction = new TransactionScope();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void SubjectWithNullValuesShouldWork()
        {
            var test = new Subject(
                2,
                EthnicGroup.Jahai,
                "eyxbzz",
                'F',
                null,
                null,
                null,
                null,
                null,
                null
                );

            Assert.AreEqual(null, test.DOB);
            Assert.AreEqual(null, test.DOBSource);
            Assert.AreEqual(null, test.ICNumber);
            Assert.AreEqual(null, test.MotherID);
            Assert.AreEqual(null, test.FatherID);
            Assert.IsNotNull(test);
        }
        [TestMethod]
        public void GetSubjectWithNullValuesShouldWork()
        {
            var expected = new Subject(31, EthnicGroup.Semai, "jpb1r6", 'M', (new DateTime(2000, 11, 5)), DOBSource.known, "n555388832027", null, 44, null);
            expected.SetNames(repo.GetNames(31));
            var actual = repo.GetSubject(31);

            AssertSubjectsAreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(RecordNotFoundException))]
        public void FetchPersonWithNonExistingIdShouldThrowRecordNotFoundException()
        {
            repo.GetSubject(0);
        }

        [TestMethod]
        public void GetNamesShouldWork()
        {
            Name n1 = new Name("mohd", "noor azmi bin", "ahmad");
            Name n2 = new Name("ey celangeh", "", "");
            List<Name> actual = repo.GetNames(12);
            Assert.IsTrue(actual.Contains(n1));
            Assert.IsTrue(actual.Contains(n2));
        }
        [TestMethod]
        public void GetSubjectListShouldWork()
        {
            List<int> ids = new List<int>();
            ids.Add(3);
            ids.Add(12);
            ids.Add(40);
            ids.Add(74);
            List<Subject> actual = repo.GetSubjectList(ids);
            Assert.IsTrue(actual.Count == 4);
        }
        /*
        [TestMethod]
        public void BindingNamesToSubjectShouldWork()
        {
            Subject test = repo.GetSubject(40);
            List<Name> names = repo.GetNames(40);
            test.SetNames(names);

            foreach(Name n in names)
            {
                Assert.IsTrue(test.Names.Contains(n));
            }
        }
        */

        private static void AssertSubjectsAreEqual(Subject expected, Subject actual)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.SubjectID, actual.SubjectID);
            Assert.AreEqual(expected.EthnicGroup, actual.EthnicGroup);
            Assert.AreEqual(expected.Sex, actual.Sex);
            CollectionAssert.AreEquivalent(expected.Names, actual.Names);
            Assert.AreEqual(expected.MotherID, actual.MotherID);
            Assert.AreEqual(expected.FatherID, actual.FatherID);
            Assert.AreEqual(expected.photoFileName, actual.photoFileName);
            Assert.AreEqual(expected.ICNumber, actual.ICNumber);
        }
    }
}
