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
        public void publicarPost(publicacion datos)
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
                publicacion pd = db.publicaciones.Find(post_id);
                pd.id_estado = 1;
                db.SaveChanges();
            }
        }

        public void validarPost(Int32 post_id)
        {

            using (ForoUdecContext db = new ForoUdecContext("post"))
            {
                publicacion pd = db.publicaciones.Find(post_id);
                pd.id_estado = 2;
                db.SaveChanges();
            }
        }
        public void modificarPost(publicacion datos)
        {

            using (ForoUdecContext db = new ForoUdecContext("post"))
            {
                publicacion neww = db.publicaciones.Find(datos.id);
                neww.titulo = datos.titulo;
                neww.descripcion = datos.descripcion;
                neww.contenido = datos.contenido;
                neww.id_categoria = datos.id_categoria;
                neww.etiquetas = datos.etiquetas;
                neww.miniatura = datos.miniatura;
                neww.fuente = datos.fuente;
                neww.id_estado = datos.id_estado;
                db.SaveChanges();
            }

        }



    }
}
