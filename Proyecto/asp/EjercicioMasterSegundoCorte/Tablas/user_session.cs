using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablas
{
    [Table("user_session", Schema ="usuario")]
    public class user_session
    {
        public long id { get; set; }
        public string username { get; set; }
        public string pasword { get; set; }
        public Nullable<System.DateTime> fecha_ult_session { get; set; }
        public string correo { get; set; }
        public Nullable<int> estado_session { get; set; }
        public string session { get; set; }
        public Nullable<int> id_permisos { get; set; }
        public Nullable<int> id_estado { get; set; }
        public Nullable<int> intentos_acceso { get; set; }
        public Nullable<int> n_sesiones { get; set; }
    }
}
