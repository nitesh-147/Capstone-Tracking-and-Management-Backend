using TrackingApp.Model;

namespace TrackingApp.Services.CarrierService
{
    public interface ICarrierService
    {
        Task<IEnumerable<Carrier>> Get();
        Task<Carrier> Get(string id);
        Task Put(string id, Carrier carrier);
        Task Post(Carrier carrier);
        Task Delete(string id);
    }
}
