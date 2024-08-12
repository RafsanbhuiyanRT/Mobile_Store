using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Entity.UserAddress
{
    public class ProductDetalse
    {
        [Key]
        public int Id { get; set; }
        public string? Supplier { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
      
    }
}
