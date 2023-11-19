using TrackingApp.Model;

namespace TrackingApp.Services.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(string id);
        Task Put(string id, User user);
        Task Post(User user);
        Task Delete(string id);
    }
}
