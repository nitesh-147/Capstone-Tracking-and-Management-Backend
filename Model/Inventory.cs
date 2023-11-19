using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TrackingApp.Model
{
    public class Inventory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }=String.Empty;
        public string UserId { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
        public string TransferStatus { get; set; } = String.Empty;
        public string Destination { get; set; } = String.Empty;
        public List<Item> Items{ get; set; }= new List<Item>();
    }

    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
