using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TrackingApp.Model;

namespace TrackingApp.Services.CarrierService
{
    public class CarrierService:ICarrierService
    {
        private readonly IMongoCollection<Carrier> _carriercollection;
        //private readonly IOptions<DatabaseSettings> _dbSettings;

        public CarrierService(IOptions<DatabaseSettings> dbSettings)
        {
            //this._dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _carriercollection = mongoDatabase.GetCollection<Carrier>(dbSettings.Value.CarriersCollectionName);
        }

        public async Task<IEnumerable<Carrier>> Get() => await _carriercollection.Find(_ => true).ToListAsync();
        public async Task<Carrier> Get(string id) => await _carriercollection.Find(carry => carry.Id == id).FirstOrDefaultAsync();
        public async Task Post(Carrier carrier) => await _carriercollection.InsertOneAsync(carrier);
        public async Task Put(string id, Carrier carrier) => await _carriercollection.ReplaceOneAsync(carry => carry.Id == id, carrier);
        public async Task Delete(string id) => await _carriercollection.DeleteOneAsync(carry => carry.Id == id);
    }
}
