using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeShare.Business.DTOs;
using RecipeShare.Business.Services.Recipes;

namespace RecipeShare.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: api/Recipe
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var recipes = await _recipeService.GetAllRecipesAsync();
            return Ok(recipes);
        }
        // GET: api/Recipe/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // DİKKAT: _recipeService içinde bu metodun (GetRecipeByIdAsync) yazılı olması lazım!
            var recipe = await _recipeService.GetRecipeByIdAsync(id);

            if (recipe == null)
            {
                return NotFound($"Id'si {id} olan tarif bulunamadı.");
            }

            return Ok(recipe);
        }

        // GET: api/Recipe/user/5     
        [HttpGet("user/{userId}")]       
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var recipes = await _recipeService.GetRecipesByUserIdAsync(userId);
                       
            if (recipes == null || !recipes.Any())
            {
                return NotFound($"Id'si {userId} olan kullanıcıya ait tarif bulunamadı.");
            }
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeDTO recipeDTO)
        {
            await _recipeService.CreateRecipeAsync(recipeDTO);
            return Ok(recipeDTO);
        }

        [HttpPut]
        public async Task<IActionResult> Update(RecipeDTO recipeDTO)
        {
            await _recipeService.UpdateRecipeAsync(recipeDTO);
            return Ok(recipeDTO);
        }

        // DELETE: api/Recipe/5     
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {          
            await _recipeService.DeleteRecipeAsync(id);
            return Ok($"Id'si {id} olan tarif silindi.");
        }
    }
}