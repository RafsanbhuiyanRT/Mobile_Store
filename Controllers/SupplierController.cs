using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers;
public class SupplierController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
