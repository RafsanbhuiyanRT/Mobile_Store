using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers;
public class ProductController : Controller
{
    public IActionResult Index()  
    {
        return View();
    }
}
