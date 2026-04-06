using Microsoft.AspNetCore.Mvc;
using RecipeShare.Business.DTOs;
using System.Diagnostics;

namespace RecipeShare.Mvc.Services
{
    public class CommentClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Task<List<CommentDTO>> GetAllCommentsAsync() => GetCommentsAsync("Comment");      
        public Task<List<CommentDTO>> GetCommentsByRecipeIdAsync(int recipeId)
            => GetCommentsAsync($"Comment/recipe/{recipeId}");

        public CommentClientService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClientFactory.CreateClient("RecipeApi");
            _httpContextAccessor = httpContextAccessor;
        }

        private async Task<List<CommentDTO>> GetCommentsAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<CommentDTO>>() ?? new List<CommentDTO>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Hatası ({url}): {ex.Message}");
            }
            return new List<CommentDTO>();
        }      

        public async Task<bool> CreateCommentAsync(CommentDTO commentDTO)
        {
            try
            {
                AttachAuthToken();
                var response = await _httpClient.PostAsJsonAsync("Comment", commentDTO);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Bağlantı Hatası (Create): {ex.Message}");
                return false;
            }
        }
        public async Task<bool> UpdateCommentAsync(CommentDTO commentDTO)
        {
            try
            {
                AttachAuthToken();               
                var response = await _httpClient.PutAsJsonAsync($"Comment/{commentDTO.Id}", commentDTO);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Bağlantı Hatası (Update): {ex.Message}");
                return false;
            }
        }
        public async Task<bool> DeleteCommentAsync(int id)
        {
            try
            {
                AttachAuthToken();
                var response = await _httpClient.DeleteAsync($"Comment/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Bağlantı Hatası (Delete): {ex.Message}");
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
