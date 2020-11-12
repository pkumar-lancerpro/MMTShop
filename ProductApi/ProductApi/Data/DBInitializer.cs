using ProductApi.Models;
using System.Linq;

namespace ProductApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MMTShopContext context)
        {
            context.Database.EnsureCreated();

            // Look for any data exists.
            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Category[]
            {
                new Category{ Name = "Home" },
                new Category{ Name = "Garden" },
                new Category{ Name = "Electronics" },
                new Category{ Name = "Fitness" },
                new Category{ Name = "Toys" }
            };

            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var products = new Product[]
            {
                new Product{SKU=10000, Name="Prod1", CategoryId = 1 },
                new Product{SKU=10001, Name="Prod2", CategoryId = 1 },
                new Product{SKU=20000, Name="Prod3", CategoryId = 2 },
                new Product{SKU=20001, Name="Prod4", CategoryId = 2 },
            };
            foreach (var p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

        }
    }
}