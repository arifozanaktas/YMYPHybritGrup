using System.Runtime.CompilerServices;

namespace DelegateAndEvents
{
    internal class ProductRepository
    {
        private static Product product;


        static ProductRepository()
        {
            product = new Product() { Id = 1, Name = "Kalem 1", Stock = 20, Barcode = Guid.NewGuid().ToString() };
        }

        internal void UpdateStock(int stock) => product.Stock = stock;


        internal Product GetProduct() => product;
    }
}