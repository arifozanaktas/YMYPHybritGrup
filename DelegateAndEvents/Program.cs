// See https://aka.ms/new-console-template for more information

using DelegateAndEvents;

Console.WriteLine("Hello, World!");


var productService = new ProductService();

productService.StockChangedEvent += StockChanged;


Console.WriteLine($"önce :product stock:{productService.GetProduct().Stock}");


for (int i = 30; i < 40; i++)
{
    productService.UpdateStock(i);
}


Console.WriteLine($"sonra :product stock:{productService.GetProduct().Stock}");


static void StockChanged(StockChangedData stockChangedData)
{
    Console.WriteLine($"Stock changed. New stock value is {stockChangedData.Stock} - {stockChangedData.Barcode}");
}


// API(Controller )> Service > Repository
// Program > Service  > Repository