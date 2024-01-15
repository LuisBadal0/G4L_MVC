using Microsoft.AspNetCore.Mvc;

namespace StoreGWeb.Areas.Customer.Controllers
{
    public class CartController : Controller
    {
        [Area("Customer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
