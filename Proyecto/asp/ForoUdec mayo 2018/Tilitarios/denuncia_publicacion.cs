using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilitarios
{
    public partial class denuncia_publicacion
    {
        public long id { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> id_publicacion { get; set; }
        public Nullable<int> id_denunciante { get; set; }
        public Nullable<int> id_estado { get; set; }

        public virtual estado_denuncia estado_denuncia { get; set; }
    }
}
