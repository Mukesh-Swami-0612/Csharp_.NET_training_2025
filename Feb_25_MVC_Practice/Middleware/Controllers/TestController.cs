using Microsoft.AspNetCore.Mvc;

namespace Middleware.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Echo(string q)
        {
            return Content($"You sent q = {q}");
        }
    }
}