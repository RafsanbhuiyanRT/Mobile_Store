using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models.Entity;

public class Payment
{
    [Key]
    public int Id { get; set; }
    public bool IsSelect { get; set; }
    public string? Invoice { get; set; }
    public string? Product { get; set; }
    public decimal Amount { get; set; }
    public string? Status { get; set; }
}
