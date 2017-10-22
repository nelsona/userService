using System.Linq;
using NUnit.Framework;
using Users.Implementation;
using Users.Interfaces;

namespace UsersTests
{
    [TestFixture]
    public class ValidationTests
    {
        private IValidation validator;
        
        [SetUp]
        protected void SetUp()
        {
            validator = new Validation();
        }

        [Test]
        public void EmailValid()
        {
            const string testEmail = "test@test.com";
            var expected = validator.IsEmailValid(testEmail);
            Assert.IsTrue(expected);
        }
        
        [Test]
        public void EmailInvalidDueToNoAt()
        {
            const string testEmail = "test";
            var expected = validator.IsEmailValid(testEmail);
            Assert.IsFalse(expected);
        }
        
        [Test]
        public void EmailInvalidDueToWrongFormat()
        {
            const string testEmail = "test@";
            var expected = validator.IsEmailValid(testEmail);
            Assert.IsFalse(expected);
        }
        
        [Test]
        public void PasswordValid()
        {
            const string password = "hereisapassword";
            var expected = validator.IsPassWordValid(password);
            Assert.IsTrue(expected.IsValid);
            Assert.IsEmpty(expected.Reasons);
        }
        
        [Test]
        public void PasswordInvalidAsEmpty()
        {
            const string password = "";
            var expected = validator.IsPassWordValid(password);
            Assert.IsFalse(expected.IsValid);
            Assert.IsNotEmpty(expected.Reasons);
            Assert.AreEqual("Password is empty.", expected.Reasons.First());
        }
        
        [Test]
        public void PasswordInvalidAsTooShort()
        {
            const string password = "password";
            var expected = validator.IsPassWordValid(password);
            Assert.IsFalse(expected.IsValid);
            Assert.IsNotEmpty(expected.Reasons);
            Assert.AreEqual("Password is too short.", expected.Reasons.First());
        }
    }
}