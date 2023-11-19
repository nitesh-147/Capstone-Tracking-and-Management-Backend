using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TrackingApp.Model;

namespace TrackingApp.Services.ShipmentService
{
    public class ShipmentService:IShipmentService
    {
        private readonly IMongoCollection<Shipment> _shipmentmethodcollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public ShipmentService(IOptions<DatabaseSettings> dbSettings)
        {
            this._dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _shipmentmethodcollection = mongoDatabase.GetCollection<Shipment>(dbSettings.Value.ShipmentsCollectionName);
        }

        public async Task<IEnumerable<Shipment>> Get() => await _shipmentmethodcollection.Find(_ => true).ToListAsync();
        public async Task<Shipment> Get(string id) => await _shipmentmethodcollection.Find(shipm => shipm.Id == id).FirstOrDefaultAsync();
        public async Task Post(Shipment shipment) => await _shipmentmethodcollection.InsertOneAsync(shipment);
        public async Task Put(string id, Shipment shipment) => await _shipmentmethodcollection.ReplaceOneAsync(shipm => shipm.Id == id, shipment);
        public async Task Delete(string id) => await _shipmentmethodcollection.DeleteOneAsync(shipm => shipm.Id == id);
    }
}
