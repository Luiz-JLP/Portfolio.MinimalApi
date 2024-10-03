using Entities;
using Repositories.Abstractions;
using Services.Abstractions;
using Services.Tools;

namespace Services;

public class AdministratorsService(IAdministratorsRepository repository) : IAdministratorsService
{
    public async Task<Administrator> CreateAsync(Administrator administrator)
    {
        if (await repository.VerifyAsync(administrator.Email))
            throw new ArgumentException("O e-mail já está cadastrado.");

        var password = PasswordHasher.Hash(administrator.Password);
        administrator.Password = password;

        return await repository.CreateAsync(administrator);
    }

    public async Task<IEnumerable<Administrator>> ReadAsync()
    {
        return await repository.ReadAsync();
    }

    public async Task<Administrator?> ReadAsync(string email)
    {
        return await repository.ReadAsync(email);
    }
}
