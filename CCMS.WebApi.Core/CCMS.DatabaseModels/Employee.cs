using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CCMS.DatabaseModels
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Birthdate")]
        public DateTime Birthdate { get; set; }

    }
}
