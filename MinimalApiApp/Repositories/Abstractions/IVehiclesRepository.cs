using Entities;

namespace Repositories.Abstractions;

public interface IVehiclesRepository
{
    Vehicle Create(Vehicle vehicle);

    Vehicle Delete(Vehicle vehicle);

    IEnumerable<Vehicle> Get();

    Vehicle? Get(int id);

    IEnumerable<Vehicle> Get(string brand);

    Vehicle? Get(string name, string brand);

    Vehicle Update(Vehicle vehicle);
}