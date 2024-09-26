using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Context;

namespace Repositories.Startup;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<InMemoryContext>();

        if (context is not null)
        {
            context.Database.EnsureCreated();

            if (!context.Administrators.Any())
            {
                context.Administrators.Add(
                    new Administrator()
                    {
                        Email = "adm@email.com",
                        Password = "10CAA770D62E55DCAE6A753AD66B2213F6C6B65010D0E4AB74394DBA9B14041B-D4C7779B062D8D5799F7567CA19FF41A",
                        Profile = "adm"
                    }
                );

                context.SaveChanges();
            }
        }

        return app;
    }
}
