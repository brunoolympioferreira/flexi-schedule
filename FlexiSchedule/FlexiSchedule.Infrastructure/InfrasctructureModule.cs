namespace FlexiSchedule.Infrastructure;
public static class InfrasctructureModule
{
    public static void AddInfrascructure(this IServiceCollection services, string connectionString)
    {
        services
            .AddDatabase(connectionString)
            .AddRepositories()
            .AddUnityOfWork();
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
            .AddScoped<IProfessionalRepository, ProfessionalRepository>()
            .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>()
            .AddScoped<IAddressRepository, AddressRepository>()
            .AddScoped<IClientRepository, ClientRepository>()
            .AddScoped<IAvailabilityRepository, AvailabilityRepository>();

        return services;
    }

    private static IServiceCollection AddUnityOfWork(this IServiceCollection services)
    {
        return services.AddScoped<IUnitOfWork, UnityOfWork>();
    }
}
