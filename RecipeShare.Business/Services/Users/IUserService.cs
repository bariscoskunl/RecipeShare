using RecipeShare.Business.DTOs;
using RecipeShare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Business.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task CreateUserAsync(UserDTO user);
        Task UpdateUserAsync(UserDTO user);
        Task DeleteUserAsync(int id);
    }
}
