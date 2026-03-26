using RecipeShare.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Business.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO?> GetRoleByIdAsync(int id);
    }
}
