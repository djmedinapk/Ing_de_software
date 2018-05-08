using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablas
{
    [Table("usuario", Schema="usuario")]
    public class usuario
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string avatar { get; set; }
        public Nullable<int> edad { get; set; }
        public Nullable<long> id_session { get; set; }
        public string sexo { get; set; }
        public string session { get; set; }
    }
}
