using MongoDB.Bson.Serialization.Attributes;

namespace OA.Data
{
    public class User : BaseEntity
    {
        [BsonElement("fullName")]
        public string FullName { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }
    }
}
