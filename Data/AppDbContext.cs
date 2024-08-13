using EcommerceApp.Models.Entity;
using EcommerceApp.Models.Entity.UserAddress;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Login> Logins { get; set; }
    public DbSet<Signup> Signups { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categorys { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetailes { get; set; }

    public DbSet<Zila> Zilas { get; set; }
    public DbSet<Thana> Thanas { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Category>()
        //    .HasData(
        //        new Category {Id = 1, Name = "Mobile" },
        //        new Category {Id = 2, Name = "Laptop" },
        //        new Category {Id = 3, Name = "Watch" }
        //    );

        base.OnModelCreating(modelBuilder);
    }
}
 