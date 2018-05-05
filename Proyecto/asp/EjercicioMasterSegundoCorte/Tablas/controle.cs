using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablas
{
    [Table("controles")]
    public class controle
    {
        public int id { get; set; }
        public string control { get; set; }
        public Nullable<int> idioma_id { get; set; }
        public Nullable<int> formulario_id { get; set; }
        public string texto { get; set; }
    }
}
