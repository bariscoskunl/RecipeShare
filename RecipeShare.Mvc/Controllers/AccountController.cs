using Microsoft.AspNetCore.Mvc;

namespace RecipeShare.Mvc.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
