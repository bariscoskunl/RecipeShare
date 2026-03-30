using RecipeShare.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Business.Services.Auth
{
    public interface ITokenService
    {
        public string CreateToken(UserDTO userDTO);
    }
}
