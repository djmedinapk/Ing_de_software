using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilitarios
{
    public partial class usuario
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string avatar { get; set; }
        public Nullable<int> edad { get; set; }
        public Nullable<long> id_session { get; set; }
        public string sexo { get; set; }
        public string session { get; set; }

        public virtual user_session user_session { get; set; }
    }
}
