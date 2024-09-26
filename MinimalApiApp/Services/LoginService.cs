using Entities;
using Services.Abstractions;

namespace Services
{
    public class LoginService : ILoginService
    {
        public bool Logar(Login login)
        {
            return login.Email == "adm@teste.com" && login.Senha == "123456";
        }
    }
}
