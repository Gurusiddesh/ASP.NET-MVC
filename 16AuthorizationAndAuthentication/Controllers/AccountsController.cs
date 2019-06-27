using _16AuthorizationAndAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _16AuthorizationAndAuthentication.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        CollegeDbContext db = new CollegeDbContext();

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                db.AppUsers.Add(appUser);
                db.SaveChanges();
                return RedirectToAction("Login", "Accounts");
            }
            return View(appUser);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            AppUser appUser = db.AppUsers.Where(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password).FirstOrDefault();
            if (appUser != null)
            {
                FormsAuthentication.SetAuthCookie(appUser.Name, loginViewModel.RememberMe);


                // Code to add role to cookie
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    1,
                    appUser.Name,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    loginViewModel.RememberMe,
                    appUser.Roles
                    );

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(cookie);


                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid user name and password";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}