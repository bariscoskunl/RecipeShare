using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeShare.Business.DTOs;
using RecipeShare.Business.Services.Users;

namespace RecipeShare.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"Id`si {id} olan kullanici bulunamadi.");
            }
            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> Create(UserDTO userDTO)
        { 
            await _userService.CreateUserAsync(userDTO);
            return Ok(userDTO);     
        }

        // PUT: api/Users
        [HttpPut]
        public async Task<IActionResult> Update(UserDTO userDTO)
        {
            await _userService.UpdateUserAsync(userDTO);
            return Ok(userDTO);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"Id`si {id} olan kullanici bulunamadi.");
            }
            await _userService.DeleteUserAsync(id);
            return Ok(user);
        }
    }
}
