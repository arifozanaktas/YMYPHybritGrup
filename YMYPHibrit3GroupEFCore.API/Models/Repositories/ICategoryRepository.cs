using YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities;

namespace YMYPHibrit3GroupEFCore.API.Models.Repositories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {

        Task<(Category, List<Product>)> GetWithProductsAsyncAsLinqQuery(int id);
        Task<Category?> GetWithProductsAsync(int id);
    }
}
