using Entities;
using Services.Abstractions;
using Services.Tools;

namespace Services;

public class LoginService(IAdministratorsService service) : ILoginService
{
    public async Task<bool> LogonAsync(Login login)
    {
        var administrator = await service.ReadAsync(login.Email);

        if (administrator is null)
            return false;

        return PasswordHasher.Verify(login.Password, administrator.Password);
    }
}
