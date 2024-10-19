using EcommerceApp.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EcommerceApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Get()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("");
            var result = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<Payment>>(result);

            return Ok(result);
        }

        public async Task<ActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpGet]
        public JsonResult GetPayments()
        {
            var payments = new List<Payment>
                 {
                     new() { Id = 1, Invoice = "INV-001", Product = "Product A", Amount = 100.00m, Status = "Paid", IsSelect = false },
                     new() { Id = 2, Invoice = "INV-002", Product = "Product B", Amount = 150.00m, Status = "Pending", IsSelect = false },
                     new() { Id = 3, Invoice = "INV-003", Product = "Product C", Amount = 200.00m, Status = "Paid", IsSelect = false },
                     new() { Id = 4, Invoice = "INV-004", Product = "Product D", Amount = 100.00m, Status = "Paid", IsSelect = false },
                     new() { Id = 5, Invoice = "INV-005", Product = "Product E", Amount = 150.00m, Status = "Pending", IsSelect = false },
                     new() { Id = 6, Invoice = "INV-006", Product = "Product F", Amount = 200.00m, Status = "Paid", IsSelect = false },
                     new() { Id = 7, Invoice = "INV-007", Product = "Product G", Amount = 100.00m, Status = "Paid", IsSelect = false },
                     new() { Id = 8, Invoice = "INV-008", Product = "Product H", Amount = 150.00m, Status = "Pending", IsSelect = false },
                     new() { Id = 9, Invoice = "INV-009", Product = "Product I", Amount = 200.00m, Status = "Paid", IsSelect = false },
                     new() { Id = 10, Invoice = "INV-001", Product = "Product A", Amount = 100.00m, Status = "Paid", IsSelect = false },
                     new() { Id = 11, Invoice = "INV-002", Product = "Product B", Amount = 150.00m, Status = "Pending", IsSelect = false },
                     new() { Id = 12, Invoice = "INV-003", Product = "Product C", Amount = 200.00m, Status = "Paid", IsSelect = false },
                     new() { Id = 13, Invoice = "INV-004", Product = "Product D", Amount = 100.00m, Status = "Paid", IsSelect = false },
                     new() { Id = 14, Invoice = "INV-005", Product = "Product E", Amount = 150.00m, Status = "Pending", IsSelect = false },
                     new() { Id = 15, Invoice = "INV-006", Product = "Product F", Amount = 200.00m, Status = "Paid", IsSelect = false },
                     new() { Id = 16, Invoice = "INV-007", Product = "Product G", Amount = 100.00m, Status = "Paid", IsSelect = false },
                     new() { Id = 17, Invoice = "INV-008", Product = "Product H", Amount = 150.00m, Status = "Pending", IsSelect = false },
                     new() { Id = 18, Invoice = "INV-009", Product = "Product I", Amount = 200.00m, Status = "Paid", IsSelect = false }
                 };
            return Json(payments);
        }
    }
}
