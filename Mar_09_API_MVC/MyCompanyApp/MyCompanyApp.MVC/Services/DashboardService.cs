using MyCompanyApp.MVC.Models;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace MyCompanyApp.MVC.Services
{
    public class DashboardService
    {
        private readonly HttpClient _httpClient;

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DashboardViewModel?> GetDashboardData(string token)
        {
            // Attach JWT Token
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.GetFromJsonAsync<DashboardViewModel>("dashboard");
        }
    }
}