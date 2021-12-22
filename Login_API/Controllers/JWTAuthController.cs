using Login_API.Models;
using Login_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class JWTAuthController : ControllerBase
    {
        private readonly IJWTService<Login> loginServ;
        public JWTAuthController(IJWTService<Login> login)
        {
            loginServ = login;
        }
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] Login user)
        {
            string _token = null;
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid client request");
            }
            var result = loginServ.Authenticate(user.Username, user.Password);
            if (result != null)
            {
                _token = loginServ.GetJWTToken(user.EmailId);
            }

            return Ok(new
            {
                email = result.EmailId,
                pasword=result.Password,
                roleId = result.RoleId,
                JWTToken = _token
            });
        }

    }
}
