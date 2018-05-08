using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablas
{
    [Table("publicacion",Schema ="post")]
    public class publicacion
    {
        public long id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string contenido { get; set; }
        public Nullable<long> visitas { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string fuente { get; set; }
        public Nullable<int> id_estado { get; set; }
        public Nullable<long> id_usuario { get; set; }
        public string miniatura { get; set; }
        public string etiquetas { get; set; }
        public Nullable<int> id_categoria { get; set; }
        public string seccion { get; set; }
    }
}
