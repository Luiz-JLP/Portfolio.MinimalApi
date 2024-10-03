using Entities;
using Microsoft.AspNetCore.Mvc;
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
        }).WithTags("Login");

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
        }).WithTags("Administrators");

        app.MapGet("/vehicle", (IVehiclesService service) =>
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
        }).WithTags("Vehicles"); 
        
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
        }).WithTags("Vehicles"); 
        
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
        }).WithTags("Vehicles");

        app.MapPost("/vehicle", ([FromBody] Vehicle vehicle, IVehiclesService service) =>
        {
            try
            {
                var result = service.Create(vehicle);
                return result is not null ? Results.Ok(result) : Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }).WithTags("Vehicles");

        app.MapPut("/vehicle", ([FromBody] Vehicle vehicle, IVehiclesService service) =>
        {
            try
            {
                var result = service.Update(vehicle);
                return result is not null ? Results.Ok(result) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }).WithTags("Vehicles");

        app.MapDelete("/vehicle", ([FromBody] Vehicle vehicle, IVehiclesService service) =>
        {
            try
            {
                var result = service.Delete(vehicle);
                return result is not null ? Results.Ok(result) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }).WithTags("Vehicles");

        return app;
    }
}
