namespace DelegateAndEvents
{
    public record StockChangedData(int Stock, string Barcode);


    internal class ProductService
    {
        internal event Action<StockChangedData> StockChangedEvent;


        private readonly ProductRepository productRepository = new ProductRepository();


        internal void UpdateStock(int stock)
        {
            if (stock is > 1 and < 100)
            {
                productRepository.UpdateStock(stock);


                StockChangedEvent?.Invoke(new StockChangedData(stock, GetProduct().Barcode));
            }
            else
            {
                throw new Exception("Stock 1 ile 100 arasında olmalıdır.");
            }
        }


        internal Product GetProduct()
        {
            return productRepository.GetProduct();
        }
    }
}