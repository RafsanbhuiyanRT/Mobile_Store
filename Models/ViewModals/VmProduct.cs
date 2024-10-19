using EcommerceApp.Models.Entity;

namespace EcommerceApp.Models.ViewModals;
#nullable disable
public class VmProduct
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Brand { get; set; }
    public string Modal { get; set; }
    public string Price { get; set; }
    public string Description { get; set; }
    public IFormFile ImagePath { get; set; }
    public int CategoryId { get; set; }
    public int Category { get; set; }
}
