namespace RecipeShare.Mvc.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = "Anonim"; // DTO'da yoktu, burada biz yönetiyoruz

       
        public string FirstLetter => !string.IsNullOrEmpty(UserName)
            ? UserName[0].ToString().ToUpper()
            : "U";
    }
}
