using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilitarios
{
    public partial class correo_institucional
    {
        public int id { get; set; }
        public Nullable<long> id_session { get; set; }
        public string correo { get; set; }

        public virtual user_session user_session { get; set; }
    }
}
