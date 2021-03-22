using GiantStore.Services.Users;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace GiantStore.Services.Auth
{
    class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IJwtManager _jwtManager;

        public AuthService(IUserService userService, IJwtManager jwtManager) {
            _userService = userService;
            _jwtManager = jwtManager;
        }
        public string CheckLogin(string email, string password)
        {
            var user = _userService.GetByEmail(email);
            if(user == null)
            {
                throw new Exception("User is not found!");
            }
            // Verify Password
            if(!string.Equals(user.Password, password, StringComparison.InvariantCulture))
            {
                throw new Exception("Invalid password!");
            }

            // Here email & password is valid then we can issue a JWT token
            // Information need to put into JWT token (Claim), this info may be use to identify user (eg: Id or email)
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, $"{user.FirstName} ${user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            //-----------------------------
            // Simple version
            //-----------------------------
            //var now = DateTime.UtcNow;
            //var jwtToken = new JwtSecurityToken(
            //    issuer: "giant.store.dev",
            //    audience: "giant.store.dev",
            //    claims: claims,
            //    notBefore: now,
            //    expires: now.AddMinutes(30),
            //    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));
            //var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            // Generate JWT token
            var token = _jwtManager.GenerateToken(claims, DateTime.UtcNow);
            return token;
        }
    }
}
