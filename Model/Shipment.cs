using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TrackingApp.Model
{
    public class Shipment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string CarrierId { get; set; }
        public string MethodId { get; set; }
        public string TrackingNumber { get; set; }

    }
}
