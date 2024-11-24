using YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities;

namespace YMYPHibrit3GroupEFCore.API.Models.Repositories;

public interface IProductRepository
{
    Task<Product?> GetWithFeature(int id);

    Task<List<Product>> GetAsync();
    Task<Product?> GetAsync(int id);
    Task<Product> AddAsync(Product product);

    Task UpdateAsync(Product product);

    Task UpdateAsync2(Product product);

    Task DeleteAsync(int id);
}