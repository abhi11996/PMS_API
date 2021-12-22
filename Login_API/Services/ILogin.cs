using Login_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_API.Services
{
   public interface ILogin
    {
        List<Login> GetAllLogins();

        //IActionResult CreateLogins(Login login);

        //IActionResult UpdateLogins(Login login);
        //IActionResult DeleLogins(int User_Id);

    }
}
