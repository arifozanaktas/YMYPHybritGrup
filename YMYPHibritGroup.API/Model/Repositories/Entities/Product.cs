using System.ComponentModel.DataAnnotations;

namespace YMYPHibrit3Group.API.Model.Repositories.Entities;

public class Product
{
    public int Id { get; set; }


    public string Name { get; set; } = default!;
    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string Barcode { get; set; }
}