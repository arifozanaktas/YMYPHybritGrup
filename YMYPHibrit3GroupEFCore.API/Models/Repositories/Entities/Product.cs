namespace YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }

        public string? Barcode { get; set; }

        public int Stock { get; set; }


        public int CategoryId { get; set; }

        //Navigation Property
        public virtual Category Category { get; set; } = default!;

        public virtual ProductFeature? ProductFeature { get; set; }
    }
}