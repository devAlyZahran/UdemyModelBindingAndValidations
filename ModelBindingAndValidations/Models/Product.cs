using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidations.Models
{
    public class Product
    {
        [Required(ErrorMessage = "{0} cannot be empty")]
        [DisplayName("Product Code")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        [DisplayName("Product Price")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        [DisplayName("Product Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public int Quantity { get; set; }

    }
}
