using Microsoft.AspNetCore.Mvc;
using RecipeShare.Mvc.Models;
using RecipeShare.Mvc.Services;

namespace RecipeShare.Mvc.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeClientService _recipeClientService;

        public RecipeController(RecipeClientService recipeClientService)
        {
            _recipeClientService = recipeClientService;
        }

        public async Task<IActionResult> Details(int id)
        { 
           var dto = await _recipeClientService.GetRecipeByIdAsync(id);
            
           if (dto == null)
           {
               return NotFound();
           }

            var model = new RecipeViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Content = dto.Content,
                CreatedDate = dto.CreatedDate,
                AuthorName = dto.Username
            };

            return View(model);           
        }
    }
}
