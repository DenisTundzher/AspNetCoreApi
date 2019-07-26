using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoParkCoreApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromForm]User userParam)
        {
            var user = _userService.UserAuthenticate(userParam);

            if (user == null)
                return BadRequest(new { message = "UserName or password is incorrect" });

            return Ok(user);
        }


        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult SignUp([FromForm] User user)
        {
            bool response = _userService.AddUser(user);

            return Ok(response);
        }
    }
}