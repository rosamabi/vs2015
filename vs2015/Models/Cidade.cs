using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vs2015.Models
{
    public class Cidade
    {
        public int id { get; set; }

        [StringLength(150)]
        public string nome { get; set; }

        [ForeignKey("Estado")]
        [StringLength(2)]
        [Display(Name = "Estado")]
        public string uf { get; set; }

        public virtual Estado Estado { get; set; }
    }
}