using FlexiSchedule.Infrastructure.Persistence.Repositories;

namespace FlexiSchedule.Infrastructure;
public static class InfrasctructureModule
{
    public static void AddInfrascructure(this IServiceCollection services, string connectionString)
    {
        services
            .AddDatabase(connectionString)
            .AddRepositories();
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<FlexiScheduleSQLServerDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<IProfessionalRepository, ProfessionalRepository>();

        return services;
    }
}
