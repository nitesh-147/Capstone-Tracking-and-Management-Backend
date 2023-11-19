using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TrackingApp.Model
{
    public class ShippingMethod
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
