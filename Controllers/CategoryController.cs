using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers;
public class CategoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
