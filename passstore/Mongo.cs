using System;
using MongoDB.Driver;

namespace passstore
{
    public static class Mongo
    {
        public static MongoDatabase Database
        {
            get
            {
                try
                {
                    string connectionString = "mongodb://mathias:cws52qbzpe2kcom@93.160.108.34/passstore";
                    var client = new MongoClient(connectionString);

                    MongoServer server = client.GetServer();
                    return server.GetDatabase("passstore");
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static MongoDatabase TestDatabase
        {
            get
            {
                try
                {
                    string connectionString = "mongodb://test:test@93.160.108.34/test-passstore";
                    var client = new MongoClient(connectionString);

                    MongoServer server = client.GetServer();
                    return server.GetDatabase("test-passstore");
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}