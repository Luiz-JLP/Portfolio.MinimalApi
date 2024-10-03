using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstractions;
using Repositories.Context;

namespace Repositories;

public class VehiclesRepository(InMemoryContext context) : IVehiclesRepository
{
    public async Task<Vehicle> CreateAsync(Vehicle vehicle)
    {
        var newVehicle = context.Vehicles.Add(vehicle);
        await context.SaveChangesAsync();
        return newVehicle.Entity;
    }

    public async Task<IEnumerable<Vehicle>> ReadAsync()
    {
        return await context.Vehicles.ToListAsync();
    }

    public async Task<IEnumerable<Vehicle>> ReadAsync(string brand)
    {
        return await context.Vehicles.Where(x => x.Brand.Equals(brand)).ToListAsync();
    }

    public async Task<Vehicle?> ReadAsync(int id)
    {
        return await context.Vehicles.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Vehicle?> ReadAsync(string name, string brand)
    {
        return await context.Vehicles.SingleOrDefaultAsync(x => x.Name.Equals(name) && x.Brand.Equals(brand));
    }

    public async Task<Vehicle> UpdateAsync(Vehicle vehicle)
    {
        var vehicleUpdated = context.Vehicles.Update(vehicle);
        await context.SaveChangesAsync();
        return vehicleUpdated.Entity;
    }

    public async Task<Vehicle> DeleteAsync(Vehicle vehicle)
    {
        var vehicleUpdated = context.Vehicles.Remove(vehicle);
        await context.SaveChangesAsync();
        return vehicleUpdated.Entity;
    }
}
