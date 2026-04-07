using Microsoft.EntityFrameworkCore;
using RecipeShare.Data.Entities;

namespace RecipeShare.Data.Repositories.Comments
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DbContext _dbContext;

        public CommentRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Yeni eklenen: Tüm yorumları getirir
        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            return await _dbContext.Set<Comment>().ToListAsync();
        }

        // İsmi güncellenen: Sadece ilgili tarifin yorumlarını getirir
        public async Task<IEnumerable<Comment>> GetAllCommentsByRecipeAsync(int recipeId)
        {
            return await _dbContext.Set<Comment>().Include(c => c.User).Where(c => c.RecipeId == recipeId).ToListAsync();
        }

        public async Task<Comment?> GetCommentById(int id)
        {
            return await _dbContext.Set<Comment>().FindAsync(id);
        }

        public async Task CreateComment(Comment comment)
        {
            _dbContext.Set<Comment>().Add(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateComment(Comment comment)
        {
            _dbContext.Entry(comment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteComment(int id)
        {
            var comment = await _dbContext.Set<Comment>().FindAsync(id);
            if (comment == null)
            {
                throw new InvalidOperationException($"Id'si {id} olan yorum bulunamadı.");
            }
            _dbContext.Set<Comment>().Remove(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}