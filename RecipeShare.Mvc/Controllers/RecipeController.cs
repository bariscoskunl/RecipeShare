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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly CommentClientService _commentClientService;

        public RecipeController(RecipeClientService recipeClientService, IWebHostEnvironment webHostEnvironment, CommentClientService commentClientService)
        {
            _recipeClientService = recipeClientService;
            _webHostEnvironment = webHostEnvironment;
            _commentClientService = commentClientService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var dto = await _recipeClientService.GetRecipeByIdAsync(id);
            if (dto == null) return NotFound();

           
            var commentDtos = await _commentClientService.GetCommentsByRecipeIdAsync(id);

            var model = new RecipeViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Content = dto.Content,
                CreatedDate = dto.CreatedDate,
                AuthorName = dto.Username,
                ImageUrl = dto.ImageUrl,
              
                Comments = commentDtos.Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    Text = c.Text,
                    CreatedDate = c.CreatedDate ?? DateTime.Now,
                    UserId = c.UserId ?? 0,
                    UserName = c.Username ?? "Ziyaretçi"
                }).ToList()
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
        [DisableRequestSizeLimit]
        [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        public async Task<IActionResult> Create(RecipeDTO recipeDTO, IFormFile imageFile)
        {
            recipeDTO.UserId = GetLoggedInUserId();

            ModelState.Remove(nameof(RecipeDTO.ImageUrl)); // ImageUrl doğrulamasını kaldır


            if (!ModelState.IsValid)
            {
                return View(recipeDTO);
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                recipeDTO.ImageUrl = await UploadImageAsync(imageFile);
            }
            else
            {
                recipeDTO.ImageUrl = "/uploads/recipes/default-recipe.jpg";
            }

            try
            {
                bool isSuccess = await _recipeClientService.CreateRecipeAsync(recipeDTO);

                if (isSuccess)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tarif eklenirken bir hata oluştu. Lütfen tekrar deneyin.");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Tarif eklenirken bir hata oluştu. Lütfen tekrar deneyin.");
            }
            return View(recipeDTO);
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

            if (dto.UserId != GetLoggedInUserId())
            {
                return RedirectToAction("AccessDenied", "Account");
            }
            return View(dto);
        }

        [HttpPost]
        [Authorize]
        [DisableRequestSizeLimit]
        [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        public async Task<IActionResult> Edit(RecipeDTO recipeDTO, IFormFile imageFile)
        {

            recipeDTO.UserId = GetLoggedInUserId();
            ModelState.Remove(nameof(RecipeDTO.ImageUrl)); // ImageUrl doğrulamasını kaldır

            if (imageFile != null && imageFile.Length > 0)
            {
                recipeDTO.ImageUrl = await UploadImageAsync(imageFile);
            }
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
                if (!string.IsNullOrEmpty(dto.ImageUrl) && !dto.ImageUrl.Contains("default-recipe.jpg"))
                {
                    try
                    {
                        string fileName = dto.ImageUrl.TrimStart('/');
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }

                    }
                    catch (Exception ex)
                    {
                        {

                        }
                    }
                    TempData["SuccessMessage"] = "Tarif ve görsel başarıyla silindi.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Tarif silinirken bir hata oluştu.";
                }              
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
        private async Task<string> UploadImageAsync(IFormFile imageFile)
        {
            try
            {
                // Dosya adını benzersiz yap
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                if (string.IsNullOrEmpty(_webHostEnvironment.WebRootPath))
                {
                    return "/uploads/recipes/default-recipe.jpg";
                }

                // Klasör: wwwroot/uploads/recipes
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "recipes");

                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                string filePath = Path.Combine(uploadDir, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                return "/uploads/recipes/" + fileName;

            }
            catch (Exception)
            {
                return "/uploads/recipes/default-recipe.jpg";

            }

        }
    }
}