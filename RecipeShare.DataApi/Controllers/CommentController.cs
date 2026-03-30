using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeShare.Business.DTOs;
using RecipeShare.Business.Services.Comments;

namespace RecipeShare.DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentService.GetAllCommentsAsync();
            return Ok(comments);
        }

        // GET: api/Comment/recipe/5       
        [HttpGet("recipe/{recipeId}")]
        public async Task<IActionResult> GetAllByRecipe(int recipeId)
        {
            var comments = await _commentService.GetAllCommentsByRecipeAsync(recipeId);
            return Ok(comments);
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCommentId(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound($"Id'si {id} olan yorum bulunamadı.");
            }
            return Ok(comment);
        }

        // POST: api/Comment
        [HttpPost]
        public async Task<IActionResult> Create(CommentDTO commentDTO)
        {
            await _commentService.CreateCommentAsync(commentDTO);
            return Ok("Yorum başarıyla eklendi.");
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CommentDTO commentDTO)
        {
            if (id != commentDTO.Id)
            {
                return BadRequest("URL'deki ID ile güncellenmek istenen yorumun ID'si eşleşmiyor.");
            }

            var existingComment = await _commentService.GetCommentByIdAsync(id);
            if (existingComment == null)
            {
                return NotFound($"Güncellenmek istenen Id'si {id} olan yorum bulunamadı.");
            }

            await _commentService.UpdateCommentAsync(id, commentDTO);
            return Ok("Yorum başarıyla güncellendi.");
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingComment = await _commentService.GetCommentByIdAsync(id);
            if (existingComment == null)
            {
                return NotFound($"Silinmek istenen Id'si {id} olan yorum bulunamadı.");
            }

            await _commentService.DeleteCommentAsync(id);
            return Ok("Yorum başarıyla silindi.");
        }
    }
}