using TrackingApp.Model;

namespace TrackingApp.Services.WarehouseService
{
    public interface IWarehouseService
    {
        Task<IEnumerable<Warehouse>> Get();
        Task<Warehouse> Get(string id);
        Task Put(string id, Warehouse warehouse);
        Task Post(Warehouse warehouse);
        Task Delete(string id);
    }
}
