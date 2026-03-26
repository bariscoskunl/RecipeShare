using RecipeShare.Business.DTOs;
using RecipeShare.Data.Repositories.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Business.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return roles.Select(r => new RoleDTO
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();
        }

        public async Task<RoleDTO?> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null) return null;

            return new RoleDTO
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
