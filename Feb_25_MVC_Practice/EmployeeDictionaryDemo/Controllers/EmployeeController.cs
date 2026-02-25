using Microsoft.AspNetCore.Mvc;
using EmployeeDictionaryDemo.Models;
using System.Collections.Generic;

namespace EmployeeDictionaryDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // Dictionary to store max 5 employees
        private static Dictionary<int, Employee> empDict =
            new Dictionary<int, Employee>();

        public IActionResult Index()
        {
            ViewBag.Count = empDict.Count;
            return View(empDict);
        }

        public IActionResult Create()
        {
            if (empDict.Count >= 5)
            {
                TempData["Error"] = "Only 5 employees allowed!";
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                if (empDict.Count >= 5)
                {
                    TempData["Error"] = "Only 5 employees allowed!";
                    return RedirectToAction("Index");
                }

                emp.Id = empDict.Count + 1;
                empDict.Add(emp.Id, emp);

                return RedirectToAction("Index");
            }

            return View(emp);
        }
    }
}