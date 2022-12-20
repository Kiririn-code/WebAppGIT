using System;
using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.Validation
{
	public class PharseAndPriceAttribute : ValidationAttribute
	{
        public string Phrase { get; set; }
        public string Price { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Product product = value as Product;

            if(product != null && product.Name.StartsWith(Phrase,StringComparison.OrdinalIgnoreCase) && product.Price > decimal.Parse(Price))
            {
                return new ValidationResult(ErrorMessage ?? $"{Phrase} products can not cost more than {Price}");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}

