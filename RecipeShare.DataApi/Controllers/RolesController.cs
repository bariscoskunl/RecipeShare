using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeShare.Business.Services;

namespace RecipeShare.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound($"Id'si {id} olan rol bulunamadı.");
            }
            return Ok(role);
        }
    }
}
