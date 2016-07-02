using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vs2015.Helpers;

namespace vs2015.Controllers
{
    public class FileController : Controller
    {
        [HttpPost]
        public ActionResult UploadFile()
        {
            HttpPostedFileBase myFile = Request.Files["MyFile"];
            bool isUploaded = false;

            string tempFolderName = ConfigurationManager.AppSettings["Image.TempFolderName"];

            if (myFile != null && myFile.ContentLength != 0)
            {
                string tempFolderPath = Server.MapPath("~/" + tempFolderName);

                if (FileHelper.CreateFolderIfNeeded(tempFolderPath))
                {
                    try
                    {
                        myFile.SaveAs(Path.Combine(tempFolderPath, myFile.FileName));
                        isUploaded = true;
                    }
                    catch (Exception) {  /*TODO: You must process this exception.*/}
                }
            }

            string filePath = string.Concat("/", tempFolderName, "/", myFile.FileName);
            return Json(new { isUploaded, filePath }, "text/html");
        }
    }
}