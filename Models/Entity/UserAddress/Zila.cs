using EcommerceApp.Models.Enums;
using Microsoft.CodeAnalysis.Options;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Entity.UserAddress
{
    public class Zila
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public required Division Division { get; set; }
        public ICollection<Thana> Thanas { get; set; } = [];
    }
}
