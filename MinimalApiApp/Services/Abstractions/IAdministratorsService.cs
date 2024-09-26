using Entities;

namespace Services.Abstractions;

public interface IAdministratorsService
{
    Administrator? GetAdministrator(string email);

    IEnumerable<Administrator> GetAdministrators();
}