using EcommerceApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Entity.UserAddress
{
    public class Zila
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public Division Division { get; set; }
    }
}
