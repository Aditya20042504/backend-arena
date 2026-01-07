using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products {get; set;}
    public AppDbContext(DbContextOptions<AppDbContext> DbContextOptions): base(DbContextOptions)
    {
        
    }
}