using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Entity
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
