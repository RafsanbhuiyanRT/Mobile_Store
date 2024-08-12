using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Entity.UserAddress
{
    public class UserDetails


    {
        [Key]
        public int Id { get; set; }
        public string? Reference { get; set; }
        public string? Phone { get; set; }
        public string? Supplier { get; set; }
        public int OrderNo { get; set; }
        public string? Address { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int UProductDetalseId { get; set; }
       
    }
}
