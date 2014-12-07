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

            for (int i = 0; i < filePaths.Length; i++)
            {
                imgM[i] = new ImageModel();
                var filename = files[i].Name.Split('.');
                imgM[i].imageURL = files[i].FullName;
                imgM[i].imageName = filename[0];
            }

            return imgM;
        }
    }
}