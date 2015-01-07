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
            var directoryInfo = new DirectoryInfo(path);
            var directories = directoryInfo.GetDirectories();

            string[] directoryNames = new string[directories.Length];

            for (int i = 0; i < directories.Length; i++)
            {
                directoryNames[i] = directories[i].Name;
            }

            return directoryNames;
        }

        public ImageModel[] loadImages(string albumName)
        {
            var path = HttpContext.Current.Server.MapPath("~/images/uploads/gallery/" + albumName);
            var directoryInfo = new DirectoryInfo(path);

            var files = new FileInfo[0];
            if (directoryInfo.Exists)
            {
                files = directoryInfo.GetFiles();
            }
            else
            {
                path = HttpContext.Current.Server.MapPath("~/images/uploads/gallery/");
                directoryInfo = new DirectoryInfo(path);
                files = directoryInfo.GetFiles();
                albumName = "";
            }

            ImageModel[] images = new ImageModel[files.Length];

            if (images.Length > 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    images[i] = new ImageModel();
                    var filename = files[i].Name.Split('.');
                    images[i].imageName = filename[0];
                    images[i].galleryName = albumName;
                    images[i].imageURL = "/images/uploads/gallery/" + images[i].galleryName + "/" + images[i].imageName + ".jpg";
                }
            }
            else
            {
                string noImagePath = @"images\siteImages\no_image.png";
                ImageModel model = new ImageModel();
                model.imageName = "No Image";
                model.imageURL = noImagePath;
                model.id = -1;

                images = new ImageModel[1];
                images[0] = model;
            }

            return images;
        }
    }
}