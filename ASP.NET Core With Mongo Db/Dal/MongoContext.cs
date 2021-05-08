using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ASP.NET_Core_With_Mongo_Db.Dal
{
    public class MongoContext<T> where T: class
    {
        public MongoContext(T model)
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            var db = client.GetDatabase("MongoDBContext");
            collection = db.GetCollection<T>($"{model}");
        }

        public IMongoCollection<T> collection { get; set; }
    } 
}
