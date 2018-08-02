using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDb
{
    class MongoDBClient
    {
        private MongoClient client;
        private IMongoDatabase mongoDatabase;
        private string connectionString = "mongodb://127.0.0.1:27017";

        public MongoDBClient()
        {
            client = new MongoClient(connectionString);
        }
        public IMongoDatabase GetDatabase(string dbName)
        {
            mongoDatabase = client.GetDatabase(dbName);
            return mongoDatabase;
        }
    }
}
