using System;
using System.Collections.Specialized;
using System.Linq;
using MongoDB.Driver;

namespace AugularJsFrameworkDemo.Configs.Windsor
{
    public class DataStore : IDataStore
    {
        private readonly IMongoDatabase _db;

        public IMongoDatabase DataBase
        {

            get { return _db; }
        }

        //serverurl;databasename;
        public DataStore(string connectionString)
        {
            var config = new NameValueCollection();
            foreach (
                var keyvalue in
                    connectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(entry => entry.Split('=')))
            {
                if (keyvalue.Length < 2)
                {
                    throw new ArgumentException(
                        "Expected 2 elements composing the key/value pair for an entry in the query string.");
                }

                if (keyvalue.Length == 2)
                {
                    var key = keyvalue[0].ToLower();
                    var value = keyvalue[1];
                    config.Add(key, value);
                }
                else if (keyvalue.Length > 2)
                {
                    var key = keyvalue[0].ToLower();
                    var value = string.Empty;
                    for (var i = 1; i < keyvalue.Length + 1; i++)
                    {
                        value += keyvalue[i];
                    }
                    config.Add(key, value);
                }
            }
            var serverName = config["server"];
            if (serverName == null)
                throw new ArgumentException("Missing 'server' name on Mongo connection string");
            var databaseName = config["database"];
            if (databaseName == null)
                throw new ArgumentException("Missing 'database' name on Mongo connectiong string");
            var mongoClient = new MongoClient(serverName);
            _db = mongoClient.GetDatabase(databaseName);
        }
    }
}