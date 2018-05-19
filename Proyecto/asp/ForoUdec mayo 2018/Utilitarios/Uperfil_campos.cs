using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class Uperfil_campos               //Se usa para retornar al web la información a coloar en el formulario
    {
        private String popup;
        private String pass1;
        private String pass2;
        private String username;

        public string Popup { get => popup; set => popup = value; }
        public string Pass1 { get => pass1; set => pass1 = value; }
        public string Pass2 { get => pass2; set => pass2 = value; }
        public string Username { get => username; set => username = value; }
    }
}
