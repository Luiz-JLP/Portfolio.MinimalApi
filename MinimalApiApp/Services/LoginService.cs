using Entities;
using Services.Abstractions;
using Services.Tools;

namespace Services;

public class LoginService(IAdministratorsService service) : ILoginService
{
    public bool Logar(Login login)
    {
        var administrator = service.GetAdministrator(login.Email);

        if (administrator is null)
            return false;

        return PasswordHasher.Verify(login.Senha, administrator.Password);
    }
}
