using System.Collections.Generic;
using System.Linq;

namespace WebApp.Models
{
	public static class ViewModelFactory
	{
		public static ProductViewModel Details(Product prod)
        {
			return new ProductViewModel
			{
				Product = prod,
				Action = "Details",
				ReadOnly = true,
				Theme = "info",
				ShowAction = false,
				Suppliers = prod == null ? Enumerable.Empty<Supplier>() : new List<Supplier> { prod.Supplier },
				Categories = prod == null ? Enumerable.Empty<Category>() : new List<Category> { prod.Category }
			};
        }

		public static ProductViewModel Create(Product product, IEnumerable<Supplier> suppliers,
			IEnumerable<Category> categories)
        {
			return new ProductViewModel
			{
				Product = product,
				Suppliers = suppliers,
				Categories = categories,
				ReadOnly = false
			};
        }

		public static ProductViewModel Edit (Product product, IEnumerable<Supplier> suppliers,
            IEnumerable<Category> categories)
        {
			return new ProductViewModel
			{
				Product = product,
				Suppliers = suppliers,
				Categories = categories,
				Action = "Edit",
				Theme = "warning"
			};
        }

		public static ProductViewModel Delete(Product product, IEnumerable<Supplier> suppliers,
            IEnumerable<Category> categories)
        {
			return new ProductViewModel
			{
				Product = product,
				Action = "Delete",
				ReadOnly = true,
				Theme = "danger",
				Categories = categories,
				Suppliers = suppliers
			};
        }

    }
}

