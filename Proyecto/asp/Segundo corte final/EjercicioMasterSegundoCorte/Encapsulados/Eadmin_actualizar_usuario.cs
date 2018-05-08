using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulados
{
    public class Eadmin_actualizar_usuario
    {
        private String id;
        private String username;
        private String password;
        private String correo;
        private String session;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Session { get => session; set => session = value; }
        public string Id { get => id; set => id = value; }
    }
}
