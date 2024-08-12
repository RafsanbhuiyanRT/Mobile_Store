using EcommerceApp.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers;
public class ProductController : Controller
{
    public IActionResult Index()  
    {
        return View();
    }
    public ActionResult Create(ProductViewModel model)
    {
        var product = new Product
        {
            Name = model.Name,
        };
        return Ok();
    }
}

public class ProductViewModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Brand { get; set; }
    public string? Modal { get; set; }
    public string? Price { get; set; }
    public string? Description { get; set; }
    public string? Path { get; set; }
    public IFormFile? Image { get; set; }
    public int CategoryId { get; set; }
}
