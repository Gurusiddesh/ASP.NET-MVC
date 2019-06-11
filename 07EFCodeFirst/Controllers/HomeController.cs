using _07EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07EFCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        StudentDbContext db = new StudentDbContext();

        public ActionResult Index()
        {
            
            return View(db.Students.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Edit(int Id)
        {
            Student student = db.Students.Find(Id);
            return View(student);
        }

        
        [HttpPost]
        public ActionResult Edit(Student student)
        {

            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Delete(int Id)
        {
            Student student = db.Students.Find(Id);
            db.Entry(student).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}