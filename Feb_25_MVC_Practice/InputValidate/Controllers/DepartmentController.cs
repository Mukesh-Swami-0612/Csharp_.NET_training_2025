using Microsoft.AspNetCore.Mvc;
using InputValidate.Models;
using InputValidate.Data;
using System.Linq;

namespace InputValidate.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View(FakeDatabase.Departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                dept.DeptId = FakeDatabase.Departments.Count + 1;
                FakeDatabase.Departments.Add(dept);
                return RedirectToAction("Index");
            }

            return View(dept);
        }

        public IActionResult Delete(int id)
        {
            var dept = FakeDatabase.Departments
                        .FirstOrDefault(x => x.DeptId == id);

            if (dept != null)
                FakeDatabase.Departments.Remove(dept);

            return RedirectToAction("Index");
        }
    }
}