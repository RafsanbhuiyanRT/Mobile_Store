using EcommerceApp.Data;
using EcommerceApp.Models.Entity;
using EcommerceApp.Models.ViewModel;
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
    //public async Task<ActionResult> CreateAndUpdate(string name, string address, string phone, string email, string logo)
    public async Task<ActionResult> CreateAndUpdate([FromForm]SupplierVm vm, [FromServices] IWebHostEnvironment webHost)
    {
        var sup = await _dbContext.Suppliers.FirstOrDefaultAsync(c => c.Phone == vm.Phone);
        var filePath = FileUpload(webHost, vm.Logo);
        if (sup == null)
        { 
            var supplier = new Supplier
            {
                Name = vm.Name,
                Address = vm.Address,
                Phone = vm.Phone,
                Email = vm.Email,
                Logo = filePath
            };
            await _dbContext.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            var data = _dbContext.Suppliers.FirstOrDefault(c => c.Phone == vm.Phone);
            if(data is not null)
            {
                var update = data;
                update.Name = vm.Name;
                update.Address = vm.Address;
                update.Phone = vm.Phone;
                update.Email = vm.Email;
                update.Logo = filePath;
               // _dbContext.Update(update);
                _dbContext.Entry(data).CurrentValues.SetValues(update);
                await _dbContext.SaveChangesAsync();
            }                   
        }
        return Ok();
    }

    [HttpGet]
    public ActionResult<List<SupplierVm>> GetAllSupplier()
    {
        var supplier = _dbContext.Suppliers
            .Select(s => new SupplierVm
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Phone = s.Phone,
                Email = s.Email,
                LogoPath = s.Logo
            })
            .ToList();
        return Ok(supplier);
    }

    [HttpGet]
    public ActionResult<SupplierVm> GetSupplierById(int id)
    {
        var supplier = _dbContext.Suppliers.FirstOrDefault(x => x.Id == id);

        if(supplier is not null)
        {
            var sup = new SupplierVm
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Address = supplier.Address,
                Phone = supplier.Phone,
                Email = supplier.Email,
                LogoPath = supplier.Logo
            };
            return Ok(sup);
        }
        return Ok(new SupplierVm());
    }

    [HttpDelete]
    public ActionResult DeleteSupplier(int id)
    {
        var supplier = _dbContext.Suppliers.FirstOrDefault(x => x.Id == id);
        _dbContext?.Remove(supplier);
        _dbContext?.SaveChanges();
        return Ok();

    }
    [NonAction]
    private static string FileUpload(IWebHostEnvironment _webHostEnvironment, IFormFile? file, string path = "")
    {
        if(file is null)
        {
            return string.Empty;
        }
        var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "Upload");
        if (path != null)
        {
            uploadPath = Path.Combine(uploadPath, path);
        }
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }
        var filePath = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
        filePath = Path.Combine(uploadPath, filePath);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }
        var contentRootPath = _webHostEnvironment.ContentRootPath;
        var relativePath = filePath.Replace(contentRootPath, "");
        return relativePath.Replace(@"\wwwroot", "").Replace(@"\", "/");
    }
   
}

