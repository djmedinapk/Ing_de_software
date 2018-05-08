using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablas
{
    [Table("formulario")]
    public class formulario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string url { get; set; }
    }
}
