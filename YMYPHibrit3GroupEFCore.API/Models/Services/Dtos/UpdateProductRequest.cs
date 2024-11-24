namespace YMYPHibrit3GroupEFCore.API.Models.Services.Dtos
{
    public record UpdateProductRequest(int Id,string Name,decimal Price, int Stock);
}
