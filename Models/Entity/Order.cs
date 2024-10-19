using EcommerceApp.Models.Entity.UserAddress;
using EcommerceApp.Models.Enums;

namespace EcommerceApp.Models.Entity;

public class Order
{
    public int Id { get; set; }
    public string? Reference { get; set; }
    public string Phone { get; set; }
    public string OrderNo { get; set; }
    public DateTime CreatedDate { get; set; }
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
    public int DivisionId { get; set; }
    public Division Division { get; set; }
    public int ZilaId { get; set; }
    public Zila Zila { get; set; }
    public int ThanaId { get; set; }
    public Thana Thana { get; set; }
    public decimal Total { get; set; }
  
    public ICollection<OrderDetails> OrderDetails { get; set; } = [];

}
