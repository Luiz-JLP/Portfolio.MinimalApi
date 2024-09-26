using Entities;
using Services.Abstractions;

namespace MinimalApi.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication AddRouteEndpoints(this WebApplication app)
        {
            app.MapPost("/login", (Login login, ILoginService service) =>
            {
                var result = service.Logar(login);
                return result ? Results.Ok("Login realizado com sucesso.") : Results.Unauthorized();
            });

            return app;
        }
    }
}
