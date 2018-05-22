using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Persistence
{
    public class PsqlDenuncia
    {
        public DataTable aceptar_denuncia_comentario(int id_denuncia)
        {
            DataTable datos = new DataTable();
            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_aceptar_denuncia_comentario(id_denuncia);


            }
            return datos;
        }

        public string denuncia_publicacion(int user_id, int publicacion_id, String descripcion)
        {
            string datos ;

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                List<string> a = db.f_denunciar_publicacion(user_id, publicacion_id, descripcion).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                //datos = salida.ConvertToDataTable(a);
                datos = a.First().ToString();
            }
            return datos;
        }

        public string denuncia_comentario(int user_id, int comentario_id, String descripcion)
        {
            string datos ;

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                List<string> a = db.f_denunciar_comentario(user_id, comentario_id, descripcion).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                //datos = salida.ConvertToDataTable(a);
                datos = a.First().ToString();


            }
            return datos;

        }

        public DataTable eliminar_denuncia_comentario(int id_denuncia)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {

                var a = db.f_eliminar_denuncia_comentario(id_denuncia);

            }
            return datos;
        }

        public DataTable mostar_denuncia_comentario()
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_mostar_denuncias_comentario(1).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);

            }

            return datos;
        }
    }
}
