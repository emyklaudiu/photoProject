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
            string directoryPath = HttpContext.Current.Server.MapPath(@"~\images\uploads\gallery");
            string[] filePaths = Directory.GetFiles(directoryPath);
            var path = HttpContext.Current.Server.MapPath("~/images/uploads/gallery/");
            var di = new DirectoryInfo(path);
            var files = di.GetFiles();

            ImageModel[] imgM = new ImageModel[filePaths.Length];

            if (imgM.Length > 0)
            {
                for (int i = 0; i < filePaths.Length; i++)
                {
                    imgM[i] = new ImageModel();
                    var filename = files[i].Name.Split('.');                   
                    imgM[i].imageName = filename[0];
                    imgM[i].imageURL = "/images/uploads/gallery/" + imgM[i].imageName + ".jpg";                   
                }
            }
            else
            {
                string noImagePath = @"images\siteImages\no_image.png";
                ImageModel model = new ImageModel();
                model.imageName = "No Image";
                model.imageURL = noImagePath;                

                imgM = new ImageModel[1];
                imgM[0] = model;
            }


            return imgM;
        }
    }
}