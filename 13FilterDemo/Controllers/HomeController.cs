using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _13FilterDemo.Controllers
{
    public class HomeController : Controller
    {
        //5th filter exception filter
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}