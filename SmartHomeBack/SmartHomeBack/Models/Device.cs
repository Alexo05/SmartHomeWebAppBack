using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartHomeBack.Models
{
    public class Device
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 

        [BsonElement("typeId")]
        public int TypeId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; }

        [BsonElement("imageUrl1")]
        public string ImageUrl1 { get; set; }

        [BsonElement("color")]
        public string Color { get; set; }

        [BsonElement("state")]
        public bool State { get; set; }

        [BsonElement("port")]
        public int Port { get; set; }
    }
}
