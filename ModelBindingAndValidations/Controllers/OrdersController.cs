using Microsoft.AspNetCore.Mvc;
using ModelBindingAndValidations.Models;

namespace ModelBindingAndValidations.Controllers
{
    public class OrdersController : Controller
    {

        [Route("/order")]
        [HttpPost]
        public IActionResult Index([Bind(nameof(Order.OrderDate), nameof(Order.InvoicePrice), nameof(Order.Products))] Order order)
        {

            if (!ModelState.IsValid)
            {
                string messages = string.Join("\n", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                return BadRequest(messages);
            }

            Random random = new Random();
            int randomOrderNo = random.Next(1, 99999);

            return Json(new { orderNumber = randomOrderNo});
        }
    }
}
