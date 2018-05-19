using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablas
{
    [Table("idioma", Schema = "idioma")]
    public class Idioma
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string terminacion { get; set; }
    }
}
