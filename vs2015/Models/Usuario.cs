using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vs2015.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string cidade { get; set; }
    }
}