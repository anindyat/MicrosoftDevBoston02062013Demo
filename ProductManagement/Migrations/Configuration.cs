namespace ProductManagement.Migrations
{
    using ProductManagement.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductManagement.Models.ProductManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProductManagement.Models.ProductManagementContext context)
        {

            context.Suppliers.AddOrUpdate(
              p => p.Name,
              new Supplier {  Key= "MSFT", Name = "Microsoft"},
              new Supplier { Key = "SONY", Name = "Sony" }
            );

            context.Categories.AddOrUpdate(
              p => p.Name,
              new Category { ID=1, Name = "Game" },
              new Category { ID = 2, Name = "Browser" },
              new Category { ID = 3, Name = "Phone" }
            );

            context.Products.AddOrUpdate(
              p => p.Name,
              new Product { ID = 1, Name="XBoxOne", Price=499, SupplierId="MSFT", CategoryId=1},
              new Product { ID = 2, Name = "XBox360", Price = 300, SupplierId = "MSFT", CategoryId = 1 },
              new Product { ID = 3, Name = "PlayStation", Price = 400, SupplierId = "SONY", CategoryId = 1 },
              new Product { ID = 4, Name = "Windows Phone 7", Price = 250, SupplierId = "MSFT", CategoryId = 3 },
              new Product { ID = 5, Name = "Windows Phone 8", Price = 225, SupplierId = "MSFT", CategoryId = 3 },
              new Product { ID = 6, Name = "Internet Explorer 11", Price = 50, SupplierId = "MSFT", CategoryId = 2 },
              new Product { ID = 7, Name = "Internet Explorer 10", Price = 40, SupplierId = "MSFT", CategoryId = 2 }
            );
        }
    }
}
