using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablas
{
    [Table("denuncia_comentario", Schema="denuncia")]
    public class denuncia_comentario
    {
        public long id { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> id_comentario { get; set; }
        public Nullable<int> id_denunciante { get; set; }
        public Nullable<int> id_estado { get; set; }
    }
}
