using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Entity.UserAddress
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string? SupplierName { get; set; }
    }
}
