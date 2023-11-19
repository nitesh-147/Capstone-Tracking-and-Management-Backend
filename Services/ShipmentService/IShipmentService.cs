using TrackingApp.Model;

namespace TrackingApp.Services.ShipmentService
{
    public interface IShipmentService
    {
        Task<IEnumerable<Shipment>> Get();
        Task<Shipment> Get(string id);
        Task Put(string id, Shipment shipment);
        Task Post(Shipment shipment);
        Task Delete(string id);
    }
}
