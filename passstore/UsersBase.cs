using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace passstore
{
    public abstract class UsersBase
    {
        public abstract MongoCollection<UserBase> Collection { get; }

        public void Add(UserBase user)
        {
            var hash = new Hash();


            user._id = ObjectId.GenerateNewId();
            user.Salt = hash.GetRandomSalt(16);
            user.MasterPassword = hash.HashPassword(user.MasterPassword, user.Salt);
            user.Name = Crypto.Encrypt(user.Name, user.MasterPassword);

            Collection.Insert(user);
        }

        public void Remove(ObjectId passId)
        {
            IMongoQuery query = Query<UserBase>.EQ(u => u._id, passId);
            Collection.Remove(query);
        }
    }
}
