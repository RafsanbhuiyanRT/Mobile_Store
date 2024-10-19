using EcommerceApp.Data;
using EcommerceApp.Models.Entity;
using EcommerceApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers;
public class ProductController(AppDbContext dbContext) : Controller
{
    private readonly AppDbContext _dbContext = dbContext;
    public IActionResult Index()  
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create([FromForm]ProductVm vm, [FromServices]IWebHostEnvironment webHost)
    {
        
        var imageFile = webHost.FileUpload(vm.Image);
        var product = new Product
        {
            Id = vm.Id,
            Name = vm.Name,
            Brand = vm.Brand,
            Modal = vm.Modal,
            Price = vm.Price,
            Description = vm.Description,
            ImagePath = imageFile,
            CategoryId = vm.CategoryId,
        };
        //if(vm.Image is not null)
        //{
        //    product.ImagePath = imageFile;
        //}
        await _dbContext.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        
        return Ok();
    }
    [HttpGet]
    public JsonResult GetDropdownProduct()
    {
        var product = _dbContext.Products
            .Select(x => new
            {
                x.Id,
                x.Name,
                x.Price
            }).ToList();
        return Json(product);
    }
    [HttpGet]
    public ActionResult<List<ProductVm>> GetAll() {
        var product = _dbContext.Products
            .Include(X => X.Category)
            .Select(p => new ProductVm
            {
                Id = p.Id,
                Name = p.Name,
                Brand = p.Brand,
                Modal = p.Modal,
                Price = p.Price,
                Description = p.Description,
                ImagePaths = p.ImagePath,
                CategoryName = p.Category!.Name!
            });
        var str = product.ToQueryString();
        return Ok(product);
    }
}

