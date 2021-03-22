using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiantStore.Common.Http;
using GiantStore.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiantStore.Web.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }

        // Note: [Authorize] can be put into controller => All endpoint in controller will require Authorization
        [Authorize] // Require send JWT Token to access this endpoint
        [HttpGet("api/users")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return CommonResponse(0, users);
        }

        [Authorize] // Require send JWT Token to access this endpoint
        [HttpGet("api/user/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var user = _userService.GetByEmail(email);
            if(user == null)
            {
                return CommonResponse(404, "User is not found");
            }

            return CommonResponse(0, user);
        }
    }
}