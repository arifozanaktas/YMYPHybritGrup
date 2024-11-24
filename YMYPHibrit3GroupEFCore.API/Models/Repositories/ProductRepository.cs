using Microsoft.EntityFrameworkCore;
using YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities;

namespace YMYPHibrit3GroupEFCore.API.Models.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        public async Task<List<Product>> GetAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product?> GetAsync(int id)
        {
            var product = await context.Products.FindAsync(id);

            var state = context.Entry(product).State;

            return product;
        }

        public async Task<Product> AddAsync(Product product)
        {
            var state1 = context.Entry(product).State;

            await context.Products.AddAsync(product);

            var state2 = context.Entry(product).State;


            await context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            var state1 = context.Entry(product).State;
            context.Products.Update(product);
            var state2 = context.Entry(product).State;

            context.Entry(product).Property(x => x.Barcode).IsModified = false;


            await context.SaveChangesAsync();
        }


        public async Task UpdateAsync2(Product product)
        {
            var productToUpdate = await context.Products.FindAsync(product.Id);

            var state2 = context.Entry(productToUpdate).State;
            productToUpdate.Stock = product.Stock;
            productToUpdate.Price = product.Price;
            productToUpdate.Name = product.Name;


            var state = context.Entry(productToUpdate).State;

            //context.Products.Update(productToUpdate);


            await context.SaveChangesAsync();
        }


        public async Task UpdateAsyncAsBulk(Product product)
        {
            await context.Products.Where(x => x.Id == product.Id).ExecuteUpdateAsync(update =>
                update.SetProperty(x => x.Price, product.Price).SetProperty(x => x.Name, product.Name)
                    .SetProperty(x => x.Stock, product.Stock));
        }


        public async Task DeleteAsync(int id)
        {
            var productToDelete = context.Products.Find(id);

            context.Products.Remove(productToDelete!);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsBulkAsync(int id)
        {
            //delete product where id=2;


            //bulk delete

            await context.Products.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<Product?> GetWithFeature(int id)
        {
            #region eager loading

            var product = await context.Products.Include(x => x.ProductFeature)
                .FirstOrDefaultAsync(x => x.Id == id);

            #endregion


            #region Lazy Loading

            //var category = context.Categories.First();


            //if (true)
            //{
            //    // var products = category.Products;

            //    // n+1 =>
            //    foreach (var item in category.Products)
            //    {
            //    }
            //}


            //var product = await context.Products.FindAsync(id);

            //if (true)
            //{
            //    var feature = product.ProductFeature;


            //}

            #endregion


            #region Explicit Loading

            //var productFeature= await context.ProductFeature.FirstOrDefaultAsync(x => x.ProductId == id);

            //product.ProductFeature = productFeature;

            //await context.Entry(product!).Reference(x => x.ProductFeature).LoadAsync();


            // one to many
            //var category = await context.Categories.FirstAsync();

            //await context.Entry(category).Collection(x => x.Products).LoadAsync();

            #endregion

            return product;
        }


        public async Task<(Product, ProductFeature)> GetWithFeatureAsQuerySyntax(int id)
        {
            var result = await (from p in context.Products
                join pf in context.ProductFeature on p.Id equals pf.ProductId
                where p.Id == id
                select new
                {
                    p,
                    pf
                }).FirstOrDefaultAsync();

            return (result.p, result.pf);
        }
    }
}