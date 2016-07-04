using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vs2015.Models
{
    [Table("Estados")] //sem isso, tava criando a tabela Estadoes rs
    public class Estado
    {
        [Key]
        [StringLength(2)]
        [Display(Name = "UF")]
        public string uf { get; set; }

        [StringLength(50)]
        [Display(Name = "Nome")]
        public string nome { get; set; }
    }
}