using System.Linq;
using System.Web.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.Data;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        // LIST
        public ActionResult Index()
        {
            return View(FakeDatabase.Departments);
        }

        // CREATE GET
        public ActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public ActionResult Create(Department dept)
        {
            dept.DeptId = FakeDatabase.Departments.Count + 1;
            FakeDatabase.Departments.Add(dept);

            return RedirectToAction("Index");
        }

        // DELETE
        public ActionResult Delete(int id)
        {
            var dept = FakeDatabase.Departments
                        .FirstOrDefault(x => x.DeptId == id);

            if (dept != null)
                FakeDatabase.Departments.Remove(dept);

            return RedirectToAction("Index");
        }
    }
}