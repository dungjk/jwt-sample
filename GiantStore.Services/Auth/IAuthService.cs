using System;
using System.Collections.Generic;
using System.Text;

namespace GiantStore.Services.Auth
{
    public interface IAuthService
    {
        string CheckLogin(string email, string password);
    }
}
