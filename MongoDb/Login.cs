using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MongoDb
{
    class Login
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("id")]
        public long id { get; set; }
        [BsonElement("Created")]
        public DateTime Created { get; set; }
        [BsonElement("AccountName")]
        public string AccountName { get; set; }
        [BsonElement("LastLoginTime")]
        public DateTime LastLoginTime { get; set; }
        [BsonElement("LoggedIn")]
        public byte LoggedIn { get; set; }
        [BsonElement("SessionId")]
        public string SessionId { get; set; }
        [BsonElement("IpString")]
        public string IpString { get; set; }
        [BsonElement("Source")]
        public string Source { get; set; }
        [BsonElement("AppStr")]
        public string AppStr { get; set; }
        [BsonElement("Version")]
        public string Version { get; set; }
        [BsonElement("LastLoginRequest")]
        public DateTime LastLoginRequest { get; set; }
        [BsonElement("LoginCount")]
        public string LoginCount { get; set; }
        [BsonElement("LogoffCount")]
        public string LogoffCount { get; set; }

        public Login()
        {

        }
        public Login(string[] line)
        {
            this.id = Int32.Parse(line[0]);
            this.Created = DateTime.Parse(line[1]);
            this.AccountName = line[2];
            this.LastLoginTime = DateTime.Parse(line[3]);
            this.LoggedIn = Byte.Parse(line[4]);
            this.SessionId = line[5];
            this.IpString = line[6];
            this.Source = line[7];
            this.AppStr = line[8];
            this.Version = line[9];
            this.LastLoginRequest = DateTime.Parse(line[10]);
            this.LoginCount = line[11];
            this.LogoffCount = line[12];
        }
    }
}
