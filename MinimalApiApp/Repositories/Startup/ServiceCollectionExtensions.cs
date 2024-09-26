using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Abstractions;
using Repositories.Context;

namespace Repositories.Startup;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataBaseContext(this IServiceCollection services)
    {
        services.AddDbContext<InMemoryContext>(options => options.UseInMemoryDatabase("Minimal"));
        return services;
    }

    public static IServiceCollection AddRepositoryDependency(this IServiceCollection services)
    {
        services.AddScoped<IAdministratorsRepository, AdministratorsRepository>();
        services.AddScoped<IVehiclesRepository, VehiclesRepository>();

        return services;
    }
}
