using EcommerceApp.Models.Entity;
using EcommerceApp.Models.ViewModals;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using System.Text.Json;
using EcommerceApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers;
public class ProductController(AppDbContext db) : Controller
{
    private readonly AppDbContext _db = db;

    public IActionResult Index()  
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(VmProduct vm)
    {
        var product = new Product
        {
            ProductName = vm.ProductName,
            Brand = vm.Brand,
            Modal = vm.Modal,
            Price = vm.Price,
            Description = vm.Description,
            ImagePath =  "",
            CategoryId = vm.CategoryId,

        };
        await _db.Products.AddAsync(product);
        await _db.SaveChangesAsync();
        return Ok();
    }
    [HttpGet]
    public async Task<ActionResult> GetAllProduct()
    {
        var response = (from p in _db.Products
                       join c in _db.Categorys on p.CategoryId equals c.Id
                       select new
                       {
                           ProductName = p.ProductName,
                           Brand = p.Brand,
                           Modal = p.Modal,
                           price = p.Price,
                           Description = p.Description,
                           Category = c.Name
                       }).ToList();
                      
        return Ok(response);               
    }
    [HttpPost]
    public async Task<ActionResult> SaveProduct(InvoiceVm vm)
    {
        var url = new Uri("https://localhost:7041/api/Products/SaveProduct");
        
        using var client = new HttpClient();
        var jsonData = JsonSerializer.Serialize(vm);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = client.PostAsync(url, content);

        return Ok(vm);
    }
}


