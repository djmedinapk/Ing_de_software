using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Persistence
{
    public class PsqlFunctions
    {
        public DataTable a(int user_id)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = from b in db.publicacion
                        where b.id_usuario==user_id && b.id_usuario == user_id select b ;
                    //select
                    //    post.publicacion.id,
                    //    ('../post/Post.aspx?id=' + cast(post.publicacion.id as nvarchar(100))),
                    //    post.publicacion.titulo,
                    //    post.publicacion.descripcion,
                    //    post.estado.tipo,
                    //    ('../post/editar-post.aspx?id=' + cast(post.publicacion.id as nvarchar(100)))
                    //  from post.publicacion,post.estado
                    //  where post.publicacion.id_usuario = @userid
                    //  and post.publicacion.id_estado = post.estado.id
                    //  and post.publicacion.seccion = 'publico'
                    //  and post.publicacion.id_estado <> 1;


                ConverToDataTable salida = new ConverToDataTable();
                //datos = salida.ConvertToDataTable(a);
            }
            return datos;

        }
    }
}
