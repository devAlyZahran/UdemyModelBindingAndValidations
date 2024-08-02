using ModelBindingAndValidations.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelBindingAndValidations.CustomValidators
{
    public class TotalInvoicePriceValidatorAttribute : ValidationAttribute
    {

        public string DefaultErrorMessage { get; set; } = "The invoice total price should be equal to total cost of all products";

        public TotalInvoicePriceValidatorAttribute()
        {
            
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));
                if (otherProperty != null)
                {
                    List<Product> products = (List<Product>)otherProperty.GetValue(validationContext.ObjectInstance)!;
                    //calculate total price
                    double totalPrice = 0;
                    foreach (Product product in products)
                    {
                        totalPrice += product.Price * product.Quantity;
                    }

                    //value of "InvoicePrice" property
                    double actualPrice = (double)value;

                    if (totalPrice > 0)
                    {
                        //if the value of "InvoicePrice" property is not equal to the total cost of all products in the order
                        if (totalPrice != actualPrice)
                        {
                            //return model error
                            return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, totalPrice), new string[] { nameof(validationContext.MemberName) });
                        }
                    }
                    else
                    {
                        //return model error is no products found
                        return new ValidationResult("No products found to validate invoice price", new string[] { nameof(validationContext.MemberName) });
                    }

                    //No validation error
                    return ValidationResult.Success;
                }
                else 
                    return null;
            }
            return null;
        }

    }
}
