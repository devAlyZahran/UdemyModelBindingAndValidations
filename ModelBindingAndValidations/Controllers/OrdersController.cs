using Microsoft.AspNetCore.Mvc;
using ModelBindingAndValidations.Models;

namespace ModelBindingAndValidations.Controllers
{
    public class OrdersController : Controller
    {

        [Route("/order")]
        [HttpPost]
        public IActionResult Index(Order order)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Random random = new Random();
            int randomOrderNo = random.Next(1, 99999);

            return Json(new { orderNumber = randomOrderNo});
        }
    }
}
