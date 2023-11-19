using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TrackingApp.Model;

namespace TrackingApp.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly IMongoCollection<User> _userCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public UserService(IOptions<DatabaseSettings> dbSettings)
        {
            this._dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _userCollection = mongoDatabase.GetCollection<User>(dbSettings.Value.UsersCollectionName);
        }

        public async Task<IEnumerable<User>> Get() => await _userCollection.Find(_ => true).ToListAsync();
        public async Task<User> Get(string id)=> await _userCollection.Find(user=> user.Id==id).FirstOrDefaultAsync();
        public async Task Post(User user) => await _userCollection.InsertOneAsync(user);
        public async Task Put(string id,User user) => await _userCollection.ReplaceOneAsync(us=>us.Id==id,user);
        public async Task Delete(string id) => await _userCollection.DeleteOneAsync(us=>us.Id==id);
    }
}
