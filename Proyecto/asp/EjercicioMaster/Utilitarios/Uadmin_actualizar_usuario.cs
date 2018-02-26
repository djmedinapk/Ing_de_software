using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class Uadmin_actualizar_usuario
    {
        private String username;
        private String password;
        private String correo;
        private String session;
        private bool admin;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Session { get => session; set => session = value; }
        public bool Admin { get => admin; set => admin = value; }
    }
    public class Uadmin_actualizar_usuario2     //Cascaron para informacion personal del usuario
    {
        private String id;
        private String nombre;
        private String apellido;
        private String edad;
        private String sexo;
        private String session;
        private String avatar;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Edad { get => edad; set => edad = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Session { get => session; set => session = value; }
        public string Avatar { get => avatar; set => avatar = value; }
    }
}
