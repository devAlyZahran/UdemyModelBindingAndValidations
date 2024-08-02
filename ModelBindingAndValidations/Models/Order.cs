using ModelBindingAndValidations.CustomValidators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidations.Models
{
    public class Order
    {
        [Required(ErrorMessage = "{0} cannot be empty")]
        [DisplayName("Order Number")]
        public int? OrderNo { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        [DisplayName("Order Date")]
        [OrderDateValidator("2000-01-01", ErrorMessage = "Order Date should be greater than 2000")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        [DisplayName("Invoice Price")]
        [TotalInvoicePriceValidator]
        public double InvoicePrice { get; set; }

        [AtLeastOneProductValidator]
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
