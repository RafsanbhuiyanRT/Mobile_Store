using EcommerceApp.Data;
using EcommerceApp.Models.Entity.UserAddress;
using EcommerceApp.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class UserIdentityController : Controller
    {
        private readonly AppDbContext _dbContext;
        public UserIdentityController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(int id, string reference, string phone, string supplier, int orderNo, string address, DateTime dateTime, string item, int quantity, decimal unitprice)
        {
            string message = "";
            var userDetalse = new UserDetalse
            {
                Reference = reference,
                Phone = phone,
                Supplier = supplier,
                OrderNo = orderNo,
                Address = address,
                OrderDate = dateTime,
                ItemName = item,
                Quantity = quantity,
                UnitPrice = unitprice
            };

            await _dbContext.AddAsync(userDetalse);
            await _dbContext.SaveChangesAsync();

            return Ok("Record created successfully"); 
        }

    }
}
