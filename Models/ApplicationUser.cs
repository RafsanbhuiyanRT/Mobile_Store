using Microsoft.AspNetCore.Identity;

namespace EcommerceApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime RegistationDate { get; set; }
        public string? Name { get; set; }
        public string? UserType { get; set; }
        public int EntityId { get; set; }
        public bool IsActive { get; set; }
    }
}
