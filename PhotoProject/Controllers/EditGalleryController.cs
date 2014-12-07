using PhotoProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoProject.Helpers;

namespace PhotoProject.Controllers
{
    public class EditGalleryController : Controller
    {
        // GET: EditGallery
        
        public ActionResult Index()
        {
            LoadImageHelper lh = new LoadImageHelper();

            return View(lh.loadImages());
        }

          [HttpPost]
          public ActionResult addImage(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/images/uploads/gallery"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
          public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/images/uploads/gallery"), fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");
        }

        
        public ActionResult DeleteImage(ImageModel fileName)
        {
            var fullPath = Server.MapPath("~/images/uploads/gallery/" + fileName.imageName+".jpg");



            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);                
            }

            return RedirectToAction("Index");
        }
    }
}