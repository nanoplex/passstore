using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace passstore
{
    public class Passstore : PassstoreBase
    {
        public override MongoCollection<Password> Collection
        {
            get { return Mongo.Database.GetCollection<Password>("Passstore"); }
        }
    }
}