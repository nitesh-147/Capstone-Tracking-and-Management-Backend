using TrackingApp.Model;

namespace TrackingApp.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> Get();
        Task<Category> Get(string id);
        Task Put(string id, Category category);
        Task Post(Category category);
        Task Delete(string id);
    }
}
