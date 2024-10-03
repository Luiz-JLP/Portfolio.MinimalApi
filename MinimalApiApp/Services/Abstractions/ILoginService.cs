using Entities;

namespace Services.Abstractions;

public interface ILoginService
{
    Task<bool> LogonAsync(Login login);
}
