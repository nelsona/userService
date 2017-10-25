using System;
using System.Runtime;
using Moq;
using NUnit.Framework;
using Users;
using Users.Implementation;
using Users.Interfaces;

namespace UsersTests
{
    [TestFixture]
    public class Tests
    {
        private IUsers users;
        
        [SetUp]
        protected void SetUp()
        {
            var validation = new Validation();
            var repository = new Mock<IUserRepository>();

            var mockUser = new User {Email = "test@test.com", Password = "testpassword"};
            
            repository.Setup(e => e.Add(It.IsAny<string>(), It.IsAny<string>())).Returns(1);
            repository.Setup(e => e.Find(It.IsAny<string>(), It.IsAny<string>())).Returns(mockUser);
            repository.Setup(e => e.Find("test", "passwordtest")).Returns((User) null);
            repository.Setup(e => e.Find("test@test.com", "passwordTest")).Returns(mockUser);
            users = new Users.Users(validation, repository.Object);
        }
        
        [Test]
        public void RegisterAValidUser()
        {
            var user = users.Register("test@test.com", "passwordtest");
            Assert.IsTrue(user.IsValid);
            Assert.IsTrue(user.UserName == "test@test.com");
            Assert.IsNull(user.Errors);
        }
        
        [Test]
        public void RegisterAnInValidUser()
        {
            var user = users.Register("test", "passwordtest");
            Assert.IsFalse(user.IsValid);
            Assert.IsTrue(user.UserName == null);
            Assert.IsNotEmpty(user.Errors);
        }
        
        [Test]
        public void RegisterAnInValidUserPasword()
        {
            var user = users.Register("test@test.coms", "pass");
            Assert.IsFalse(user.IsValid);
            Assert.IsTrue(user.UserName == null);
            Assert.IsNotEmpty(user.Errors);
        }
        
        [Test]
        public void LoginAValidUser()
        {
            var user = users.Login("test@test.com", "passwordtest");
            Assert.IsTrue(user.IsValid);
            Assert.IsTrue(user.UserName == "test@test.com");
            Assert.IsNull(user.Error);
        }
        
        [Test]
        public void LoginAnInValidUser()
        {
            var user = users.Login("test", "passwordtest");
            Assert.IsFalse(user.IsValid);
            Assert.IsTrue(user.UserName == null);
            Assert.IsNotEmpty(user.Error);
        }
    }
}