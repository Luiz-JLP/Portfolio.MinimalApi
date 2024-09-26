using Entities;

namespace Repositories.Abstractions;

public interface IAdministratorsRepository
{
    Administrator? GetAdministrator(string email);

    IEnumerable<Administrator> GetAdministrators();
}