namespace FlexiSchedule.Infrastructure.Persistence;
public class FlexiScheduleSQLServerDbContext : DbContext
{
    public FlexiScheduleSQLServerDbContext(DbContextOptions<FlexiScheduleSQLServerDbContext> options) : base(options) { }

    public DbSet<Professional> Professionals { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
