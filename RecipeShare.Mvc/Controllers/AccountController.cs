using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RecipeShare.Business.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RecipeShare.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDTO);
            }
            var client = _httpClientFactory.CreateClient("RecipeApi");

            var response = await client.PostAsJsonAsync("Auth/login", loginDTO);

            if (response.IsSuccessStatusCode)
            {
                // İşte burası kritik: API'den gelen isimsiz nesneyi 
                // bizim AuthResponseDTO sınıfımıza döküyoruz.
                var authResult = await response.Content.ReadFromJsonAsync<AuthResponseDTO>();

                if (authResult != null)
                {
                    // Token'ı alıp oturumu (Cookie) başlatıyoruz
                    await SignInUser(authResult);

                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "E-posta veya şifre hatalı.");
            return View(loginDTO);
        }

        private async Task SignInUser(AuthResponseDTO authData)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(authData.Token);

            var claims = jwtToken.Claims.ToList();

            claims.Add(new Claim(ClaimTypes.Name, authData.UserName));            
            claims.Add(new Claim(ClaimTypes.Role, authData.Role));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, authData.UserId.ToString()));

            claims.Add(new Claim("JWToken", authData.Token));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }
            var client = _httpClientFactory.CreateClient("RecipeApi");
            var response = await client.PostAsJsonAsync("Auth/register", registerDto);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Kayıt başarılı! Lütfen giriş yapın.";
                return RedirectToAction("Login");
            }
            ModelState.AddModelError(string.Empty, "Kayıt sırasında bir hata oluştu. E-posta veya kullanıcı adı kullanımda olabilir.");
            return View(registerDto);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
