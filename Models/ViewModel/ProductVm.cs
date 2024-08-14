namespace EcommerceApp.Models.ViewModel
{
    public class ProductVm
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Brand { get; set; }
        public string? Modal { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
        public IFormFile? Image { get; set; }
        public int CategoryId { get; set; }
    }
}
