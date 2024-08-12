namespace EcommerceApp.Models.Entity;

public class Order
{
    public int Id { get; set; }
    public string? Reference { get; set; }
    public required string Phone { get; set; }
    public required string OrderNo { get; set; }
    public DateTime CreatedDate { get; set; }
    public int SupplierId { get; set; }
    public Supplier? Supplier { get; set; }
    public int AddressId { get; set; }
    public int ZilaId { get; set; }
    public int ThanaId { get; set; }
    public decimal Total { get; set; }
    public ICollection<OrderDetails> OrderDetails { get; set; } = [];

}
