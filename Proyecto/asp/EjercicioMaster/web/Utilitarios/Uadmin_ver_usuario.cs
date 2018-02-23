using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class Uadmin_ver_usuario
    {
        private String alerta;
        private String id;
        private String username;
        private String correo;
        private String password;

        public string Alerta { get => alerta; set => alerta = value; }
        public string Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Password { get => password; set => password = value; }
    }
}
