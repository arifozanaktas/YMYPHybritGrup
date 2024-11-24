using YMYPHibrit3Group.API.Model.Repositories.Entities;

namespace YMYPHibrit3Group.API.Model.Repositories;

public interface IProductRepository
{
    List<Product> GetAll();
    bool Any(Func<Product, bool> fun);
    Product? Get(int id);

    Product Add(Product product);

    Product Update(Product product);

    void UpdateStock(int id, int stock);

    void UpdatePrice(int id, decimal price);
    void Delete(int id);

    int GetCount();
}