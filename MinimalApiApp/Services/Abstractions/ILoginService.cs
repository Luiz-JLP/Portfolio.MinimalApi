﻿using Domain;

namespace Services.Abstractions
{
    public interface ILoginService
    {
        bool Logar(Login login);
    }
}
