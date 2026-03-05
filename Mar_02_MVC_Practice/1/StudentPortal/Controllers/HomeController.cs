using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;
using System.Diagnostics;

namespace StudentPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentPortalDbContext _context;

        public HomeController(StudentPortalDbContext context)
        {
            _context = context;
        }

        // DASHBOARD
        public IActionResult Index(string search)
        {
            var students = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(s =>
                    s.FullName.Contains(search) ||
                    s.Email.Contains(search));
            }

            ViewBag.Search = search;

            return View(students.ToList());
        }

        // DASHBOARD STATS
        public IActionResult Dashboard()
        {
            var model = new DashboardViewModel
            {
                TotalStudents = _context.Students.Count(),
                TotalCourses = _context.Courses.Count(),
                TotalPaidAmount = _context.Enrollments
                    .Where(e => e.PaymentStatus == "Paid")
                    .Sum(e => (decimal?)e.PaidAmount) ?? 0,

                PendingPayments = _context.Enrollments
                    .Count(e => e.PaymentStatus == "Pending")
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}