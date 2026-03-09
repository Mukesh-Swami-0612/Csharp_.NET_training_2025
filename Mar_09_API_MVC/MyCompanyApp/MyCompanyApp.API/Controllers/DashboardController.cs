using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MyCompanyApp.Data.Context;

namespace MyCompanyApp.API.Controllers
{
    [Authorize]   // ⭐ Protect API with JWT
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly AdventureWorksContext _context;

        public DashboardController(AdventureWorksContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDashboardData()
        {
            var totalEmployees = _context.People.Count();

            var totalCustomers = _context.Customers.Count();

            var totalOrders = _context.SalesOrderHeaders.Count();

            return Ok(new
            {
                totalEmployees,
                totalCustomers,
                totalOrders
            });
        }
    }
}