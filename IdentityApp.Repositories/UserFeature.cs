namespace IdentityApp.Repositories
{
    public class UserFeature
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }

        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; } = default!;
    }
}