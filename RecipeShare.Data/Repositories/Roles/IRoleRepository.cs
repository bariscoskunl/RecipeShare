using RecipeShare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Data.Repositories.Roles
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByIdAsync(int id);
    }
}
