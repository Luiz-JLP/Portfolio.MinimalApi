using Entities;

namespace Repositories.Abstractions;

public interface IAdministratorsRepository
{
    IEnumerable<Administrator> GetAdministrators();
}