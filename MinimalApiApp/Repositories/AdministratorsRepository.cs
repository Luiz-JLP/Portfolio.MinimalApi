using Entities;
using Repositories.Abstractions;
using Repositories.Context;

namespace Repositories;

public class AdministratorsRepository(InMemoryContext context) : IAdministratorsRepository
{
    public Administrator? GetAdministrator(string email)
    {
        return context.Administrators.Where(x => x.Email.Equals(email)).FirstOrDefault();
    }

    public IEnumerable<Administrator> GetAdministrators()
    {
        return [.. context.Administrators];
    }
}
