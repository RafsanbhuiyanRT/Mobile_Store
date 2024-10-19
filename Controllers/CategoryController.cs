using EcommerceApp.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers;
public class CategoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
