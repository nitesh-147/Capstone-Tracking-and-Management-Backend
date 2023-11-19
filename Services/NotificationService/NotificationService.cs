using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TrackingApp.Model;

namespace TrackingApp.Services.NotificationService
{
    public class NotificationService:INotificationService
    {
        private readonly IMongoCollection<Notification> _notificationcollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public NotificationService(IOptions<DatabaseSettings> dbSettings)
        {
            this._dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _notificationcollection = mongoDatabase.GetCollection<Notification>(dbSettings.Value.NotificationsCollectionName);
        }

        public async Task<IEnumerable<Notification>> Get() => await _notificationcollection.Find(_ => true).ToListAsync();
        public async Task<Notification> Get(string id) => await _notificationcollection.Find(notf => notf.Id == id).FirstOrDefaultAsync();
        public async Task Post(Notification notification) => await _notificationcollection.InsertOneAsync(notification);
        public async Task Put(string id, Notification notification) => await _notificationcollection.ReplaceOneAsync(notf => notf.Id == id, notification);
        public async Task Delete(string id) => await _notificationcollection.DeleteOneAsync(notf => notf.Id == id);
    }
}
