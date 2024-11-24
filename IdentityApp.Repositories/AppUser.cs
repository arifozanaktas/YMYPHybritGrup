using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Repositories
{
    public class AppUser : IdentityUser<Guid>
    {
        public DateTime? BirthDate { get; set; }
        public string? City { get; set; }

        public UserFeature? UserFeature { get; set; }
    }
}