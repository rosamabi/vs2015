using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vs2015.Models
{
    public class Usuario
    {
        public int id { get; set; }
        [StringLength(80)]
        public string nome { get; set; }
        [StringLength(50)]
        public string email { get; set; }
        [StringLength(1000)]
        public string senha { get; set; }
        [ForeignKey("Cidade")]
        public int cidadeid { get; set; }
        [StringLength(70)]
        public string endereco { get; set; }
        [StringLength(30)]
        public string complemento { get; set; }
        public short numero { get; set; }
        [StringLength(30)]
        public string bairro { get; set; }
        [StringLength(20)]
        public string telefone { get; set; }
        [StringLength(200)]
        public string foto { get; set; }

        public virtual Cidade Cidade { get; set; }
    }
}
