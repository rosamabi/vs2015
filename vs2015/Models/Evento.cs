using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vs2015.Models
{
    [Table("Eventos")]
    public class Evento
    {
        public int id { get; set; }
        public DateTime horarioInicio { get; set; }
        public DateTime? horarioFim { get; set; } //se o evento for o dia todo, fica null
        [StringLength(150)]
        public string descricao { get; set; }
    }
}