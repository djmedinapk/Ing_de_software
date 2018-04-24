using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilitarios
{
    public partial class bloqueo
    {
        public int id { get; set; }
        public Nullable<System.DateTime> fecha_bloqueo { get; set; }
        public Nullable<long> id_user { get; set; }
        public Nullable<System.DateTime> fecha_teminacion { get; set; }

        public virtual user_session user_session { get; set; }
    }
}
