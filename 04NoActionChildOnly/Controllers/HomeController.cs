using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04NoActionChildOnly.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly] //To prevent it directly calling as view it should be called by only main View as a child view;
        public ActionResult Topics()
        {
            List<string> topics = new List<string>() { "C#", "Java", "Python", "HTML", "CSS" };
            return PartialView("_topics", topics);
        }
        [NonAction] //blocking of non action method to convert it action method directly from browser //Any public method is by default action method;
        public string Demo()
        {
            return "Hello";
        }
        [ActionName("New")]
        public string DemoNew()
        {
            return "Hello World!";
        }
    }
}