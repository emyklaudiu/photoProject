using PhotoProject.Helpers;
using PhotoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoProject.Controllers
{
    public class BaseController:Controller
    {
        public ImageModel[] model;

        public BaseController()
        {
            // Here you will use some business logic to populate your Layout Model
            // You might also consider placing this model into the cache to prevent constant fetching of data from the database on each page request.
            LoadImageHelper loadHelper = new LoadImageHelper();
            model = loadHelper.loadImages();
            ViewBag.LayoutModel = model;
        }
    }
}