using TrackingApp.Model;

namespace TrackingApp.Services.ShippingMethodService
{
    public interface IShipmentMethodService
    {
        Task<IEnumerable<ShippingMethod>> Get();
        Task<ShippingMethod> Get(string id);
        Task Put(string id, ShippingMethod shipmentMethod);
        Task Post(ShippingMethod shipmentMethod);
        Task Delete(string id);
    }
}
