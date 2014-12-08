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
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            LoadImageHelper lh = new LoadImageHelper();

            return View(lh.loadImages());
        }

        public ActionResult Fade()
        {
            return View();
        }

        public ActionResult EditGallery()
        {
            return RedirectToAction("Index", "EditGallery");

        }
    }
}