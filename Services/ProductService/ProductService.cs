using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TrackingApp.Model;

namespace TrackingApp.Services.ProductService
{
    public class ProductService:IProductService
    {
        private readonly IMongoCollection<Product> _productcollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public ProductService(IOptions<DatabaseSettings> dbSettings)
        {
            this._dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _productcollection = mongoDatabase.GetCollection<Product>(dbSettings.Value.ProductsCollectionName);
        }

        public async Task<IEnumerable<Product>> Get() => await _productcollection.Find(_ => true).ToListAsync();
        public async Task<Product> Get(string id) => await _productcollection.Find(prod => prod.Id == id).FirstOrDefaultAsync();
        public async Task Post(Product product) => await _productcollection.InsertOneAsync(product);
        public async Task Put(string id, Product product) => await _productcollection.ReplaceOneAsync(prod => prod.Id == id, product);
        public async Task Delete(string id) => await _productcollection.DeleteOneAsync(prod => prod.Id == id);
    }
}
