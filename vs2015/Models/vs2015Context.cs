using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace vs2015.Models
{
    public class vs2015Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public vs2015Context() : base("name=vs2015Context")
        {
        }

        public System.Data.Entity.DbSet<vs2015.Models.Usuario> Usuarios { get; set; }
        public System.Data.Entity.DbSet<vs2015.Models.Estado> Estados { get; set; }
        public System.Data.Entity.DbSet<vs2015.Models.Cidade> Cidades { get; set; }
        public System.Data.Entity.DbSet<vs2015.Models.Evento> Eventos { get; set; }
    }
}
