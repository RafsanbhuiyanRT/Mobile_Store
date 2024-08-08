using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Modal { get; set; }
        public string? Price { get; set; }      
        public string? Description { get; set; }
        public string? Path { get; set; }
        public IFormFile? ImagePath { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
          