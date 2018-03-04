using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public  class Ucontacto
    {
        private String nombre;
        private String apellido;
        private String correo;
        private String telefono;
        private String contenido;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Contenido { get => contenido; set => contenido = value; }
    }
}
