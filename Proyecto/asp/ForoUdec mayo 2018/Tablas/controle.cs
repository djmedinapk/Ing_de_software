using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablas
{
    [Table("controles")]
    public class Controle
    {
        public int id { get; set; }
        public string control { get; set; }
        [Column("idioma_id")]
        public Nullable<int> idiomaId { get; set; }
        [Column("formulario_id")]
        public Nullable<int> formularioId { get; set; }
        public string texto { get; set; }
    }
}
