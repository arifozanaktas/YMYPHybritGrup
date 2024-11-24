using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace YMYPHibrit3Group.API.Model.Services.Dto
{
    public record AddProductRequest(string Name, decimal Price, int Stock);


    //public record AddProductRequest
    //{
    //    //[StringLength(20, ErrorMessage = "isim alanı en fazla 20 karakter olabilir")]
    //    //[Required(ErrorMessage = "isim alanı gereklidir.")]
    //    public string Name { get; init; } = default!;


    //    // float- double - decimal
    //    //[Range(1, double.MaxValue, ErrorMessage = "fiyat alanı 0'dan büyük olmalıdır")]
    //    public decimal Price { get; init; }


    //    //[Range(1, int.MaxValue, ErrorMessage = "stok alanı 0'dan büyük olmalıdır")]
    //    public int Stock { get; init; }


    //    public AddProductRequest(string name, decimal price, int stock)
    //    {
    //        Name = name;
    //        Price = price;
    //        Stock = stock;
    //    }
    //}
}