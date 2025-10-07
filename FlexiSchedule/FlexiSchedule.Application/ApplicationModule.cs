using FlexiSchedule.Application.Services.Cache;
using FlexiSchedule.Application.Services.Client.WriteOnly.Update;

namespace FlexiSchedule.Application;
public static class ApplicationModule
{
    public static void AddApplication(this IServiceCollection services)
    {
        services
            .AddServices()
            .AddValidators()
            .AddAuthServices();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services
            .AddScoped<ICreateProfessionalService, CreateProfessionalService>()
            .AddScoped<IUpdateProfessionalService, UpdateProfessionalService>()
            .AddScoped<IProfessionalReadOnlyService, ProfessionalReadOnlyService>()
            .AddScoped<IRemoveProfessionalService, RemoveProfessionalService>()
            .AddScoped<IAddressService, AddressService>()
            .AddScoped<ICreateClientService, CreateClientService>()
            .AddScoped<IClientReadOnlyService, ClientReadOnlyService>()
            .AddScoped<ICacheService, CacheService>()
            .AddScoped<IUpdateClientService, UpdateClientService>();
        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services
            .AddScoped<ProfessionalValidator>();

        return services;
    }

    private static IServiceCollection AddAuthServices(this IServiceCollection services)
    {
        services
            .AddScoped<IJwtService, JwtService>()
            .AddScoped<IAuthService, AuthService>();

        return services;
    }
}
