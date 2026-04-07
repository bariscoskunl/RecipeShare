using RecipeShare.Business.DTOs;

namespace RecipeShare.Mvc.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty; 
        public string AuthorName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public string? ImageUrl { get; set; }

        public IFormFile? ImageFile { get; set; }

        public List<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();

        // --- Detay İçin Eklenen "Akıllı" Özellikler ---

        // İçeriğin sadece ilk 100 karakterini alıp sonuna ... ekler
        public string ShortDescription => Content.Length > 100
            ? Content.Substring(0, 100) + "..."
            : Content;

        public string FormattedDate => CreatedDate.ToString("dd MMM yyyy");

       
    }
}