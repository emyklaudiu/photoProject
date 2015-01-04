using PhotoProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoProject.Helpers
{
    public class LoadImageHelper
    {
        public ImageModel[] loadImages()
        {
            return loadImages("");
        }

        public string[] getGaleryNames()
        {
            
            var path = HttpContext.Current.Server.MapPath("~/images/uploads/gallery/");

            var di = new DirectoryInfo(path);
            var dirNames = di.GetDirectories();

            string[] result = new string[dirNames.Length];

            for(int i=0; i<dirNames.Length; i++)
            {
                result[i] = dirNames[i].Name;
            }

            return result;
        }

        public ImageModel[] loadImages(string albumName)
        {
            var path = HttpContext.Current.Server.MapPath("~/images/uploads/gallery/" + albumName);
            var di = new DirectoryInfo(path);

            var files = new FileInfo[0];
            if (di.Exists)
            {
                files = di.GetFiles();
            }
            else
            {
                path = HttpContext.Current.Server.MapPath("~/images/uploads/gallery/");
                di = new DirectoryInfo(path);
                files = di.GetFiles();
                albumName = "";
            }

            ImageModel[] imgM = new ImageModel[files.Length];

            if (imgM.Length > 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    imgM[i] = new ImageModel();
                    var filename = files[i].Name.Split('.');
                    imgM[i].imageName = filename[0];
                    imgM[i].galleryName = albumName;
                    imgM[i].imageURL = "/images/uploads/gallery/" + imgM[i].galleryName + "/" + imgM[i].imageName + ".jpg";
                }
            }
            else
            {
                string noImagePath = @"images\siteImages\no_image.png";
                ImageModel model = new ImageModel();
                model.imageName = "No Image";
                model.imageURL = noImagePath;
                model.id = -1;

                imgM = new ImageModel[1];
                imgM[0] = model;
            }


            return imgM;
        }
    }
}