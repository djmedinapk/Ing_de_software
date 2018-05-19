using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablas
{
    [Table("contacto", Schema = "public")]
    public class Contacto
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string contenido { get; set; }
        [Column("fecha_solicitud")]
        public Nullable<System.DateTime> fechaSolicitud { get; set; }
    }
}
