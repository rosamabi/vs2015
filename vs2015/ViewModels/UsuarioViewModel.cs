using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vs2015.Models;

namespace vs2015.ViewModels
{
    public class UsuarioViewModel
    {

        public int id { get; set; }
        [Required, StringLength(80)]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Required, StringLength(50)]
        [Display(Name = "E-mail")]
        public string email { get; set; }
        [Required, StringLength(20)]
        [Display(Name = "Senha")]
        public string senha { get; set; }
        [Display(Name = "Cidade")]
        public int cidadeid { get; set; }
        [Required, StringLength(70)]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }
        [Display(Name = "Complemento"), StringLength(30)]
        [DisplayFormat(NullDisplayText = "-")]
        public string complemento { get; set; }
        [Required]
        [Display(Name = "Número")]
        public short numero { get; set; }
        [Required, StringLength(30)]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }
        [Required, StringLength(20)]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }
        [Display(Name = "Foto")]
        public string foto { get; set; }

        public HttpPostedFileBase MyFile { get; set; }

        public virtual Cidade Cidade { get; set; }

        public IEnumerable<SelectListItem> cidades { get; set; }
        public IEnumerable<SelectListItem> estados { get; set; }
    }
}