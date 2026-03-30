using RecipeShare.Business.DTOs;
using RecipeShare.Data.Entities;
using RecipeShare.Data.Repositories.Comments;

namespace RecipeShare.Business.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<CommentDTO>> GetAllCommentsAsync()
        {
            // Veritabanındaki tüm yorumları çekip DTO'ya çeviriyoruz
            var comments = await _commentRepository.GetAllCommentsAsync();
            return comments.Select(c => new CommentDTO
            {
                Id = c.Id,
                Text = c.Text,
                UserId = c.UserId,
                RecipeId = c.RecipeId
            }).ToList();
        }

        public async Task<IEnumerable<CommentDTO>> GetAllCommentsByRecipeAsync(int recipeId)
        {
            var comments = await _commentRepository.GetAllCommentsByRecipeAsync(recipeId);
            return comments.Select(c => new CommentDTO
            {
                Id = c.Id,
                Text = c.Text,
                UserId = c.UserId,
                RecipeId = c.RecipeId
            }).ToList();
        }

        public async Task<CommentDTO?> GetCommentByIdAsync(int id)
        {
            var comment = await _commentRepository.GetCommentById(id);
            if (comment == null)
            {
                return null;
            }
            return new CommentDTO
            {
                Id = comment.Id,
                Text = comment.Text,
                UserId = comment.UserId,
                RecipeId = comment.RecipeId
            };
        }

        public async Task CreateCommentAsync(CommentDTO comment)
        {
            var newComment = new Comment
            {
                Text = comment.Text,
                UserId = comment.UserId,
                RecipeId = comment.RecipeId
            };
            await _commentRepository.CreateComment(newComment);
        }

        public async Task UpdateCommentAsync(int id, CommentDTO comment)
        {
            var existingComment = await _commentRepository.GetCommentById(id);
            if (existingComment != null)
            {
                existingComment.Text = comment.Text;
                existingComment.UserId = comment.UserId;
                existingComment.RecipeId = comment.RecipeId;

                await _commentRepository.UpdateComment(existingComment);
            }
        }

        public async Task DeleteCommentAsync(int id)
        {
            var existingComment = await _commentRepository.GetCommentById(id);
            if (existingComment != null)
            {
                await _commentRepository.DeleteComment(existingComment.Id);
            }
        }
    }
}