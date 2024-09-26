using Entities;
using Services.Abstractions;

namespace MinimalApi.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication AddRouteEndpoints(this WebApplication app)
    {
        app.MapPost("/login", (Login login, ILoginService service) =>
        {
            var result = service.Logar(login);
            return result ? Results.Ok("Login realizado com sucesso.") : Results.Unauthorized();
        });

        app.MapGet("/administrators", (IAdministratorsService service) =>
        {
            try
            {
                var result = service.GetAdministrators();
                return result.Any() ? Results.Ok(result) : Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        });

        return app;
    }
}
