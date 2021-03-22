using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace GiantStore.Services.Auth
{
    public interface IJwtManager
    {
        string GenerateToken(IEnumerable<Claim> claims, DateTime now);
    }
}
