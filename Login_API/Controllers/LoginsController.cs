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
    public class LoginsController : ControllerBase
    {
        private PMSContext _dbContext;
        private readonly ILogin _loginServices;


        //private readonly LoginService _loginServices;

        public LoginsController(ILogin loginServ)
        {
            _loginServices = loginServ;
        }

        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            try
            {
                var logins = _loginServices.GetAllLogins();
                if (logins.Count == 0)
                {
                    return StatusCode(404, "no user found");
                }
                return Ok(logins);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

        }

        //public LoginsController(PMSContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //[HttpGet("GetUsers")]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        var logins = _dbContext.Login.ToList();
        //        if (logins.Count == 0)
        //        {
        //            return StatusCode(404, "no user found");
        //        }
        //        return Ok(logins);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "An error has occured");
        //    }

        //}
    }
}
