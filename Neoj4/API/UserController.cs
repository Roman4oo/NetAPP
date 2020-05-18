using Microsoft.AspNetCore.Mvc;
using Neoj4.API.Services.Abstract;
using Neoj4.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoj4.API
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("api/createuser")]
        public async Task<IActionResult> Create([FromBody]RegisterViewModel registerViewModel)
        {
            var user = _userService.Create(registerViewModel);
            return Ok(user);
        }


        [HttpGet("api/getuserbyname")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginViewModel loginViewModel)
        {
            var user = await _userService.AuthUser(loginViewModel);
            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
