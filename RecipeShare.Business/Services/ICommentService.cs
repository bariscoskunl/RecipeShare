using RecipeShare.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Business.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> GetAllCommentsAsync(int RecipeId);
        Task<CommentDTO?> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(CommentDTO comment);
        Task UpdateCommentAsync(CommentDTO comment);
        Task DeleteCommentAsync(int id);
    }
}
