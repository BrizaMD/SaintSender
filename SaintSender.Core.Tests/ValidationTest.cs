using NUnit.Framework;
using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Tests
{
    [TestFixture]
    class ValidationTest
    {
        private Validation testValidation;

        [SetUp]
        public void SetUP()
        {
            this.testValidation = new Validation();
        }

        [TestCase]
        public void GivenMailIsNotValid_ThenReturnFalse()
        {
            bool result = this.testValidation.ValidateEmail("test");
            Assert.That(result, Is.False);
        }

        [TestCase]
        public void GivenMailIsCorrect_ThenReturnTrue()
        {
            bool result = this.testValidation.ValidateEmail("unclebob@gmail.com");
            Assert.That(result, Is.True);
        }

        [TestCase]
        public void GivenPasswordIsTooShort_ThenReturnFalse()
        {
            bool result = this.testValidation.ValidatePassword("test");
            Assert.That(result, Is.False);
        }


        [TestCase]
        public void GivenPasswordCorrect_ThenReturnTrue()
        {
            bool result = this.testValidation.ValidatePassword("unclebob");
            Assert.That(result, Is.True);
        }
    }
}
