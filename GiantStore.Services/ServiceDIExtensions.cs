using GiantStore.Services.Auth;
using GiantStore.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiantStore.Services
{
    public static class ServiceDIExtensions
    {
        public static void UserGiantStoreServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtManager, JwtManager>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
