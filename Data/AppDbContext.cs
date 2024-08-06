using EcommerceApp.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Login> Logins { get; set; }
    public DbSet<Signup> Signups { get; set; }
}
 