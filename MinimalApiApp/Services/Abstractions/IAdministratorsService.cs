using Entities;

namespace Services.Abstractions;

public interface IAdministratorsService
{
    IEnumerable<Administrator> GetAdministrators();
}