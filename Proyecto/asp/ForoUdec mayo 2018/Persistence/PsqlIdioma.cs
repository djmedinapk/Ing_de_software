using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Persistence
{
    public class PsqlIdioma
    {
        public DataTable cargar_idiomas()
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_cargar_idiomas().ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }
            return datos;
        }

        public DataTable obtenerIdioma(Int32 formulario, Int32 idioma)
        {
            DataTable Usuario = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_obtener_idioma_formulario(formulario, idioma).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                Usuario = salida.ConvertToDataTable(a);
            }
            return Usuario;
        }



        public DataTable agregarIdioma(String idioma, String term)
        {
            DataTable Usuario = new DataTable();
            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_ingresar_idioma(idioma, term);
            }
            return Usuario;
        }


        public DataTable cargar_form()
        {
            DataTable datos = new DataTable();
            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_listar_formulario().ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }
            return datos;
        }



        public DataTable cargar_ctrl(Int32 formulario, Int32 idioma)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_listar_controles(formulario).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }
            return datos;
        }



        public DataTable guardar_ctrl(String control, int idioma, int formulario, String texto)
        {
            DataTable datos = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_ingresar_idioma_control(idioma, control, formulario, texto);
            }
            return datos;
        }
        public void eliminarIdioma(Int32 id)
        {

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                idioma neww = db.idioma.Find(id);
                db.idioma.Remove(neww);
                db.SaveChanges();
            }

        }
    }
}
