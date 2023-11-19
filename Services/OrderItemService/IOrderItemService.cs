using TrackingApp.Model;

namespace TrackingApp.Services.OrderItemService
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> Get();
        Task<OrderItem> Get(string id);
        Task Put(string id, OrderItem orderItem);
        Task Post(OrderItem orderItem);
        Task Delete(string id);
    }
}
