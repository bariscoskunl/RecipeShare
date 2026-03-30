using RecipeShare.Business.DTOs;
using System.Diagnostics;

namespace RecipeShare.Mvc.Services
{
    public class RecipeClientService
    {
        private readonly HttpClient _httpClient;

        public RecipeClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("RecipeApi");
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
            var response = await _httpClient.GetAsync($"Recipe/{id}");
            if (!response.IsSuccessStatusCode)
            {               
                Debug.WriteLine($"API Hatası: {response.StatusCode}");
                return null;
            }

            return await response.Content.ReadFromJsonAsync<RecipeDTO>();
        }
    }
}
