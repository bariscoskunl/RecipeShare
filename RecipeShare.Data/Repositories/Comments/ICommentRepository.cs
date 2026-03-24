using RecipeShare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Data.Repositories.Comments
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllComments(int recipeId);
        Task<Comment?> GetCommentById(int id);
        Task CreateComment(Comment comment);
        Task UpdateComment(Comment comment);
        Task DeleteComment(int id);
    }
}
