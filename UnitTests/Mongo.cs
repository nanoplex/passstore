using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using passstore;

namespace UnitTests
{
    [TestClass]
    public class MongoTest
    {
        [TestMethod]
        public void Mongo_DatabaseConnection()
        {
            Assert.AreNotEqual(Mongo.TestDatabase, null);
        }
    }
}