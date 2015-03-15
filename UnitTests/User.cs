using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using passstore;

namespace UnitTests
{
    [TestClass]
    public class UserAuthTest
    {
        [TestMethod]
        public void User_Autherized()
        {
            var user = new TestUser { Username = "test", MasterPassword = "test" };
            user.Auth();
            Assert.AreNotEqual(user.MasterPassword, null);
        }

        [TestMethod]
        public void User_Unautherized()
        {
            var user = new TestUser { Username = "test", MasterPassword = "" };
            user.Auth();
            Assert.AreEqual(user.MasterPassword, null);
        }
    }
    [TestClass]
    public class UserTest
    {
        public MongoCursor Users { get; set; }

        [TestInitialize]
        public void Init()
        {
            Users = new TestUsers().Collection.FindAllAs<TestUser>();
        }

        [TestMethod]
        public void User_Add()
        {
            var oldUserCount = new TestUsers().Collection.FindAllAs<TestUser>().Count();

            var user = new TestUser();
            user.Name = "TEST";
            user.Username = "TEST";
            user.MasterPassword = "TEST";
            new TestUsers().Add(user);

            Assert.AreNotEqual(new TestUsers().Collection.FindAllAs<TestUser>().Count(), oldUserCount);

            new TestUsers().Remove(user._id);
        }

        [TestMethod]
        public void User_Remove()
        {
            var user = new TestUser();
            user.Name = "TEST";
            user.Username = "TEST";
            user.MasterPassword = "TEST";
            new TestUsers().Add(user);

            var oldUserCount = new TestUsers().Collection.FindAllAs<TestUser>().Count();

            new TestUsers().Remove(user._id);

            Assert.AreNotEqual(new Users().Collection.FindAllAs<TestUser>().Count(), oldUserCount);
        }
    }
}