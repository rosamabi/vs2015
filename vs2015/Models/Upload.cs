using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vs2015.Models
{
    public class Upload
    {
        public HttpPostedFileBase MyFile { get; set; }
        public string CroppedImagePath { get; set; }
    }
}