using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class Uadmin_ver_usuario_2
    {
        private String nombre;
        private String apellido;
        private String edad;
        private bool fem;
        private bool mas;
        private bool otro;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Edad { get => edad; set => edad = value; }
        public bool Fem { get => fem; set => fem = value; }
        public bool Mas { get => mas; set => mas = value; }
        public bool Otro { get => otro; set => otro = value; }
    }
}
