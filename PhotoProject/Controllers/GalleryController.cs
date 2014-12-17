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
        public ActionResult Index()
        {
            LoadImageHelper lh = new LoadImageHelper();

            return View(lh.loadImages());
        }

        public ActionResult Fade()
        {
            LoadImageHelper lh = new LoadImageHelper();

            return View(lh.loadImages());
            
        }

        public ActionResult EditGallery()
        {
            return RedirectToAction("Index", "EditGallery");

        }

        public JsonResult ReturnModel()
        {
            LoadImageHelper lh = new LoadImageHelper();

            return Json(lh.loadImages());

        }
    }
}