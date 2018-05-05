using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class Uvista_perfil
    {
        private String imageUrl;
        private String username;
        private String totalPublic;
        private String estado;
        private String nombre;
        private String edad;
        private String genero;
        private String response;

        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public string Username { get => username; set => username = value; }
        public string TotalPublic { get => totalPublic; set => totalPublic = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Edad { get => edad; set => edad = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Response { get => response; set => response = value; }
    }
}
