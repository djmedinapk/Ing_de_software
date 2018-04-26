using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tablas;

namespace Persistencia
{
    public class ForoUdecContext: DbContext
    {
        public ForoUdecContext() : base("Postgres")
        {
            
        }

        public DbSet<contacto> contactos { get; set; }
    }
}
