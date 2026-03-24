using Microsoft.EntityFrameworkCore;
using RecipeShare.Data.Entities;

namespace RecipeShare.Data.Repositories.Recipes
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DbContext _dbContext;

        public RecipeRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            return await _dbContext.Set<Recipe>().ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipesByUserId(int userId)
        {
            return await _dbContext.Set<Recipe>().Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task CreateRecipe(Recipe recipe)
        {
            _dbContext.Set<Recipe>().Add(recipe);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            _dbContext.Entry(recipe).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRecipe(int id)
        {
            var recipe = await _dbContext.Set<Recipe>().FindAsync(id);
            if (recipe == null)
            {
                throw new InvalidOperationException($"Id'si {id} olan tarif bulunamadı.");
            }
            _dbContext.Set<Recipe>().Remove(recipe);
            await _dbContext.SaveChangesAsync();
        }
    }
}