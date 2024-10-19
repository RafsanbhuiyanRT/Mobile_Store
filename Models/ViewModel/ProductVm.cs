namespace EcommerceApp.Models.ViewModel
{
    public class ProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Brand { get; set; }
        public string? Modal { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImagePaths { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
