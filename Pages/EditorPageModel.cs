using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Pages
{
	public class EditorPageModel : PageModel
	{
		public EditorPageModel(DataContext dbContext)
		{
			Context = dbContext;
		}

        public DataContext Context { get; set; }
		public IEnumerable<Supplier> Suppliers => Context.Suppliers;
		public IEnumerable<Category> Categories => Context.Categories;
		public ProductViewModel ViewModel { get; set; }

		public async Task CheckNewCategory(Product product)
        {
			if(product.CategoryId == -1 && !string.IsNullOrEmpty(product.Category?.Name))
            {
				Context.Categories.Add(product.Category);
				await Context.SaveChangesAsync();
				product.CategoryId = product.Category.CategoryId;
				ModelState.Clear();
				TryValidateModel(product);
            }
        }
    }
}

