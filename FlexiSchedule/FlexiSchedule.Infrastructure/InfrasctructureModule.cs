namespace FlexiSchedule.Infrastructure;
public static class InfrasctructureModule
{
    public static void AddInfrascructure(this IServiceCollection services)
    {
        string connectionString = Environment.GetEnvironmentVariable("CS_SQLSERVER_FLEXI_SCHEDULE") ?? throw new NullReferenceException();

        services
            .AddDatabase(connectionString);
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<FlexiScheduleSQLServerDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}
