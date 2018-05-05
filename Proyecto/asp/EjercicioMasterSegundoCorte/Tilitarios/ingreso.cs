using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilitarios
{
    public partial class ingreso
    {
        public long id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string user_mac { get; set; }
        public string user_session { get; set; }
        public Nullable<System.TimeSpan> fecha_inicio { get; set; }
        public string user_ip { get; set; }
    }
}
