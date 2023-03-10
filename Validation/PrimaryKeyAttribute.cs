using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Validation
{
	public class PrimaryKeyAttribute : ValidationAttribute
	{
        public Type ContextType { get; set; }
        public Type DataType { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DbContext context = validationContext.GetService(ContextType) as DbContext;
            if(context.Find(DataType,value) == null)
            {
                return new ValidationResult(ErrorMessage ?? "Enter a existing key value");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}

