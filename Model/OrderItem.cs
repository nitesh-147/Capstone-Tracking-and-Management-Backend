using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TrackingApp.Model
{
    public class OrderItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
