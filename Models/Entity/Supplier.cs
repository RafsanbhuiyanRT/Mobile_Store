using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Entity
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }
        public string? Logo { get; set; }
    }
}
