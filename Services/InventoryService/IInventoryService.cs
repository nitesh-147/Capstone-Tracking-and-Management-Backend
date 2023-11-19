using TrackingApp.Model;

namespace TrackingApp.Services.InventoryService
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> Get();
        Task<Inventory> Get(string id);
        Task Put(string id, Inventory inventory);
        Task Post(Inventory inventory);
        Task Delete(string id);
    }
}
