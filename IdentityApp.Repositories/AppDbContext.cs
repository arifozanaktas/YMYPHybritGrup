using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<AppUser, AppRole, Guid>(options)
    {
        public DbSet<Seller> Sellers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<AppUser>().Property(x => x.City).HasMaxLength(100);

            builder.Entity<UserFeature>()
                .HasOne(x => x.AppUser)
                .WithOne(x => x.UserFeature)
                .HasForeignKey<UserFeature>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}