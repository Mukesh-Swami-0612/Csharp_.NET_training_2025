using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Square()
        {
            int number = 5 * 5;
            return Content(number.ToString());
        }
        //public ActionResult Name()
        //{
        //    return "Mukesh";
        //}

        public ActionResult DivideByZeroError()
        {
            int a = 10;
            int b = 0;
            int c = a / b;   
            return Content(c.ToString());
        }
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}