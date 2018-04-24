using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilitarios
{
    public partial class lcontrole
    {
        public int id { get; set; }
        public string control { get; set; }
        public Nullable<int> formulario_id { get; set; }

        public virtual formulario formulario { get; set; }
    }
}
