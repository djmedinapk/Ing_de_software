using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablas
{
    [Table("denuncia_comentario", Schema="denuncia")]
    public class DenunciaComentario
    {
        public long id { get; set; }
        public string descripcion { get; set; }
        [Column("id_comentario")]
        public Nullable<int> idComentario { get; set; }
        [Column("id_denunciante")]
        public Nullable<int> idDenunciante { get; set; }
        [Column("id_estado")]
        public Nullable<int> idEstado { get; set; }
    }
}
