using Microsoft.AspNetCore.Mvc;
using MyCompanyApp.MVC.Services;

namespace MyCompanyApp.MVC.Controllers
{
    public class AdventureWorksController : Controller
    {
        private readonly ApiService _apiService;

        public AdventureWorksController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 100, string search = "")
        {
            var result = await _apiService.GetAdventureWorksData(page, pageSize, search);

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecords = result.TotalRecords;
            ViewBag.Search = search;

            return View(result.Data);
        }
    }
}