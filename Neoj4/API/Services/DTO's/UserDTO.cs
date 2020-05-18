using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoj4.API.Services.DTO_s
{
    public class UserDTO
    {
        public string Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string HashPassword { get; set; }

    }
}
