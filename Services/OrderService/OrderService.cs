using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TrackingApp.Model;

namespace TrackingApp.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orderCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public OrderService(IOptions<DatabaseSettings> dbSettings)
        {
            this._dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _orderCollection = mongoDatabase.GetCollection<Order>(dbSettings.Value.OrdersCollectionName);
        }

        public async Task<IEnumerable<Order>> Get() => await _orderCollection.Find(_ => true).ToListAsync();
        public async Task<Order> Get(string id) => await _orderCollection.Find(order => order.Id == id).FirstOrDefaultAsync();
        public async Task Post(Order order) => await _orderCollection.InsertOneAsync(order);
        public async Task Put(string id, Order order) => await _orderCollection.ReplaceOneAsync(ord => ord.Id == id, order);
        public async Task Delete(string id) => await _orderCollection.DeleteOneAsync(ord => ord.Id == id);
    }
}
