using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProductManagement.Models
{
    public class ProductManagementContext : DbContext
    {
        public ProductManagementContext()
            : base("name=ProductManagementContext")
        {
        }

        public System.Data.Entity.DbSet<ProductManagement.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<ProductManagement.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<ProductManagement.Models.Supplier> Suppliers { get; set; }

    }
}