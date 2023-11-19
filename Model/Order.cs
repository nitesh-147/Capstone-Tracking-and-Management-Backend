using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrackingApp.Model
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    
        public string UserId { get; set; }
        public string OrderDate { get; set; }
        public string OrderStatus { get; set; }

        public string ProductName {  get; set; }
        public int quantity { get; set; }
        public string RecipentName { get; set; }
        public string Address { get; set; }
    }
}
