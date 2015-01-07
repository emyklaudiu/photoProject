using PhotoProject.Helpers;
using PhotoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoProject.Controllers
{
    public class BaseController : Controller
    {
        //This base class will be inherited by all controller classes in order to be able to access the loaded images
        public ImageModel[] model;
        public BaseController()
        {
            LoadImageHelper loadHelper = new LoadImageHelper();
            model = loadHelper.loadImages("");
            ViewBag.LayoutModel = model;
        }

        public BaseController(string albumName)
        {
            LoadImageHelper loadHelper = new LoadImageHelper();
            model = loadHelper.loadImages(albumName);
            ViewBag.LayoutModel = model;
        }
    }
}