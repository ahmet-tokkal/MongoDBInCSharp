using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Driver.Builders;

namespace MongoDb
{
    class MongoDBController
    {
        private IMongoDatabase mongoDatabase;
        public MongoDBController()
        {
            mongoDatabase = new MongoDBClient().GetDatabase("test");
        }
        public void ListCollections()
        {
            var list = mongoDatabase.ListCollections().ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public void AddLogin(Login login)
        {
            var collection = mongoDatabase.GetCollection<BsonDocument>("logins");
            var bsonDoc = login.ToBsonDocument();
            collection.InsertOne(bsonDoc);
        }
        public long GetLoginSize()
        {
            var collection = mongoDatabase.GetCollection<BsonDocument>("logins");
            long size = collection.CountDocuments(new BsonDocument());
            return size;
        }
        public List<Login> GetAllLogins()
        {
            var collection = mongoDatabase.GetCollection<Login>("logins");
            var query = from doc in collection.AsQueryable<Login>()
                        select doc;
            List<Login> logins = new List<Login>();
            foreach (var item in query)
            {
                logins.Add(item);
            }
            return logins;
        }
        public Login GetLoginWithSessionId(string sessionId)
        {
            var collection = mongoDatabase.GetCollection<Login>("logins");
            var query = from l in collection.AsQueryable<Login>()
                        where l.SessionId == sessionId
                        select l;
            List<Login> logins = new List<Login>();
            foreach (var item in query)
            {
                logins.Add(item);
            }
            return logins[0];
        }
    }
}
