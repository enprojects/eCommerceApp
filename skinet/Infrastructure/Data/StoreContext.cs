using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>()
            //.Property(p => p.SomeId).HasColumnName("SomeRf");
        }

        public DbSet<Product> Products { get; set; }
        //public DbSet<ProductBrand> ProductBrands { get; set; }       
        public DbSet<ProductType> ProductTypes { get; set; }

    }
}
