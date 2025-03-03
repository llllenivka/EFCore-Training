using FirstApp;
using Microsoft.EntityFrameworkCore;
 
public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public ApplicationDbContext()
    {
        Database.EnsureCreated();    
    } 
    
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}