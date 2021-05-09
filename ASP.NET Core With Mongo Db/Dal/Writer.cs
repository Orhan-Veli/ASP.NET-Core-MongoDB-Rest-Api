using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Dal
{
    public class Writer : IEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Name")]
        [BsonRequired]
        public string Name { get; set; }
        [BsonElement("Last Name")]
        [BsonRequired]
        public string LastName { get; set; }
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime DateTime { get; set; }
        [BsonIgnore]
        public Address Address { get; set; }
        public ObjectId AddressId { get; set; }
        [BsonIgnore]
        public List<Book> Books { get; set; }
    }
}
