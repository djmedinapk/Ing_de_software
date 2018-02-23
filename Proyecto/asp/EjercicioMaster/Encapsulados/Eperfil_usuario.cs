using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulados
{
    class Eperfil_usuario
    {
        private String username;
        private String correo;
        private String nombre;
        private String apellido;
        private int edad;
        private String sexo;
        private String avatar;

        public string Username { get => username; set => username = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Avatar { get => avatar; set => avatar = value; }
    }
}
