using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TrackingApp.Model;

namespace TrackingApp.Services.InventoryService
{
    public class InventoryService:IInventoryService
    {
        private readonly IMongoCollection<Inventory> _inventorycollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public InventoryService(IOptions<DatabaseSettings> dbSettings)
        {
            this._dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _inventorycollection = mongoDatabase.GetCollection<Inventory>(dbSettings.Value.InventoriesCollectionName);
        }

        public async Task<IEnumerable<Inventory>> Get() => await _inventorycollection.Find(_ => true).ToListAsync();
        public async Task<Inventory> Get(string id) => await _inventorycollection.Find(invent => invent.Id == id).FirstOrDefaultAsync();
        public async Task Post(Inventory inventory) => await _inventorycollection.InsertOneAsync(inventory);
        public async Task Put(string id, Inventory inventory) => await _inventorycollection.ReplaceOneAsync(invent => invent.Id == id, inventory);
        public async Task Delete(string id) => await _inventorycollection.DeleteOneAsync(invent => invent.Id == id);
    }
}
