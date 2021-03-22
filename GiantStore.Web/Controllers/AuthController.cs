using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiantStore.Common.Http;
using GiantStore.Services.Auth;
using GiantStore.Services.Users;
using GiantStore.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiantStore.Web.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private const string InvalidAuthInfoMsg = "Invalid email or password";
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost("api/auth/gett")]
        public IActionResult GetAny()
        {
            return new JsonResult(new { x = 12, y = "dsdads" });
        }

        [HttpPost]
        [Route("api/auth/login")]
        public IActionResult Login([FromBody]LoginDto model)
        {
            if(!ModelState.IsValid || model == null || string.IsNullOrWhiteSpace(model.Email))
            {
                return CommonResponse(1, InvalidAuthInfoMsg);
            }
            try
            {
                var token = _authService.CheckLogin(model.Email, model.Password);
                return CommonResponse(0, token);
            }
            catch
            {
                return CommonResponse(1, InvalidAuthInfoMsg);
            }
        }
    }
}