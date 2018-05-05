using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilitarios
{
    public partial class bloqueo_configuration
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> tiempo { get; set; }
        public string tipo { get; set; }
    }
}
