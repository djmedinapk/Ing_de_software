using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tablas;

namespace Persistencia
{
    public class Ppost
    {
        public void publicarPost(Publicacion datos)
        {
           
            using (ForoUdecContext db = new ForoUdecContext("post"))
            {
                
                db.publicaciones.Add(datos);
                db.SaveChanges();
            }

        }
        public void eliminarPost(Int32 post_id)
        {

            using (ForoUdecContext db = new ForoUdecContext("post"))
            {
                Publicacion pd = db.publicaciones.Find(post_id);
                pd.idEstado = 1;
                db.SaveChanges();
            }
        }

        public void validarPost(Int32 post_id)
        {

            using (ForoUdecContext db = new ForoUdecContext("post"))
            {
                Publicacion pd = db.publicaciones.Find(post_id);
                pd.idEstado = 2;
                db.SaveChanges();
            }
        }
        public void modificarPost(Publicacion datos)
        {

            using (ForoUdecContext db = new ForoUdecContext("post"))
            {
                Publicacion neww = db.publicaciones.Find(datos.id);
                neww.titulo = datos.titulo;
                neww.descripcion = datos.descripcion;
                neww.contenido = datos.contenido;
                neww.idCategoria = datos.idCategoria;
                neww.etiquetas = datos.etiquetas;
                neww.miniatura = datos.miniatura;
                neww.fuente = datos.fuente;
                neww.idEstado = datos.idEstado;
                db.SaveChanges();
            }

        }



    }
}
