using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using WebApp.Validation;

namespace WebApp.Models
{
    //[PharseAndPrice(Phrase ="Small",Price ="100")]
	public class Product
	{
        public long ProductId { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        [Required(ErrorMessage = "Please enter a price")]
        [Range(1, 999999, ErrorMessage = "please enter a positive price")]
        public decimal Price { get; set; }
        [PrimaryKey(ContextType =typeof(DataContext), DataType =typeof(Category))]
        //[Remote("CategoryKey", "Validation", ErrorMessage ="Enter an existing key")]
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        [PrimaryKey(ContextType =typeof(DataContext), DataType = typeof(Category))]
        //[Remote("SupplierKey", "Validation", ErrorMessage = "Enter an existing key")]
        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}

