using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TrackingApp.Model;

namespace TrackingApp.Services.ShippingMethodService
{
    public class ShipmentMethodService:IShipmentMethodService
    {
        private readonly IMongoCollection<ShippingMethod> _shipmentmethodcollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public ShipmentMethodService(IOptions<DatabaseSettings> dbSettings)
        {
            this._dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _shipmentmethodcollection = mongoDatabase.GetCollection<ShippingMethod>(dbSettings.Value.ShippingMethodsCollectionName);
        }

        public async Task<IEnumerable<ShippingMethod>> Get() => await _shipmentmethodcollection.Find(_ => true).ToListAsync();
        public async Task<ShippingMethod> Get(string id) => await _shipmentmethodcollection.Find(shipm => shipm.Id == id).FirstOrDefaultAsync();
        public async Task Post(ShippingMethod shipmentmethod) => await _shipmentmethodcollection.InsertOneAsync(shipmentmethod);
        public async Task Put(string id, ShippingMethod shipmentmethod) => await _shipmentmethodcollection.ReplaceOneAsync(shipm => shipm.Id == id, shipmentmethod);
        public async Task Delete(string id) => await _shipmentmethodcollection.DeleteOneAsync(shipm => shipm.Id == id);
    }
}
