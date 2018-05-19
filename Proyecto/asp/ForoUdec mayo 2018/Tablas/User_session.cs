using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablas
{
    [Table("user_session", Schema ="usuario")]
    public class User_session
    {
        public long id { get; set; }
        public string username { get; set; }
        public string pasword { get; set; }
        [Column("fecha_ult_session")]
        public Nullable<System.DateTime> fechaUltimaSesion { get; set; }
        public string correo { get; set; }
        [Column("estado_session")]
        public Nullable<int> estadoSession { get; set; }
        public string session { get; set; }
        [Column("id_permisos")]
        public Nullable<int> idPermisos { get; set; }
        [Column("id_estado")]
        public Nullable<int> idEstado { get; set; }
        [Column("intentos_acceso")]
        public Nullable<int> intentosAcceso { get; set; }
        [Column("n_sesiones")]
        public Nullable<int> nSesiones { get; set; }
    }
}
