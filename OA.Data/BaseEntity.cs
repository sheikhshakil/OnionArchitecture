using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace OA.Data
{
    public class BaseEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("creationDate")]
        public DateTime CreationDate { get; set; }

    }
}
