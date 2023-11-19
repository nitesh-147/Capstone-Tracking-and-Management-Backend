using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TrackingApp.Model;

namespace TrackingApp.Services.CategoryService
{
    public class CategoryService:ICategoryService
    {
        private readonly IMongoCollection<Category> _categorycollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public CategoryService(IOptions<DatabaseSettings> dbSettings)
        {
            this._dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _categorycollection = mongoDatabase.GetCollection<Category>(dbSettings.Value.CategoriesCollectionName);
        }

        public async Task<IEnumerable<Category>> Get() => await _categorycollection.Find(_ => true).ToListAsync();
        public async Task<Category> Get(string id) => await _categorycollection.Find(cate => cate.Id == id).FirstOrDefaultAsync();
        public async Task Post(Category category) => await _categorycollection.InsertOneAsync(category);
        public async Task Put(string id, Category category) => await _categorycollection.ReplaceOneAsync(cate => cate.Id == id, category);
        public async Task Delete(string id) => await _categorycollection.DeleteOneAsync(cate => cate.Id == id);
    }
}
