using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Dal
{
    public class Book : IEntity
    {
       
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Category")]
        public string Category { get; set; }
        [BsonIgnore]
        public Writer Writer { get; set; }
        public  ObjectId WriterId { get; set; }
    }
}
