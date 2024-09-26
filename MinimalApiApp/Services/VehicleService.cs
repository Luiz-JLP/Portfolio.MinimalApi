using Entities;
using Repositories.Abstractions;
using Services.Abstractions;

namespace Services;

public class VehicleService(IVehiclesRepository repository) : IVehiclesService
{
    public Vehicle Create(Vehicle vehicle)
    {
        return repository.Create(vehicle);
    }

    public Vehicle Delete(Vehicle vehicle)
    {
        return repository.Delete(vehicle);
    }

    public IEnumerable<Vehicle> Get()
    {
        return repository.Get();
    }

    public Vehicle? Get(int id)
    {
        return repository.Get(id);
    }

    public IEnumerable<Vehicle> Get(string brand)
    {
        return repository.Get(brand);
    }

    public Vehicle? Get(string name, string brand)
    {
        return repository.Get(name, brand);
    }

    public Vehicle Update(Vehicle vehicle)
    {
        return repository.Update(vehicle);
    }
}
