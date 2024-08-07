using EcommerceApp.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Login> Logins { get; set; }
    public DbSet<Signup> Signups { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categorys { get; set; }
       
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasData(
                new Category { Name = "Mobile" },
                new Category {  Name = "Laptop" },
                new Category {  Name = "Watch" }
            );

        base.OnModelCreating(modelBuilder);
    }
}
 