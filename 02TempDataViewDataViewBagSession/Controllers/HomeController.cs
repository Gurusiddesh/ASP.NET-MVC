using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02TempDataViewDataViewBagSession.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult Demo()
        {
            string name = "Ram";

            ViewData["Name"] = name;
            ViewData["Age"]=18;

            TempData["City"] = "Goa";

            Session["Country"] = "India";

            ViewBag.PhoneNumber = 9845098450;
            return View();
        }

        public ActionResult Demo1()
        {
            return View();
        }
    }
}