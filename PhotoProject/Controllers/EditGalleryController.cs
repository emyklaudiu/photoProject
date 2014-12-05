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
            string directoryPath =Server.MapPath(@"~\images\uploads\gallery");
            string[] filePaths = Directory.GetFiles(directoryPath);
            var path = Server.MapPath("~/images/uploads/gallery/");
            var di = new DirectoryInfo(path);
            var files = di.GetFiles();

            ImageModel[] imgM = new ImageModel[filePaths.Length];
            
            for (int i = 0; i < filePaths.Length; i++)
            {
                imgM[i] = new ImageModel();
                var filename = files[i].Name.Split('.');
                imgM[i].imageURL = files[i].FullName;
                imgM[i].imageName = filename[0];
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