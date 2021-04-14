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


        /*

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
