using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class Upost
    {
        private String nombre;
        private String descripcion;
        private int categoria;
        private String contenido;
        private String autor;
        private String etiquetas;
        private String miniatura;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Categoria { get => categoria; set => categoria = value; }
        public string Contenido { get => contenido; set => contenido = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Etiquetas { get => etiquetas; set => etiquetas = value; }
        public string Miniatura { get => miniatura; set => miniatura = value; }
    }
}
