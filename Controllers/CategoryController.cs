using EcommerceApp.Data;
using EcommerceApp.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

    [HttpGet]
    public ActionResult GetCategoryById(int id) { 
        var category = _dbContext.Categorys.FirstOrDefault(x => x.Id == id);
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

    [HttpPost]
    public async Task<ActionResult> Update(int id, string name, string description)
    {
        var category = await _dbContext.Categorys.FirstOrDefaultAsync(c => c.Id == id);
        if (category is not null) {
            category.Name = name;
            category.Description = description;

            _dbContext.Update(category);
            _dbContext.SaveChanges();
        }     
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(int id) {
        var catagory = _dbContext.Categorys.ToList();
        _dbContext.Remove(catagory);
        _dbContext.SaveChanges();
        return Ok();
    }

    [HttpGet]
    public ActionResult GetDropDownCategory()
    {
        var category = _dbContext.Categorys
                    .Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = $"{s.Id}"
                    }).ToList();
        return Ok(category);
    }

}
