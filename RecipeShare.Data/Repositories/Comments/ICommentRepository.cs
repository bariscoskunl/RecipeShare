using RecipeShare.Data.Entities;

namespace RecipeShare.Data.Repositories.Comments
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task<IEnumerable<Comment>> GetAllCommentsByRecipeAsync(int recipeId);
        Task<Comment?> GetCommentById(int id);
        Task CreateComment(Comment comment);
        Task UpdateComment(Comment comment);
        Task DeleteComment(int id);
    }
}