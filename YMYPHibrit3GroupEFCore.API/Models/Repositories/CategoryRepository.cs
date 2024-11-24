using Microsoft.EntityFrameworkCore;
using YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities;

namespace YMYPHibrit3GroupEFCore.API.Models.Repositories
{
    public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

            
        }

        public Task<Category?> GetWithProductsAsync(int id)
        {

            //1. way(Best Practices) (Eager Loading )
           return _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);

        }
      

        public async Task<(Category,List<Product>)> GetWithProductsAsyncAsLinqQuery(int id)
        {





            // LinQ Query Syntax

            var categoryWithProductsList = await _context.Categories.Where(c => c.Id == id).Join(_context.Products, c => c.Id, p => p.CategoryId, (c, p) => new { c, p }).ToListAsync();

            //select * from Categories c
            //join Products p on c.Id = p.CategoryId
            //where c.Id = 1
           
             var category = categoryWithProductsList.Select(c => c.c).First();

            var products = categoryWithProductsList.Select(c => c.p).ToList();

            //List<Product> products2 = new();
            //foreach (var p in categoryWithProductsList)
            //{
            //    products2.Add(p);


            //}




            return (category, products);

        }

        public async Task<(Category, List<Product>)> GetWithProductsAsyncAsQuery(int id)
        {

            //            select* from Categories c
            //join Products p on c.Id = p.CategoryId
            //where c.Id = 1

            //  Query Syntax
            var categoryWithProducts = await (from c in _context.Categories
                                        join p in _context.Products on c.Id equals p.CategoryId
                                        where c.Id == id
                                        select new { c, p }).ToListAsync();


         


            var category = categoryWithProducts.Select(c => c.c).First();

            var products = categoryWithProducts.Select(c => c.p).ToList();



            return (category, products);

        }
    }
}
