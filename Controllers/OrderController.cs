using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
