using Login_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_API.Services
{
    public class LoginDBO
    {

        private PMSContext _dbContext;
        public LoginDBO(PMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Login VerifyLogin(string email, string password)
        {
            Login user = new Login();
            try

            { 
                user = _dbContext.Login.Where(e => e.EmailId == email && e.Password == password).Select(e => new Login
                {
                    EmailId = e.EmailId,
                    RoleId = e.RoleId,
                    Password=e.Password

                }).FirstOrDefault();

            }
            catch (Exception ex)
            {

            }
            return user;
        }
    }
}
