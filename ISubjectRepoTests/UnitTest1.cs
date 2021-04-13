using System;
using System.Collections.Generic;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using SubjectData.Models;
using SubjectData;

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
        public void GetSubjectShouldWork()
        {
            var expected = new Subject(2, EthnicGroup.Jahai, "eyxbzz", 'F');
            var actual = repo.GetSubject(2);

            AssertSubjectsAreEqual(expected, actual);
        }


    /*
        [TestMethod]
        [ExpectedException(typeof(RecordNotFoundException))]
        public void FetchPersonWithNonExistingIdShouldThrowRecordNotFoundException()
        {
            repo.FetchPerson(0);
        }

        [TestMethod]
        public void FetchPersonShouldWork()
        {
            var expected = CreateTestPerson();
            var actual = repo.FetchPerson(expected.PersonId);

            AssertPersonsAreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPersonShouldWork()
        {
            var expected = CreateTestPerson();
            var actual = repo.GetPerson(expected.Email);

            AssertPersonsAreEqual(expected, actual);
        }

        [TestMethod]
        public void RetrievePersonsShouldWork()
        {
            var p1 = CreateTestPerson();
            var p2 = CreateTestPerson();
            var p3 = CreateTestPerson();

            var expected = new Dictionary<int, Person>
         {
            { p1.PersonId, p1 },
            { p2.PersonId, p2 },
            { p3.PersonId, p3 }
         };

            var actual = repo.RetrievePersons();

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count >= 3, "At least three are expected.");

            var matchCount = 0;

            foreach (var a in actual)
            {
                if (!expected.ContainsKey(a.PersonId))
                    continue;

                AssertPersonsAreEqual(expected[a.PersonId], a);

                matchCount += 1;
            }

            Assert.AreEqual(expected.Count, matchCount, "Not all expected persons were returned.");
        }

        private static void AssertPersonsAreEqual(Person expected, Person actual)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Email, actual.Email);
        }

        private Person CreateTestPerson()
        {
            return repo.CreatePerson(GetTestString(), GetTestString(), $"{GetTestString()}@test.com");
        }
    
    */

    private static void AssertSubjectsAreEqual(Subject expected, Subject actual)
    {
        Assert.IsNotNull(actual);
        Assert.AreEqual(expected.SubjectID, actual.SubjectID);
        Assert.AreEqual(expected.EthnicGroup, actual.EthnicGroup);
        Assert.AreEqual(expected.Sex, actual.Sex);
        //Assert.AreEqual(expected.Names, actual.Names);
        Assert.AreEqual(expected.MotherID, actual.MotherID);
        Assert.AreEqual(expected.FatherID, actual.FatherID);
        Assert.AreEqual(expected.photoFileName, actual.photoFileName);
        Assert.AreEqual(expected.ICNumber, actual.ICNumber);
    }
    }
}
