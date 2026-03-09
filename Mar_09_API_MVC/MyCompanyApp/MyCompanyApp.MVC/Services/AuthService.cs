using System.Net.Http.Json;
using MyCompanyApp.MVC.Models;

namespace MyCompanyApp.MVC.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> Login(LoginViewModel login)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/login", login);

            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<TokenResponse>();

            return result?.Token;
        }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
    }
}