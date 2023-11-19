using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TrackingApp.Model
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string CategoryId { get; set; }
        public int stock {  get; set; }
        public string WarehouseId { get; set; }

    }
}
