using Entities;

namespace Services.Abstractions;

public interface IVehiclesService
{
    Task<Vehicle> CreateAsync(Vehicle vehicle);

    Task<IEnumerable<Vehicle>> ReadAsync();

    Task<IEnumerable<Vehicle>> ReadAsync(string brand);

    Task<Vehicle?> ReadAsync(int id);

    Task<Vehicle?> ReadAsync(string name, string brand);

    Task<Vehicle> UpdateAsync(Vehicle vehicle);

    Task<Vehicle> DeleteAsync(Vehicle vehicle);
}
