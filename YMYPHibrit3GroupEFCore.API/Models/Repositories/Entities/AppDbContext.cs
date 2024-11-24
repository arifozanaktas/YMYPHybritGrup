using System.Reflection;
using Microsoft.EntityFrameworkCore;
using YMYPHibrit3GroupEFCore.API.Models.Repositories.Configurations;
using YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities.ManyToMany;

namespace YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }


        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductFeature> ProductFeature { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}