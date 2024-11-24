namespace YMYPHibrit3GroupEFCore.API.Models.Services.Dtos
{
    public record AddCategoryWithProductRequest(string CategoryName,string ProductName,decimal ProductPrice,int ProductStock);
   
}
