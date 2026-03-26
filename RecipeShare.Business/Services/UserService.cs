using RecipeShare.Business.DTOs;
using RecipeShare.Data.Entities;
using RecipeShare.Data.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
           var users =await _userRepository.GetAllUsers();
            return users.Select(u => new UserDTO
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                PasswordHash = u.PasswordHash,
                RoleId = u.RoleId,
                RoleName = u.Role.Name,

            }).ToList();
        }
        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
           var user = await _userRepository.GetUserById(id);
            if (user == null)
            { 
                return null;
            }
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                RoleId = user.RoleId,
                RoleName = user.Role.Name

            };            
        }
        public async Task CreateUserAsync(UserDTO user)
        {
            var newUser = new User
            {               
                Username = user.Username,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                RoleId = 2
            };
            await _userRepository.CreateUser(newUser);
        }
        public async Task UpdateUserAsync(UserDTO user)
        {
            var existingUser = await _userRepository.GetUserById(user.Id);
            if (existingUser != null)
            {
                existingUser.Email = user.Email;
                existingUser.Username = user.Username;
                existingUser.PasswordHash = user.PasswordHash;  
                await _userRepository.UpdateUser(existingUser);
            }
        }
        public async Task DeleteUserAsync(int id)
        {
            var existingUser = await _userRepository.GetUserById(id);
            if (existingUser != null)
            { 
                await _userRepository.DeleteUser(existingUser.Id);
            }            
        }
    }
}
