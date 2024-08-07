using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Entity
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
