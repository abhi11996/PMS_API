using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_API.Services
{
    public interface IJWTService<TEntity> where TEntity : class
    {
        TEntity Authenticate(string username, string password);
        string GetJWTToken(string username);
    }
}
