using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Entity;

public class OrderDetails
{
    [Key]
    public int Id { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Quantity { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
}
