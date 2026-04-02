using RecipeShare.Business.DTOs;
using System.Diagnostics;

namespace RecipeShare.Mvc.Services
{
    public class RecipeClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RecipeClientService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClientFactory.CreateClient("RecipeApi");
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<RecipeDTO>> GetAllRecipesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Recipe");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<RecipeDTO>>() ?? new List<RecipeDTO>();
                }
                else
                {
                    Console.WriteLine($"API Hatası: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API Hatası: {ex.Message}");
            }
            return new List<RecipeDTO>();
        }

        public async Task<RecipeDTO?> GetRecipeByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Recipe/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"API Hatası: {response.StatusCode}");
                    return null;
                }
                return await response.Content.ReadFromJsonAsync<RecipeDTO>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Bağlantı Hatası: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> CreateRecipeAsync(RecipeDTO recipeDTO)
        {
            try
            {
                AttachAuthToken();
                var response = await _httpClient.PostAsJsonAsync("Recipe", recipeDTO);
                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"API Hatası: {response.StatusCode}");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Bağlantı Hatası: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(RecipeDTO recipeDTO)
        {
            try
            {
                AttachAuthToken();
                var response = await _httpClient.PutAsJsonAsync("Recipe", recipeDTO);

                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"API Hatası: {response.StatusCode}");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Bağlantı Hatası: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                AttachAuthToken();
                var response = await _httpClient.DeleteAsync($"Recipe/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"API Hatası: {response.StatusCode}");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Bağlantı Hatası: {ex.Message}");
                return false;
            }
        }

        private void AttachAuthToken()
        { 
            var token = _httpContextAccessor.HttpContext?.User.FindFirst("JWToken")?.Value;
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
