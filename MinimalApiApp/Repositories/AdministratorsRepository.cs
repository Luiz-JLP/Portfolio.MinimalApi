using Entities;
using Repositories.Abstractions;
using Repositories.Context;

namespace Repositories;

public class AdministratorsRepository(InMemoryContext context) : IAdministratorsRepository
{
    public IEnumerable<Administrator> GetAdministrators()
    {
        return [.. context.Administrators];
    }
}
