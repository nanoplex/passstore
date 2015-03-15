using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace passstore
{
    public class Users : UsersBase
    {
        public override MongoCollection<UserBase> Collection
        {
            get { return Mongo.Database.GetCollection<UserBase>("User"); }
        }
    }
}
