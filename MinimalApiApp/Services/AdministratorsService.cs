using Entities;
using Repositories.Abstractions;
using Services.Abstractions;

namespace Services;

public class AdministratorsService(IAdministratorsRepository repository) : IAdministratorsService
{
    public IEnumerable<Administrator> GetAdministrators()
    {
        return repository.GetAdministrators();
    }
}
