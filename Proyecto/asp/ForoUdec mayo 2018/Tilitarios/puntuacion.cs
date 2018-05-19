using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilitarios
{
    public partial class puntuacion
    {
        public long id { get; set; }
        public Nullable<int> puntuacion1 { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public long id_usuario { get; set; }
        public Nullable<long> id_publicacion { get; set; }

        public virtual publicacion publicacion { get; set; }
        public virtual user_session user_session { get; set; }
    }
}
