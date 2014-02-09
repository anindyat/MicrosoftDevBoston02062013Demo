using _5WebAPIHostedOnIIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _5WebAPIHostedOnIIS.Controllers
{
    public class ProductsController : ApiController
    {
        static List<Product> Products = new List<Product>() { };

        static ProductsController()
        {
            PopulateProductsList();
        }

        private static void PopulateProductsList()
        {
            Products.Add(new Product() { Id = 1, Name = "Table", Price = 200.0m, Category = "Furniture" });
            Products.Add(new Product() { Id = 2, Name = "Chair", Price = 50.0m, Category = "Furniture" });
            Products.Add(new Product() { Id = 2, Name = "Desk", Price = 150.0m, Category = "Furniture" });
        }

        public Product Get(int id)
        {
            return Products.Find(a => a.Id == id);
        }

        public List<Product> GetAll()
        {
            return Products;
        }
    }
}
