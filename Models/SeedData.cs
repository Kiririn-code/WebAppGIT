using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
	public class SeedData
	{
		public static void SeedDatabase(DataContext context)
        {
			context.Database.Migrate();
            if (context.Products.Count() == 0
				&& context.Suppliers.Count() == 0
				&& context.Categories.Count() == 0)
            {
				Supplier s1 = new Supplier { Name = "Splash Dudes", City = "San Jose" };
				Supplier s2 = new Supplier { Name = "Soccer Town", City = "Chocago" };
				Supplier s3 = new Supplier { Name = "Chess Co", City = "New York" };
				Category c1 = new Category { Name = "Watersports"};
				Category c2 = new Category { Name = "Soccer"};
				Category c3 = new Category { Name = "Chess"};
				context.Products.AddRange(
					new Product { Name = "Kayak", Category = c1, Supplier = s1, Price = 275 },
					new Product { Name = "Lifejacket", Category = c1, Supplier = s1, Price = 19.50m },
					new Product { Name = "Soccer ball", Price = 19.50m, Category = c2, Supplier = s2 },
					new Product { Name = "Corner Flags", Price = 34.59m, Category = c2, Supplier = s2 },
					new Product { Name = "Stadium", Price = 79500, Category = c2, Supplier = s2 },
					new Product { Name = "Thinking Cap", Price = 16, Category = c3, Supplier = s3 },
					new Product { Name = "Unsteady Chair", Price = 29.95m, Category = c3, Supplier = s3 },
					new Product { Name = "Human chess board", Price = 75, Category = c3, Supplier = s3 },
					new Product { Name = "Bling-Bling king", Price = 1200, Category = c3, Supplier = s3 });
				context.SaveChanges();
			}
		}
	}
}

