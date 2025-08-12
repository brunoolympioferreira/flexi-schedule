namespace FlexiSchedule.Application;
public static class ApplicationModule
{
    public static void AddApplication(this IServiceCollection services)
    {
        services
            .AddServices();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services
            .AddScoped<ICreateProfessionalService, CreateProfessionalService>();

        return services;
    }
}
