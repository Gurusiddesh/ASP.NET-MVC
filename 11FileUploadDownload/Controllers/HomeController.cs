using _11FileUploadDownload.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _11FileUploadDownload.Controllers
{
    public class HomeController : Controller
    {
        FileUploadDbContext db = new FileUploadDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.FileInformations.ToList());
        }

        [HttpPost]
        public ActionResult Create(FileInformation model, HttpPostedFileBase somefile)
        {
            FileInformation fi = new FileInformation();
            fi.FileName = Path.GetFileName(somefile.FileName);
            fi.ContentType = somefile.ContentType;

            using (var reader = new BinaryReader(somefile.InputStream))
            {
                fi.Content = reader.ReadBytes(somefile.ContentLength);
            }

            db.FileInformations.Add(fi);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DownloadFile(int id)
        {
            FileInformation fi = db.FileInformations.Find(id);
            return File(fi.Content, fi.ContentType, fi.FileName);
        }

        public ActionResult DeleteFile(int id)
        {
            FileInformation fi = db.FileInformations.Find(id);
            db.Entry(fi).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}