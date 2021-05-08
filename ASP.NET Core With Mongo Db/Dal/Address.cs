using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Dal
{
    public class Address : IEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Country")]
        [BsonRequired]
        public string Country { get; set; }
        [BsonElement("County")]
        [BsonRequired]
        public string County { get; set; }
        [BsonElement("District")]
        public string District { get; set; }
    }
}
