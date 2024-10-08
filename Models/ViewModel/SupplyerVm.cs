﻿ namespace EcommerceApp.Models.ViewModel;

public class SupplierVm
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public IFormFile? Logo { get; set; }
    public string? LogoPath { get; set;}
}
