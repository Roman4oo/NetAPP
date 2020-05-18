using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoj4.API.Services.Abstract
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool CheckMatch(string password, string hashedPassword);

    }
}
