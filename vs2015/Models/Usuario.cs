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
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [StringLength(50)]
        [Display(Name = "E-mail")]
        public string email { get; set; }
        [StringLength(1000)]
        [Display(Name = "Senha")]
        public string senha { get; set; }
        [Display(Name = "Cidade")]
        public int cidade { get; set; }
        [StringLength(2)]
        [Display(Name = "Estado")]
        public string estado { get; set; }
        [StringLength(70)]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }
        [StringLength(30)]
        [Display(Name = "Complemento")]
        public string complemento { get; set; }
        [Display(Name = "Número")]
        public short numero { get; set; }
        [StringLength(30)]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }
        [StringLength(20)]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }
        [StringLength(200)]
        [Display(Name = "Foto")]
        public string foto { get; set; }

        [NotMapped]
        public HttpPostedFileBase MyFile { get; set; }
    }
}
