using PhotoProject.Helpers;
using PhotoProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoProject.Controllers
{
    public class GalleryController : BaseController
    {
        // GET: Gallery
        [Authorize]
        public ActionResult Index(string albumName)
        {
            LoadImageHelper lh = new LoadImageHelper();

            return View(lh.loadImages(albumName));
        }

        public JsonResult testGal()
        {
            LoadImageHelper lh = new LoadImageHelper();
            string[] result =lh.getGaleryNames();
            return Json(result);
        }

        public ActionResult GetGalleries()
        {
            LoadImageHelper lh = new LoadImageHelper();

            return View(lh.getGaleryNames());
        }

        [Authorize]
        public ActionResult EditGallery()
        {
            return RedirectToAction("Index", "EditGallery");
        }

        public JsonResult ReturnModel(string albumName)
        {
            LoadImageHelper lh = new LoadImageHelper();

            return Json(lh.loadImages(albumName));

        }
    }
}