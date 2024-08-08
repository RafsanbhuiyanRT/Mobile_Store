using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class UserIdentityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
