using Microsoft.AspNetCore.Mvc;
using MyCompanyApp.MVC.Models;
using MyCompanyApp.MVC.Services;

namespace MyCompanyApp.MVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DashboardService _service;

        public DashboardController(DashboardService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JWToken");

            if (token == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var data = await _service.GetDashboardData(token);

            return View(data);
        }
    }
}