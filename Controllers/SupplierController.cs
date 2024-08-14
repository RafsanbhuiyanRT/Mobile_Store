using EcommerceApp.Data;
using EcommerceApp.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers;
public class SupplierController(AppDbContext dbContext) : Controller
{
    private AppDbContext _dbContext { get; } = dbContext;
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> CreateAndUpdate(string name, string address, string phone, string email, string logo)
    {
        var sup = await _dbContext.Suppliers.FirstOrDefaultAsync(c => c.Phone == phone);
        if (sup == null)
        {
            var supplier = new Supplier
            {
                Name = name,
                Address = address,
                Phone = phone,
                Email = email,
                Logo = logo
            };
            await _dbContext.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            var data = _dbContext.Suppliers.FirstOrDefault(c => c.Phone == phone);
            if(data is not null)
            {
                var update = data;
                update.Name = name;
                update.Address = address;
                update.Phone = phone;
                update.Email = email;
                update.Logo = logo;
               // _dbContext.Update(update);
                _dbContext.Entry(data).CurrentValues.SetValues(update);
                await _dbContext.SaveChangesAsync();
            }                   
        }
        return Ok();
    }

    [HttpGet]
    public ActionResult<List<Supplier>> GetAllSupplier()
    {
        var supplier = _dbContext.Suppliers.ToList();
        return Ok(supplier);
    }
    [HttpGet]
    public ActionResult GetSupplierById(int id)
    {
        var supplier = _dbContext.Suppliers.FirstOrDefault(x => x.Id == id);
        return Ok(supplier);
    }

    [HttpDelete]
    public ActionResult DeleteSupplier(int id)
    {
        var supplier = _dbContext.Suppliers.FirstOrDefault(x => x.Id == id);
        _dbContext?.Remove(supplier);
        _dbContext?.SaveChanges();
        return Ok();

    }
}

