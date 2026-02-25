using Microsoft.AspNetCore.Mvc;
using InputValidate.Models;
using InputValidate.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace InputValidate.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            var employees = FakeDatabase.Employees;

            foreach (var emp in employees)
            {
                var dept = FakeDatabase.Departments
                            .FirstOrDefault(d => d.DeptId == emp.DeptId);

                if (dept != null)
                    emp.DeptName = dept.DeptName;
            }

            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.DepartmentList = new SelectList(
                FakeDatabase.Departments,
                "DeptId",
                "DeptName"
            );

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                emp.EmpId = FakeDatabase.Employees.Count + 1;
                FakeDatabase.Employees.Add(emp);
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentList = new SelectList(
                FakeDatabase.Departments,
                "DeptId",
                "DeptName"
            );

            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            var emp = FakeDatabase.Employees
                        .FirstOrDefault(x => x.EmpId == id);

            if (emp != null)
                FakeDatabase.Employees.Remove(emp);

            return RedirectToAction("Index");
        }
    }
}