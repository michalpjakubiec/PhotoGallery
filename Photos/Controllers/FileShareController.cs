using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Photos.Controllers
{
    public class FileShareController : Controller
    {
        // GET: FileShare
        public ActionResult Index()
        {
            return View();
        }
        
        // POST: FileShare/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
