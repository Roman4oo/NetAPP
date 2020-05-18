using Neoj4.API.Services.DTO_s;
using Neoj4.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoj4.API.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDTO> AuthUser(LoginViewModel loginViewModel);
        Task Create(RegisterViewModel registerViewModel);
    }
}
