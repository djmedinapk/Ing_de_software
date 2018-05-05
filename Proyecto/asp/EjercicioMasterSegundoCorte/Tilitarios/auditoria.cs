using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilitarios
{
    public partial class auditoria
    {
        public long id { get; set; }
        public System.DateTimeOffset fecha { get; set; }
        public string accion { get; set; }
        public string schema { get; set; }
        public string tabla { get; set; }
        public string pk { get; set; }
        public string session { get; set; }
        public string user_bd { get; set; }
    }
}
