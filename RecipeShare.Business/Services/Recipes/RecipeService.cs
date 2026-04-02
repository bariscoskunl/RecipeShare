using RecipeShare.Business.DTOs;
using RecipeShare.Data.Entities;
using RecipeShare.Data.Repositories.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Business.Services.Recipes
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public async Task<IEnumerable<RecipeDTO>> GetAllRecipesAsync()
        {
           var recipes = await _recipeRepository.GetAllRecipes();
            return recipes.Select(r => new RecipeDTO
            { 
                Id = r.Id,
                Title = r.Title,
                Content = r.Content,
                CreatedDate = r.CreatedDate,
                ImageUrl = r.ImageUrl, 
                UserId = r.UserId,
                Username = r.User != null ? r.User.Username : "Bilinmeyen Yazar"
            }).ToList();    
        }

        public async Task<RecipeDTO?> GetRecipeByIdAsync(int id)
        {           
            var recipe = await _recipeRepository.GetRecipeById(id);

            if (recipe == null)
            {
                return null; 
            }

            return new RecipeDTO
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Content = recipe.Content,
                CreatedDate = recipe.CreatedDate,
                ImageUrl = recipe.ImageUrl,
                UserId = recipe.UserId,
                Username = recipe.User != null ? recipe.User.Username : "Bilinmeyen Yazar"
            };
        }
        public async Task<IEnumerable<RecipeDTO>> GetRecipesByUserIdAsync(int userId)
        {
            var recipe = await _recipeRepository.GetRecipesByUserId(userId);
            return recipe.Select(r => new RecipeDTO
            {
                Id = r.Id,
                Title = r.Title,
                Content = r.Content,
                CreatedDate = r.CreatedDate,
                ImageUrl = r.ImageUrl,
                UserId = r.UserId
            }).ToList();
        }
        public async Task CreateRecipeAsync(RecipeDTO recipe)
        {
            var newRecipe = new Recipe
            {                
                Title = recipe.Title,
                Content = recipe.Content,
                CreatedDate = DateTime.Now,
                UserId = recipe.UserId,
                ImageUrl = recipe.ImageUrl ?? "/images/default-recipe.jpg"
            };
            await _recipeRepository.CreateRecipe(newRecipe);
        }
        public async Task UpdateRecipeAsync(RecipeDTO recipe)
        {
            var existingRecipe = await _recipeRepository.GetRecipeById(recipe.Id);
            if (existingRecipe != null)
            {

                existingRecipe.Title = recipe.Title;
                existingRecipe.Content = recipe.Content;
                existingRecipe.UserId = recipe.UserId;
                existingRecipe.ImageUrl = recipe.ImageUrl ?? existingRecipe.ImageUrl;

                await _recipeRepository.UpdateRecipe(existingRecipe);

            }           
        }
        public async Task DeleteRecipeAsync(int id)
        {
            var existingRecipe = await _recipeRepository.GetRecipeById(id);
            if (existingRecipe != null)
            {
                await _recipeRepository.DeleteRecipe(id);
            }            
        }

      
    }
}
