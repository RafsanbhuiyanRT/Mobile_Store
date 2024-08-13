using EcommerceApp.Data;
using EcommerceApp.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers;
public class CategoryController(AppDbContext dbContext) : Controller
{
    private readonly AppDbContext _dbContext = dbContext;
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public ActionResult<List<Category>> GetAllCategory()
    {
        var category = _dbContext.Categorys.ToList();
        return Ok(category);
    }
    [HttpPost]
    public async Task<ActionResult> Create(string name, string description)
    {
        var category = new Category
        { 
            Name = name,
            Description = description 
        };
       await _dbContext.AddAsync(category);
       await _dbContext.SaveChangesAsync();

        return Ok();
    }
}
