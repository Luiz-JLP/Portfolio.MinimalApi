using Services;
using Services.Abstractions;

namespace MinimalApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<ILoginService, LoginService>();

            return services;
        }
    }
}
