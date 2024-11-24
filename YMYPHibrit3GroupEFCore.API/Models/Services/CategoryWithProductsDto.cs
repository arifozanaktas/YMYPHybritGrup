using YMYPHibrit3GroupEFCore.API.Models.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Models.Services
{
    public class CategoryWithProductsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public List<ProductDto>? Products { get; set; }
    }
}
