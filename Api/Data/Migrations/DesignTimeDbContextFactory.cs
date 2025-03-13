using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RepoPatternDbContext>
{
    public RepoPatternDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RepoPatternDbContext>();
        
        optionsBuilder.UseSqlServer(
            "Server=db;Database=YourDbName;User Id=sa;Password=YourStrongPassword123!;",
            b => b.MigrationsAssembly(typeof(RepoPatternDbContext).Assembly.FullName)
        );

        return new RepoPatternDbContext(optionsBuilder.Options);
    }
}