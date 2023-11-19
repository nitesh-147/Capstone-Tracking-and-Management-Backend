using TrackingApp.Model;

namespace TrackingApp.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(string id);
        Task Put(string id, Product product);
        Task Post(Product product);
        Task Delete(string id);
    }
}
