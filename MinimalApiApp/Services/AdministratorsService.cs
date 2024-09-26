using Entities;
using Repositories.Abstractions;
using Services.Abstractions;

namespace Services;

public class AdministratorsService(IAdministratorsRepository repository) : IAdministratorsService
{
    public Administrator? GetAdministrator(string email)
    {
        return repository.GetAdministrator(email);
    }

    public IEnumerable<Administrator> GetAdministrators()
    {
        return repository.GetAdministrators();
    }
}
