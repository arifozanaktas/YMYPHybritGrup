namespace YMYPHibrit3GroupEFCore.API.Models.Services.Dtos
{
    public record ProductDto(int Id, string Name, decimal Price, int Stock, ProductFeatureDto? ProductFeatureDto);


    public class ProductDto2
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public ProductFeatureDto? ProductFeatureDto { get; set; }
    }
}