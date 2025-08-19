namespace FlexiSchedule.Application;
public static class ApplicationModule
{
    public static void AddApplication(this IServiceCollection services)
    {
        services
            .AddServices()
            .AddValidators();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services
            .AddScoped<ICreateProfessionalService, CreateProfessionalService>()
            .AddScoped<IUpdateProfessionalService, UpdateProfessionalService>()
            .AddScoped<IProfessionalReadOnlyService, ProfessionalReadOnlyService>();
        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services
            .AddScoped<ProfessionalValidator>();

        return services;
    }
}
