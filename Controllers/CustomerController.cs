using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
