using TrackingApp.Model;

namespace TrackingApp.Services.NotificationService
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> Get();
        Task<Notification> Get(string id);
        Task Put(string id, Notification notification);
        Task Post(Notification notification);
        Task Delete(string id);
    }
}
