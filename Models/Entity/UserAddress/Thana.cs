using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Entity.UserAddress
{
    public class Thana
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public required int ZilaId { get; set; }
        public required Zila Zila { get; set; }
    }
}
