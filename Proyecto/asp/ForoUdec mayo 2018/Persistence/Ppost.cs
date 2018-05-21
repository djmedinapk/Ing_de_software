using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Ppost
    {
        public void publicarPost(publicacion datos)
        {
           
            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                
                db.publicacion.Add(datos);
                db.SaveChanges();
            }

        }
        public void eliminarPost(Int32 post_id)
        {

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                publicacion pd = db.publicacion.Find(post_id);
                pd.id_estado = 1;
                db.SaveChanges();
            }
        }

        public void validarPost(Int32 post_id)
        {

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                publicacion pd = db.publicacion.Find(post_id);
                pd.id_estado = 2;
                db.SaveChanges();
            }
        }
        public void modificarPost(publicacion datos)
        {

           using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                publicacion neww = db.publicacion.Find(datos.id);
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
