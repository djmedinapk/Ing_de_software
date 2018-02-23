using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulados
{
    public class Eadmin_actualizar_usuario_2
    {
        private String id;
        private String nombre;
        private String apellido;
        private String edad;
        private String sexo;
        private String session;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Edad { get => edad; set => edad = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Session { get => session; set => session = value; }
    }
}
