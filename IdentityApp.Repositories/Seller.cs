namespace IdentityApp.Repositories
{
    public class Seller
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}