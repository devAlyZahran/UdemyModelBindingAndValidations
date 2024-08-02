using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelBindingAndValidations.CustomValidators
{
    public class OrderDateValidatorAttribute : ValidationAttribute
    {

        public string DefaultErrorMessage { get; set; } = "Order date should be greater than or equal to {0}";
        public DateTime MinimumDate { get; set; }

        public OrderDateValidatorAttribute(string minimumDateString) 
        {
            MinimumDate = Convert.ToDateTime(minimumDateString);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // check if the order date is null
            if (value != null)
            {
                DateTime orderDate = (DateTime)value;

                if (orderDate < MinimumDate)
                {
                    return new ValidationResult(
                        string.Format( ErrorMessage ?? DefaultErrorMessage, MinimumDate.ToString("yyyy-MM-dd")), 
                        new string[] { nameof(validationContext.MemberName) }
                    );
                }
                return ValidationResult.Success;
            }
            return null;
        }

    }
}
