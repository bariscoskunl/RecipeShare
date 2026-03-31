using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeShare.Business.DTOs;
using RecipeShare.Mvc.Models;
using RecipeShare.Mvc.Services;
using System.Security.Claims;

namespace RecipeShare.Mvc.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeClientService _recipeClientService;

        public RecipeController(RecipeClientService recipeClientService)
        {
            _recipeClientService = recipeClientService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var dto = await _recipeClientService.GetRecipeByIdAsync(id);

            if (dto == null)
            {
                return NotFound();
            }

            var model = new RecipeViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Content = dto.Content,
                CreatedDate = dto.CreatedDate,
                AuthorName = dto.Username
            };

            return View(model);
        }
      
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(RecipeDTO recipeDTO)
        {
            recipeDTO.UserId = GetLoggedInUserId();
            if (!ModelState.IsValid)
            {
                return View(recipeDTO);
            }
            bool isSuccess = await _recipeClientService.CreateRecipeAsync(recipeDTO);

            if (isSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Tarif eklenirken API ile iletişim kurulamadı.");
                return View(recipeDTO);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _recipeClientService.GetRecipeByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            System.Diagnostics.Debug.WriteLine("---------------------------------------");
            System.Diagnostics.Debug.WriteLine($"TARİF SAHİBİ ID (API'DEN GELEN): {dto.UserId}");
            System.Diagnostics.Debug.WriteLine($"GİRİŞ YAPAN KULLANICI ID (MVC'DEN): {GetLoggedInUserId()}");
            System.Diagnostics.Debug.WriteLine("---------------------------------------");

            if (dto.UserId != GetLoggedInUserId())
            {
                return RedirectToAction("AccessDenied", "Account");
            }
            return View(dto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(RecipeDTO recipeDTO)
        {
           
            recipeDTO.UserId = GetLoggedInUserId();
            if (!ModelState.IsValid)
            {
                return View(recipeDTO);
            }
            bool isSuccess = await _recipeClientService.UpdateAsync(recipeDTO);
            if (isSuccess)
            {
                return RedirectToAction("Details", new { id = recipeDTO.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Tarif güncellenirken API ile iletişim kurulamadı.");
                return View(recipeDTO);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _recipeClientService.GetRecipeByIdAsync(id);

            if (dto == null) return NotFound();

            if (dto.UserId != GetLoggedInUserId())
            {
                TempData["ErrorMessage"] = "Sadece kendi tariflerinizi silebilirsiniz!";
                return RedirectToAction("Index", "Home");
            }

            bool isSuccess = await _recipeClientService.DeleteAsync(id);

            if (isSuccess)
            {               
                TempData["SuccessMessage"] = "Tarif başarıyla silindi.";
            }
            else
            {
                TempData["ErrorMessage"] = "Tarif silinirken bir hata oluştu.";
            }

            return RedirectToAction("Index", "Home");
        }
        private int GetLoggedInUserId()
        {
            // Kimlik kartındaki (Claims) NameIdentifier alanını bul
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            { 
                return userId;
            }
            return 0;// Hala 0 geliyorsa giriş yapılmamış veya Claim okunmamış demektir
        }
    }
}