using TrackingApp.Model;

namespace TrackingApp.Services.OrderService
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> Get();
        Task<Order> Get(string id);
        Task Post(Order order);
        Task Put(string id, Order order);
        Task Delete(string id);
    }
}