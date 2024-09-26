using Entities;
using Repositories.Abstractions;
using Repositories.Context;

namespace Repositories;

public class VehiclesRepository(InMemoryContext context) : IVehiclesRepository
{
    public Vehicle Create(Vehicle vehicle)
    {
        var newVehicle = context.Vehicles.Add(vehicle);
        context.SaveChangesAsync();
        return newVehicle.Entity;
    }

    public IEnumerable<Vehicle> Get()
    {
        return [.. context.Vehicles];
    }

    public IEnumerable<Vehicle> Get(string brand)
    {
        return [.. context.Vehicles.Where(x => x.Brand.Equals(brand))];
    }

    public Vehicle? Get(int id)
    {
        return context.Vehicles.SingleOrDefault(x => x.Id == id);
    }

    public Vehicle? Get(string name, string brand)
    {
        return context.Vehicles.SingleOrDefault(x => x.Name.Equals(name) && x.Brand.Equals(brand));
    }

    public Vehicle Update(Vehicle vehicle)
    {
        var vehicleUpdated = context.Vehicles.Update(vehicle);
        context.SaveChangesAsync();
        return vehicleUpdated.Entity;
    }

    public Vehicle Delete(Vehicle vehicle)
    {
        var vehicleUpdated = context.Vehicles.Remove(vehicle);
        context.SaveChangesAsync();
        return vehicleUpdated.Entity;
    }
}
