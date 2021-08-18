using NUnit.Framework;
using SaintSender.Core.Services;
using System.Collections.Generic;

namespace SaintSender.Core.Tests
{
    [TestFixture]
    class InboxServiceTest
    {
        private List<MimeKit.MimeMessage> testMails;
        private InboxService testInboxService;

        [SetUp]
        public void SetUp()
        {
            this.testMails = new List<MimeKit.MimeMessage>();
            this.testInboxService = new InboxService();
        }

        [TestCase]
        public void GivenListIsEmpty_ThenReturnEmptyListOfMails()
        {
            List<Mail> result = this.testInboxService.CreateMails(this.testMails);
            Assert.IsEmpty(result);
        }

        [TestCase]
        public void GivenListHasOneElement_ThenReturnListCountIsOne()
        {
            this.testMails.Add(new MimeKit.MimeMessage());
            int result = this.testInboxService.CreateMails(this.testMails).Count;
            int excepted = 1;
            Assert.AreEqual(result, excepted);
        }
    }
}