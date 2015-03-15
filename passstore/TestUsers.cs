using MongoDB.Driver;

namespace passstore
{
    public class TestUsers : UsersBase
    {
        public override MongoCollection<UserBase> Collection
        {
            get { return Mongo.TestDatabase.GetCollection<UserBase>("User"); }
        }
    }
}
