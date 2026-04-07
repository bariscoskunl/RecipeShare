using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeShare.Business.DTOs;
using RecipeShare.Mvc.Services;

namespace RecipeShare.Mvc.Controllers
{
    public class CommentController : Controller
    {

        private readonly CommentClientService _commentClientService;

        public CommentController(CommentClientService commentClientService)
        {
            _commentClientService = commentClientService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CommentDTO commentDTO)
        {           
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                commentDTO.UserId = int.Parse(userIdClaim.Value);
            }
         
            commentDTO.CreatedDate = DateTime.Now;
          
            if (!ModelState.IsValid)
            {               
                return BadRequest(ModelState);
            }

            var result = await _commentClientService.CreateCommentAsync(commentDTO);

            if (result)
            {
                return Ok(); 
            }

            return BadRequest("Yorum kaydedilemedi.");

        }
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var comment = await _commentClientService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit([FromBody] CommentDTO commentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _commentClientService.UpdateCommentAsync(commentDTO.Id, commentDTO);

            if (result)
            {
                return Ok();
            }

            return BadRequest("Güncelleme başarısız.");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> Delete(int id, int recipeId)
        {            
            var result = await _commentClientService.DeleteCommentAsync(id);
            if (result) return Ok();

            return BadRequest();
        }
    }
}
