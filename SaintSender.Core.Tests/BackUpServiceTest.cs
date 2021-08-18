using NUnit.Framework;
using SaintSender.Core.Models;
using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Tests
{
    [TestFixture]
    class BackUpServiceTest
    {
        private BackupService testBackUpService;
        private User testUser;
        private List<Mail> testMails;

        [SetUp]
        public void SetUp()
        {
            this.testBackUpService = new BackupService();
            this.testUser = new User("test@gmail.com", "testPassword");
            this.testMails = new List<Mail>();
        }

        [TestCase]
        public void GivenMailsIsEmpty_ThenReturnTrue()
        {
            bool result = this.testBackUpService.SaveData(this.testUser, this.testMails);
            Assert.That(result, Is.True);
        }

        [TestCase]
        public void GivenMailsIsNotEmpty_ThenReturnTrue()
        {
            this.testMails.Add(new Mail("test", "test", "test"));
            bool result = this.testBackUpService.SaveData(this.testUser, this.testMails);
            Assert.That(result, Is.True);
        }

        [TestCase]
        public void GivenUsersMailsIsEmpty_ThenReturnEmptyMails()
        {
            this.testBackUpService.SaveData(this.testUser, this.testMails);

            List<Mail> result = this.testBackUpService
                                    .ReadMailsFromFile(this.testUser);

            Assert.IsEmpty(result);
        }

        [TestCase]
        public void GivenPasswordIsCorrect_ThenReturnFalse()
        {
            this.testBackUpService.SaveData(this.testUser, this.testMails);

            bool result = this.testBackUpService
                              .CheckForCorrectPassword(this.testUser.EmailAdress, this.testUser.Password);

            Assert.That(result, Is.True);
        }


        [TestCase]
        public void GivenPasswordIsNotCorrect_ThenReturnFalse()
        {
            this.testBackUpService.SaveData(this.testUser, this.testMails);

            bool result = this.testBackUpService
                              .CheckForCorrectPassword(this.testUser.EmailAdress, "wrong password");

            Assert.That(result, Is.False);
        }

        [TestCase]
        public void GivenUserHasNotBackUp_ThenReturnFalse()
        {
            bool result = this.testBackUpService
                              .CheckIfUserSaved(this.testUser.EmailAdress);

            Assert.That(result, Is.False);
        }

        [TestCase]
        public void GivenUserHasBackUp_ThenReturnTrue()
        {
            this.testBackUpService.SaveData(this.testUser, this.testMails);

            bool result = this.testBackUpService
                              .CheckIfUserSaved(this.testUser.EmailAdress);

            Assert.That(result, Is.True);
        }

        [TearDown]
        public void TestCleanUp()
        {
            File.Delete($"{this.testUser.EmailAdress}.xml");
        }
    }
}
