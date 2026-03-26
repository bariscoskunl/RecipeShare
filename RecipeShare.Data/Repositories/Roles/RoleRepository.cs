using Microsoft.EntityFrameworkCore;
using RecipeShare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Data.Repositories.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext _dbContext;

        public RoleRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _dbContext.Set<Role>().ToListAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await _dbContext.Set<Role>().FindAsync(id);
        }
    }
}
