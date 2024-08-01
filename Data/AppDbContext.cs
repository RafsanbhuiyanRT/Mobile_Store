using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

}
 