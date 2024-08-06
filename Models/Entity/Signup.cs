namespace EcommerceApp.Models.Entity
{
    public class Signup
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public bool Condition { get; set; }
    }
}
