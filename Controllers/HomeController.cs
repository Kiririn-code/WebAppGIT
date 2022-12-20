using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Filters;
using WebApp.Models;

namespace WebApp.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private DataContext context;

        private IEnumerable<Category> Categories => context.Categories;
        private IEnumerable<Supplier> Suppliers => context.Suppliers;


        public HomeController(DataContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View(context.Products.Include(c => c.Category).Include(s => s.Supplier));
        }

        public async Task<IActionResult> Details(long id)
        {
            Product product = await context.Products.Include(p => p.Category)
                .Include(p => p.Supplier).FirstOrDefaultAsync(p => p.ProductId == id);
            ProductViewModel model = ViewModelFactory.Details(product);
            return View("ProductEditor", model);
        }

        public IActionResult Create()
        {
            return View("ProductEditor", ViewModelFactory.Create(new Product(), Suppliers, Categories));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductId = default;
                product.Category = default;
                product.Supplier = default;
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("ProductEditor", ViewModelFactory.Create(product, Suppliers, Categories));
        }

        public async Task<IActionResult> Edit(long id)
        {
            Product product = await context.Products.FindAsync(id);
            ProductViewModel model = ViewModelFactory.Edit(product, Suppliers, Categories);
            return View("ProductEditor", model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Category = default;
                product.Supplier = default;
                context.Products.Update(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("ProductEditor", ViewModelFactory.Edit(product, Suppliers, Categories));
        }

        public async Task<IActionResult> Delete(long id)
        {
            Product product = await context.Products.FindAsync(id);
            ProductViewModel model = ViewModelFactory.Delete(product, Suppliers, Categories);
            return View("ProductEditor", model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

