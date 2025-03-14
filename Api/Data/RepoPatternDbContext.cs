using Microsoft.EntityFrameworkCore;

public class RepoPatternDbContext : DbContext
{
    public RepoPatternDbContext(DbContextOptions options)
    : base(options)
    { }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}
