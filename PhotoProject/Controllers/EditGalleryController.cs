﻿using PhotoProject.Models;
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
        [Authorize]
        public ActionResult Index(string id)
        {
            LoadImageHelper lh = new LoadImageHelper();

            return View(lh.loadImages(id));
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
        public ActionResult Upload(HttpPostedFileBase file, string id)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/images/uploads/gallery/" + id), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction(id == null ? "" : "Index/" + id);
        }


        public ActionResult DeleteImage(ImageModel fileName)
        {
            var fullPath = Server.MapPath("~/images/uploads/gallery/" + fileName.galleryName + "/" + fileName.imageName + ".jpg");

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            return RedirectToAction(fileName.galleryName == null ? "" : "Index/" + fileName.galleryName);
        }

        public ActionResult NewGallery(string galleryName)
        {
            var fullPath = Server.MapPath("~/images/uploads/gallery/" + galleryName.Split('/')[1]);
            Directory.CreateDirectory(fullPath);

            return RedirectToAction(galleryName);
        }

        [HttpPost]
        public ActionResult deleteGallery(string galleryName)
        {
            var fullPath = Server.MapPath("~/images/uploads/gallery/");
            Directory.Delete(fullPath+galleryName);

            return RedirectToAction("", "Gallery");
        }
    }
}