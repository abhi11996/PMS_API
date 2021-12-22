using Login_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_API.Services
{
    public class JWTServiceLayer: IJWTService<Login>
    {
        private PMSContext _dbContext;
        public JWTServiceLayer(PMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Login Authenticate(string username, string password)
        {
            Login userModel = new Login();
            userModel = new LoginDBO(_dbContext).VerifyLogin(username, password);
            return userModel;
        }

        public string GetJWTToken(string username)
        {
            var token = new JWTHelper().GetJWTToken(username);
            return token;
        }
    }
}
