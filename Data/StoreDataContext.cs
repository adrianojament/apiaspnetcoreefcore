using ApiAspnetCoreEfCore.Data.Maps;
using ApiAspnetCoreEfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAspnetCoreEfCore.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=prodcat;User ID=SA;Password=1q2w3e%&!");
            optionsBuilder.UseInMemoryDatabase("store");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
        }
    }
}