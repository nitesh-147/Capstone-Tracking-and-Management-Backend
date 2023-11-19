using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TrackingApp.Model;

namespace TrackingApp.Services.WarehouseService
{
    public class WarehouseService:IWarehouseService
    {
        private readonly IMongoCollection<Warehouse> _warehousecollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public WarehouseService(IOptions<DatabaseSettings> dbSettings)
        {
            this._dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _warehousecollection = mongoDatabase.GetCollection<Warehouse>(dbSettings.Value.WarehousesCollectionName);
        }

        public async Task<IEnumerable<Warehouse>> Get() => await _warehousecollection.Find(_ => true).ToListAsync();
        public async Task<Warehouse> Get(string id) => await _warehousecollection.Find(wh => wh.Id == id).FirstOrDefaultAsync();
        public async Task Post(Warehouse warehouse) => await _warehousecollection.InsertOneAsync(warehouse);
        public async Task Put(string id, Warehouse warehouse) => await _warehousecollection.ReplaceOneAsync(wh => wh.Id == id, warehouse);
        public async Task Delete(string id) => await _warehousecollection.DeleteOneAsync(wh => wh.Id == id);
    }
}
