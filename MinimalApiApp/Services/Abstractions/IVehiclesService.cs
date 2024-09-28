using Entities;

namespace Services.Abstractions;

public interface IVehiclesService
{
    Vehicle Create(Vehicle vehicle);

    Vehicle Delete(Vehicle vehicle);

    IEnumerable<Vehicle> Get();

    Vehicle? Get(int id);

    IEnumerable<Vehicle> Get(string brand);

    Vehicle Update(Vehicle vehicle);
}
