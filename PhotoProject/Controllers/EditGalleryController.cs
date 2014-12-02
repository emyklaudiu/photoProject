using PhotoProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoProject.Controllers
{
    public class EditGalleryController : Controller
    {
        // GET: EditGallery
        
        public ActionResult Index()
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "images\\uploads\\gallery";
            string[] filePaths = Directory.GetFiles(directoryPath);

            ImageModel[] imgM = new ImageModel[filePaths.Length];
            
            for (int i = 0; i < filePaths.Length; i++)
            {
                imgM[i] = new ImageModel();
                imgM[i].imageURL = filePaths[i];
            }
            return View(imgM);
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


    }
}