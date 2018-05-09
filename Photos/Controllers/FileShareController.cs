using Photos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Photos.Controllers
{
    public class FileShareController : Controller
    {
        private static List<FileShareItem> _fileShares= new List<FileShareItem>();
        // GET: FileShare
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(Server.MapPath("~/UploadFiles"), fileName);

            file.SaveAs(filePath);

            if (Session["files"] == null)
                Session["files"] = new List<string>();

            (Session["files"] as List<string>).Add(fileName);

            return Json(fileName);
        }

        // POST: FileShare/Create
        [HttpPost]
        public ActionResult Create(string tags)
        {
            try
            {
                _fileShares.Add(new FileShareItem
                {
                    Tags = tags.Split(',').ToList(),
                    FileNames = Session["files"] as List<string>,
                });

                Session.Abandon();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult GetFileShares()
        {
            return PartialView("GetFileShares", _fileShares);
        }
    }
}
