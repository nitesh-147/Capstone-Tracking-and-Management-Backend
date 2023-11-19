using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TrackingApp.Model;

namespace TrackingApp.Services.OrderItemService
{
    public class OrderItemService:IOrderItemService
    {
        private readonly IMongoCollection<OrderItem> _orderitemcollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public OrderItemService(IOptions<DatabaseSettings> dbSettings)
        {
            this._dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _orderitemcollection = mongoDatabase.GetCollection<OrderItem>(dbSettings.Value.OrderItemsCollectionName);
        }

        public async Task<IEnumerable<OrderItem>> Get() => await _orderitemcollection.Find(_ => true).ToListAsync();
        public async Task<OrderItem> Get(string id) => await _orderitemcollection.Find(_orderitem => _orderitem.Id == id).FirstOrDefaultAsync();
        public async Task Post(OrderItem orderitem) => await _orderitemcollection.InsertOneAsync(orderitem);
        public async Task Put(string id, OrderItem orderitem) => await _orderitemcollection.ReplaceOneAsync(_orderitem => _orderitem.Id == id, orderitem);
        public async Task Delete(string id) => await _orderitemcollection.DeleteOneAsync(_orderitem => _orderitem.Id == id);
    }
}
