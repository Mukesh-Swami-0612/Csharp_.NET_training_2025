using MyCompanyApp.MVC.Models;

namespace MyCompanyApp.MVC.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse> GetAdventureWorksData(int page, int pageSize, string search)
        {
            var response = await _httpClient.GetAsync(
                $"AdventureWorks?page={page}&pageSize={pageSize}&search={search}");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<ApiResponse>();

            return data!;
        }
    }
}

