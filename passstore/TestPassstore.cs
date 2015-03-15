using MongoDB.Driver;

namespace passstore
{
    public class TestPassstore : PassstoreBase
    {
        public override MongoCollection<Password> Collection
        {
            get { return Mongo.TestDatabase.GetCollection<Password>("Passstore"); }
        }
    }
}
