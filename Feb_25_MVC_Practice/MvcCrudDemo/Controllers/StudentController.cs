using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StudentCRUD.Models;

namespace StudentCRUD.Controllers
{
    public class StudentController : Controller
    {
        // In-memory list (acts like database)
        static List<Student> students = new List<Student>()
        {
            new Student{ Id=1, Name="Mukesh", Age=22, Course="CSE" },
            new Student{ Id=2, Name="Rahul", Age=23, Course="IT" }
        };

        // READ
        public ActionResult Index()
        {
            return View(students);
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(Student s)
        {
            s.Id = students.Max(x => x.Id) + 1;
            students.Add(s);
            return RedirectToAction("Index");
        }
        // GET: Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return RedirectToAction("Index");

            return View(student);
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            var student = students.FirstOrDefault(x => x.Id == s.Id);
            student.Name = s.Name;
            student.Age = s.Age;
            student.Course = s.Course;

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            students.Remove(student);
            return RedirectToAction("Index");
        }
    }
}