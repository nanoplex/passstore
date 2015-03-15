using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver.Builders;
using passstore;

namespace UnitTests
{
    [TestClass]
    public class PassstoreTest
    {
        public TestUser User = new TestUser { Username = "test", MasterPassword = "test" };
        public TestPassstore Passstore = new TestPassstore();

        [TestInitialize]
        public void Init()
        {
            User.Auth();
            var t = 0;
        }

        [TestMethod]
        public void Passstore_Add()
        {
            var oldPassCount = Passstore.Collection.FindAllAs<Password>().Count();

            Passstore.AddPass(User, "test", "test", "test");

            var newPassCount = Passstore.Collection.FindAllAs<Password>().Count();

            Assert.AreNotEqual(newPassCount, oldPassCount);

            Passstore.RemovePass(User, Passstore.Collection.FindOneAs<Password>(Query<Password>.EQ(p => p.Name, "test"))._id);
        }

        [TestMethod]
        public void Passstore_Remove()
        {
            Passstore.AddPass(User, "test", "test", "test");

            var oldPassCount = Passstore.Collection.FindAllAs<Password>().Count();

            Passstore.RemovePass(User, Passstore.Collection.FindOneAs<Password>(Query<Password>.EQ(p => p.Name, "test"))._id);

            var newPassCount = Passstore.Collection.FindAllAs<Password>().Count();

            Assert.AreNotEqual(newPassCount, oldPassCount);
        }
    }
}
