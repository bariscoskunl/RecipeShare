using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeShare.Business.DTOs;
using RecipeShare.Business.Services.Auth;
using RecipeShare.Business.Services.Users;

namespace RecipeShare.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var users = await _userService.GetAllUsersAsync();
            var user = users.FirstOrDefault(u => u.Email == loginDTO.Email && u.PasswordHash == loginDTO.Password);

            if (user == null)
            {
                return Unauthorized("E-posta veya şifre yanlış.");
            }
            var token = _tokenService.CreateToken(user);
            return Ok(new 
            {
                Token = token,
                UserName = user.Username,
                Role = user.RoleName
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            var users = await _userService.GetAllUsersAsync();

            var existingUser = users.FirstOrDefault(u => u.Email == registerDto.Email || u.Username == registerDto.Username);

            if (existingUser != null)
            {                
                if (existingUser.Email == registerDto.Email)
                {
                    return BadRequest("Bu e-posta adresi zaten kullanımda.");
                }
                if (existingUser.Username == registerDto.Username)
                {
                    return BadRequest("Bu kullanıcı adı zaten alınmış. Lütfen başka bir tane dene.");
                }
            }


            var userDto = new UserDTO
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = registerDto.Password,
                RoleId = 2 
            };

            await _userService.CreateUserAsync(userDto);
            return Ok("Kayıt başarıyla tamamlandı.");
        }
    }
}
