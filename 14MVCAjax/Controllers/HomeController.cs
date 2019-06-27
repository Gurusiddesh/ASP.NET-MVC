using _14MVCAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace _14MVCAjax.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetDate()
        {
            Thread.Sleep(5000);
            return PartialView("_DateTime");
        }
        [HttpPost]
        public PartialViewResult SaveStudentDetails(Student student)
        {
            
            return PartialView("_StudentDetails",student);
        }

    }
}