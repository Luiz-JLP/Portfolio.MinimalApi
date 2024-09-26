using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions;

namespace Services.Startup;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceDependency(this IServiceCollection services)
    {
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IAdministratorsService, AdministratorsService>();

        return services;
    }
}
