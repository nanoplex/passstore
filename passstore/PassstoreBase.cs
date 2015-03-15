using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace passstore
{
    public abstract class PassstoreBase
    {
        public abstract MongoCollection<Password> Collection { get; }

        public void AddPass(UserBase user, string name, string username, string password)
        {
            var pass = new Password();

            pass._id = ObjectId.GenerateNewId();
            pass.Name = name;
            pass.Username = username;
            pass.Pass = Crypto.Encrypt(password, user.MasterPassword);
            pass.UserId = user._id;

            Collection.Insert(pass);
        }

        public void RemovePass(UserBase user, ObjectId passId)
        {
            var query = Query<Password>.EQ(p => p._id, passId);
            Collection.Remove(query);
        }

        public List<Password> GetEncryptedPasswords(UserBase user)
        {
            return Collection.FindAllAs<Password>().Where(p => p.UserId.Equals(user._id)).ToList();
        }

        public Password GetDecryptedPassword(UserBase user, ObjectId passId)
        {
            var pass = Collection.FindOneAs<Password>(Query<Password>.EQ(p => p._id, passId));

            pass.Pass = Crypto.Decrypt(pass.Pass, user.MasterPassword);

            return pass;
        }
    }
}
