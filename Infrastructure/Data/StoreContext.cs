using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;
using System.Linq;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        
        
        public StoreContext( DbContextOptions<StoreContext> options) : base(options)
        {
        }

        //access the products and use the method in dbcontext
        public DbSet<Product> Products {get;set;}
        public DbSet<ProductBrand> ProductBrands {get;set;}
        public DbSet<ProductType> ProductType {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach(var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name)
                            .HasConversion<double>();
                    }
                }
            }
        }
    }
    //code first approach
    //create a data migration using dot
    //1. add package: microsoft.EntityFrameworkCore.Design 
    //2. using bash input this command:dotnet ef migration add InitialCreate -o Data/Migrations 
}