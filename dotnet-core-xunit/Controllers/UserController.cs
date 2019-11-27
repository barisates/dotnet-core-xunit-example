using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_core_xunit.Dtos;
using dotnet_core_xunit.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace dotnet_core_xunit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "dotnet-core-xunit-example", $"v{GetType().Assembly.GetName().Version.ToString()}", });
        }


        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            UserDto.User user = _userService.GetUser(id);

            if (user == null)
                return BadRequest("User not found!");

            return Ok(user);
        }


        [HttpPost]
        public IActionResult AddUser([FromBody]UserDto.User userInfo)
        {
            UserDto.User user = _userService.AddUser(userInfo);

            if (user == null)
                return BadRequest("Failed to add user!");

            return Ok(user);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UserDto.User user = _userService.DeleteUser(id);

            if (user == null)
                return BadRequest("Failed to delete user!");

            return Ok(user);
        }
    }
}
