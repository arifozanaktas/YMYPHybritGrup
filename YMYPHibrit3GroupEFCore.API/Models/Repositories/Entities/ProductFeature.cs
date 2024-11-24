namespace YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }


        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = default!;
    }
}