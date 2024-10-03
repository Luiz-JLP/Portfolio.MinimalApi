using Entities;

namespace Services.Abstractions;

public interface IAdministratorsService
{
    Task<Administrator> CreateAsync(Administrator administrator);

    Task<IEnumerable<Administrator>> ReadAsync();

    Task<Administrator?> ReadAsync(string email);
}