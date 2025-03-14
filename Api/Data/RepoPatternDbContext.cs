using Microsoft.EntityFrameworkCore;

public class RepoPatternDbContext : DbContext
{
    public RepoPatternDbContext(DbContextOptions options)
    : base(options)
    { }
    public DbSet<User> Users { get; set; }
}
