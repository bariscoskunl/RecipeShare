using RecipeShare.Business.DTOs;

namespace RecipeShare.Business.Services.Comments
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> GetAllCommentsAsync();
        Task<IEnumerable<CommentDTO>> GetAllCommentsByRecipeAsync(int recipeId);
        Task<CommentDTO?> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(CommentDTO comment);
        Task UpdateCommentAsync(int id, CommentDTO comment);
        Task DeleteCommentAsync(int id);
    }
}