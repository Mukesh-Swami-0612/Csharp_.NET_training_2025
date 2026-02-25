using System.Linq;
using System.Web.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.Data;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // LIST
        public ActionResult Index()
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

        // CREATE GET
        public ActionResult Create()
        {
            ViewBag.DepartmentList = new SelectList(
                FakeDatabase.Departments,
                "DeptId",
                "DeptName"
            );

            return View();
        }

        // CREATE POST
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            emp.EmpId = FakeDatabase.Employees.Count + 1;
            FakeDatabase.Employees.Add(emp);

            return RedirectToAction("Index");
        }

        // DELETE
        public ActionResult Delete(int id)
        {
            var emp = FakeDatabase.Employees
                        .FirstOrDefault(x => x.EmpId == id);

            if (emp != null)
                FakeDatabase.Employees.Remove(emp);

            return RedirectToAction("Index");
        }
    }
}