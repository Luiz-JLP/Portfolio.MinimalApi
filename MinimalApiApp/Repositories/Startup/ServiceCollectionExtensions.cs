using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Context;

namespace Repositories.Startup
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataBaseContext(this IServiceCollection services)
        {
            services.AddDbContext<InMemoryContext>(options => options.UseInMemoryDatabase("Minimal"));
            return services;
        }
    }
}
