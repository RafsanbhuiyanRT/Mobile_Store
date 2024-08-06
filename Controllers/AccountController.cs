using EcommerceApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class AccountController(AppDbContext db) : Controller
    {
        public IActionResult LoginIndex()
        {
            return View();
        }
        public IActionResult SignUpIndex()
        {
            return View();
        }
    }
}
