using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class Upost2
    {
        private String nombre;
        private String descripcion;
        private String etiquetas;
        private String contenido;
        private bool fuentes1;
        private bool fuentes2;
        private String miniatura;
        private String categoria;
        private String autor;
        
        

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Contenido { get => contenido; set => contenido = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Etiquetas { get => etiquetas; set => etiquetas = value; }
        public string Miniatura { get => miniatura; set => miniatura = value; }
        public bool Fuentes1 { get => fuentes1; set => fuentes1 = value; }
        public bool Fuentes2 { get => fuentes2; set => fuentes2 = value; }
    }
}
