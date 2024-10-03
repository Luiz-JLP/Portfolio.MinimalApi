using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace MinimalApi.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication AddRouteEndpoints(this WebApplication app)
    {
        app.MapPost("/login", async (Login login, ILoginService service) =>
        {
            var result = await service.LogonAsync(login);
            return result ? Results.Ok("Login realizado com sucesso.") : Results.Unauthorized();
        }).WithTags("Login");

        app.MapGet("/administrators", async (IAdministratorsService service) =>
        {
            try
            {
                var result = await service.ReadAsync();
                return result.Any() ? Results.Ok(result) : Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }).WithTags("Administrators");

        app.MapPost("/administrators", async ([FromBody] Administrator administrator, IAdministratorsService service) =>
        {
            try
            {
                var result = await service.CreateAsync(administrator);
                return result is not null ? Results.Ok(result) : Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }).WithTags("Administrators");

        app.MapGet("/vehicle", async (IVehiclesService service) =>
        {
            try
            {
                var result = await service.ReadAsync();
                return result.Any() ? Results.Ok(result) : Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }).WithTags("Vehicles"); 
        
        app.MapGet("/vehicle/id/{id}", async (int id, IVehiclesService service) =>
        {
            try
            {
                var result = await service.ReadAsync(id);
                return result is not null ? Results.Ok(result) : Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }).WithTags("Vehicles"); 
        
        app.MapGet("/vehicle/brand/{brand}", async (string brand, IVehiclesService service) =>
        {
            try
            {
                var result = await service.ReadAsync(brand);
                return result is not null ? Results.Ok(result) : Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }).WithTags("Vehicles");

        app.MapPost("/vehicle", async ([FromBody] Vehicle vehicle, IVehiclesService service) =>
        {
            try
            {
                var result = await service.CreateAsync(vehicle);
                return result is not null ? Results.Ok(result) : Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }).WithTags("Vehicles");

        app.MapPut("/vehicle", async ([FromBody] Vehicle vehicle, IVehiclesService service) =>
        {
            try
            {
                var result = await service.UpdateAsync(vehicle);
                return result is not null ? Results.Ok(result) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }).WithTags("Vehicles");

        app.MapDelete("/vehicle", async ([FromBody] Vehicle vehicle, IVehiclesService service) =>
        {
            try
            {
                var result = await service.DeleteAsync(vehicle);
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
