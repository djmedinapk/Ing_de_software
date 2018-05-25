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
        public DataTable listar_post(int user_id,string sesion)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = from b in db.publicacion
                        join e in db.estado on b.id_estado equals e.id
                        where b.id_estado != 1 && b.id_usuario == user_id && b.seccion == "publico"
                        select new
                        {
                            id = b.id,
                            id_post = "../post/Post.aspx?id=" + b.id.ToString(),
                            titulo = b.titulo,
                            estado = b.descripcion,
                            descripcion = e.tipo,
                            editar_post = "../post/editar-post.aspx?id=" + b.id.ToString()

                        };


                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a.ToList());
            }
            return datos;

        }
    }
}
