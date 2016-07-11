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
        public DateTime horario { get; set; }
        [StringLength(150)]
        public string descricao { get; set; }
    }
}