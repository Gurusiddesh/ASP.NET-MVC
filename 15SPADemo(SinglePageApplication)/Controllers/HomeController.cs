using _15SPADemo_SinglePageApplication_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace _15SPADemo_SinglePageApplication_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        EmployeeDbContext db = new EmployeeDbContext();

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult GetAll()
        {
            return Json(db.Employees.ToList(),JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult Save(Employee employee)
        {
            Thread.Sleep(4000);
            if (employee.Id == 0)
            {
                db.Employees.Add(employee);
            }
            else
            {
                Employee emp = db.Employees.Find(employee.Id);
                emp.Name = employee.Name;
                emp.Age = employee.Age;
                db.Entry(emp).State = EntityState.Modified;
            }
            db.SaveChanges();
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            Employee emp = db.Employees.Find(id);
            db.Entry(emp).State = EntityState.Deleted;
            db.SaveChanges();
            return Json(new { Success = "success" }, JsonRequestBehavior.AllowGet);
        }
    }
}