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
    }
}