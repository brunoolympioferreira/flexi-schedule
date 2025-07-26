using FlexiSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FlexiSchedule.Infrastructure.Persistence;
public class FlexiScheduleSQLServerDbContext : DbContext
{
    public FlexiScheduleSQLServerDbContext(DbContextOptions<FlexiScheduleSQLServerDbContext> options) : base(options) { }

    public DbSet<Professional> Professionals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
