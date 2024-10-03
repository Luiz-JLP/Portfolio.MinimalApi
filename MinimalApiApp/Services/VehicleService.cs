using Entities;
using Repositories.Abstractions;
using Services.Abstractions;

namespace Services;

public class VehicleService(IVehiclesRepository repository) : IVehiclesService
{
    public async Task<Vehicle> CreateAsync(Vehicle vehicle)
    {
        return await repository.CreateAsync(vehicle);
    }

    public async Task<IEnumerable<Vehicle>> ReadAsync()
    {
        return await repository.ReadAsync();
    }

    public async Task<IEnumerable<Vehicle>> ReadAsync(string brand)
    {
        return await repository.ReadAsync(brand);
    }

    public async Task<Vehicle?> ReadAsync(int id)
    {
        return await repository.ReadAsync(id);
    }

    public async Task<Vehicle?> ReadAsync(string name, string brand)
    {
        return await repository.ReadAsync(name, brand);
    }

    public async Task<Vehicle> UpdateAsync(Vehicle vehicle)
    {
        return await repository.UpdateAsync(vehicle);
    }

    public async Task<Vehicle> DeleteAsync(Vehicle vehicle)
    {
        return await repository.DeleteAsync(vehicle);
    }
}
