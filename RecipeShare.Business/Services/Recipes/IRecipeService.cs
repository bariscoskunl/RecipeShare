using RecipeShare.Business.DTOs;
using RecipeShare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Business.Services.Recipes
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDTO>> GetAllRecipesAsync();
        Task<RecipeDTO> GetRecipeByIdAsync(int id);
        Task<IEnumerable<RecipeDTO>> GetRecipesByUserIdAsync(int userId);
        Task CreateRecipeAsync(RecipeDTO recipe);
        Task UpdateRecipeAsync(RecipeDTO recipe);
        Task DeleteRecipeAsync(int id);
    }
}
