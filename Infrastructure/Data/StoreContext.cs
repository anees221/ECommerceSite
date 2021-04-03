
using System.Reflection;
using Core.Entitities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
         public DbSet<ProductType> ProductTypes { get; set; }

         //This is reason for creating new  Migrations after configurations in Migrations Folder
         protected  override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);
            ModelBuilder modelBuilder1 = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
         }
    }


}