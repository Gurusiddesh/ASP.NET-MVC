using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Hello World";
        }

        public string Name(string name)
        {
            return "Hello "+name;
        }
        public string Add(int n1, int n2)
        {
            return "<h1>The sum of two numbers is:"+(n1+n2)+ "</h1>";
        }

        public ActionResult Hello()
        {
            return View();
        }

        public ActionResult ShowTime()
        {
            return View();
        }

        public ActionResult Addition()
        {
            return View();
        }


        //public string Addition(int fnum,int snum)
        //{
        //    return "Sum of two Numbers is:"+(fnum+snum);
        //}

        [HttpPost]
        public ActionResult Addition(int fnum, int snum)
        {
            int result = fnum + snum;
            return View(result);
        }

        public ActionResult SiCalculator()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult SiCalculator(float pnum, float time, float roi)
        {
            float result = (pnum * time * roi) / 100;
            return View(result);
        }



        
    }
}