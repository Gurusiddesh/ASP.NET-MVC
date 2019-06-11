using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03PartialViews.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TopArticles()
        {
            List<string> articles = new List<string>()
            {
                "Top 10 CSS Best Practices",
                "How to implement partial view",
                "What is Captcha?",
                ".Net Core released date",
                "What is MVC, MVP? "

            };
            return PartialView("_articles",articles);
        }

        public ActionResult Books()
        {
            List<string> books = new List<string>()
            {
                "Learn C#",
                "Learn Javascript",
                "Ansi C",
                "Frontend Web Development",
                "BackEnd Web Development"

            };
            return PartialView("_books", books);
        }
    }
}