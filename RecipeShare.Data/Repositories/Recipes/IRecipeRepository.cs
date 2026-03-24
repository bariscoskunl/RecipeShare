using RecipeShare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Data.Repositories.Recipes
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAllRecipes();
        Task<IEnumerable<Recipe>> GetRecipesByUserId(int userId);
        Task<Recipe?> GetRecipeById(int id);
        Task CreateRecipe(Recipe recipe);
        Task UpdateRecipe(Recipe recipe);
        Task DeleteRecipe(int id);
    }
}
