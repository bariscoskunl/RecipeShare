using Microsoft.AspNetCore.Mvc;
using RecipeShare.Mvc.Models;
using RecipeShare.Mvc.Services;
using System.Diagnostics;

namespace RecipeShare.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly RecipeClientService _recipeClientService;

        public HomeController(RecipeClientService recipeClientService)
        {
            _recipeClientService = recipeClientService;
        }

        public async Task<IActionResult> Index()
        {
            var recipeDtos = await _recipeClientService.GetAllRecipesAsync();

            var model = recipeDtos.Select(dto => new RecipeViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Content = dto.Content, 
                CreatedDate = dto.CreatedDate,
                AuthorName = dto.Username,
                ImageUrl = string.IsNullOrEmpty(dto.ImageUrl) ? "/uploads/recipes/default-recipe.jpg" : dto.ImageUrl
            }).OrderByDescending(r => r.CreatedDate).ToList(); 

            return View(model);
        }
    }
}
