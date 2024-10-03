using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstractions;
using Repositories.Context;

namespace Repositories;

public class AdministratorsRepository(InMemoryContext context) : IAdministratorsRepository
{

    public async Task<Administrator> CreateAsync(Administrator administrator)
    {
        var newAdministrator = context.Administrators.Add(administrator);
        await context.SaveChangesAsync();
        return newAdministrator.Entity;
    }

    public async Task<IEnumerable<Administrator>> ReadAsync()
    {
        return await context.Administrators.ToListAsync();
    }

    public async Task<Administrator?> ReadAsync(string email)
    {
        return await context.Administrators.SingleOrDefaultAsync(x => x.Email.Equals(email));
    }

    public async Task<bool> VerifyAsync(string email)
    {
        return await context.Administrators.AllAsync(x => x.Email.Equals(email));
    }
}
