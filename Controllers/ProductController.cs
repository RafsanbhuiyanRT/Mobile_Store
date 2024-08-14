using EcommerceApp.Models.Entity;
using EcommerceApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers;
public class ProductController : Controller
{
    public IActionResult Index()  
    {
        return View();
    }
    public ActionResult Create(ProductVm model)
    {
        var product = new Product
        {
            Name = model.Name,
        };
        return Ok();
    }
}

