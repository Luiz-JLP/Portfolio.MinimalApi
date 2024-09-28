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

        app.MapGet("/vehicle", (Vehicle vehicle, IVehiclesService service) =>
        {
            try
            {
                var result = service.Get();
                return result.Any() ? Results.Ok(result) : Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }); 
        
        app.MapGet("/vehicle/id/{id}", (int id, IVehiclesService service) =>
        {
            try
            {
                var result = service.Get(id);
                return result is not null ? Results.Ok(result) : Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }); 
        
        app.MapGet("/vehicle/brand/{brand}", (string brand, IVehiclesService service) =>
        {
            try
            {
                var result = service.Get(brand);
                return result is not null ? Results.Ok(result) : Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        });

        return app;
    }
}
