using Microsoft.EntityFrameworkCore;

namespace SecondApp;

public class AplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public AplicationDbContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
    
}