using RecipeShare.Business.DTOs;

namespace RecipeShare.Mvc.Models
{
    public class RecipeDetailsViewModel
    {
        public RecipeDTO Recipe { get; set; }
        public List<CommentDTO> Comments { get; set; }
        
    }
}
