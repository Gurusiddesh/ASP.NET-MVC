using _07EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace _07EFCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        StudentDbContext db = new StudentDbContext();

        public ActionResult Index(string SearchString, string sortOrder = "name_asc", int page = 1)
        {
            IEnumerable<Student> students;
            if (string.IsNullOrEmpty(SearchString))
                students = db.Students.ToList();
            else
                students = db.Students.Where(x => x.Name.Contains(SearchString)).ToList();

            int pageSize = 5;
            ViewBag.SearchString = SearchString;
            ViewBag.Page = page;
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.NameSort = sortOrder == "name_asc" ? "name_dsc" : "name_asc";
            ViewBag.AgeSort = sortOrder == "age_asc" ? "age_dsc" : "age_asc";
            ViewBag.CitySort = sortOrder == "city_asc" ? "city_dsc" : "city_asc";

            switch (sortOrder)
            {
                case "name_asc":
                    students = students.OrderBy(x => x.Name).ToList();
                    break;

                case "name_dsc":
                    students = students.OrderByDescending(x => x.Name).ToList();
                    break;

                case "age_asc":
                    students = students.OrderBy(x => x.Age).ToList();
                    break;

                case "age_dsc":
                    students = students.OrderByDescending(x => x.Age).ToList();
                    break;

                case "city_asc":
                    students = students.OrderBy(x => x.City).ToList();
                    break;

                case "city_dsc":
                    students = students.OrderByDescending(x => x.City).ToList();
                    break;


            }
            return View(students.ToPagedList(page, pageSize));
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