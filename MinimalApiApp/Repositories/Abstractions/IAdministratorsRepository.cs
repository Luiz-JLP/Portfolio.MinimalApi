using Entities;

namespace Repositories.Abstractions;

public interface IAdministratorsRepository
{
    Task<Administrator> CreateAsync(Administrator administrator);

    Task<IEnumerable<Administrator>> ReadAsync();

    Task<Administrator?> ReadAsync(string email);

    Task<bool> VerifyAsync(string email);
}