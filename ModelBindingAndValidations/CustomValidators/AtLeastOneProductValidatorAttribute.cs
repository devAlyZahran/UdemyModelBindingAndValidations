using ModelBindingAndValidations.Models;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidations.CustomValidators
{
    public class AtLeastOneProductValidatorAttribute : ValidationAttribute
    {

        public string DefaultErrorMessage { get; set; } = "Order should have at least one product";

        public AtLeastOneProductValidatorAttribute()
        {
            
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not null) 
            {
                List<Product> products = (List<Product>)value;

                if (products.Count == 0)
                {
                    return new ValidationResult(DefaultErrorMessage, new string[] { nameof(validationContext.MemberName) });
                }
                return ValidationResult.Success;
            }
            return null;
        }

    }
}
