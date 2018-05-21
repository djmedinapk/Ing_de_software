using Encapsulados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Persistence
{
    public class PsqlLogin
    {
        public DataTable ingresar(String userio_name, String pass)
        {
            DataTable Usuario = new DataTable();

            return Usuario;
        }

        public DataTable guardadoSession(Esesion datos)
        {
            DataTable Usuario = new DataTable();

            return Usuario;
        }
        public DataTable CerrarSession(String datos)
        {
            DataTable Usuario = new DataTable();

            return Usuario;
        }
        public DataTable ingresar_bloqueo_sesion(String datos)
        {
            DataTable Usuario = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_ingresar_bloqueo_sesion(datos);
            }

            return Usuario;
        }
        public DataTable solicitar_bloqueo_sesion(String datos)
        {
            DataTable Usuario = new DataTable();


            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_solicitar_bloqueo2(datos).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                Usuario = salida.ConvertToDataTable(a);
            }
            return Usuario;
        }
        public DataTable solicitar_bloqueo_sesion_pre(String datos)
        {
            DataTable Usuario = new DataTable();


            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_solicitar_bloqueo_preingreso(datos).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                Usuario = salida.ConvertToDataTable(a);
            }


            return Usuario;
        }

        public DataTable limpiar_bloqueo_sesion(String datos)
        {
            DataTable Usuario = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_limpiar_bloqueo(datos);
            }

            return Usuario;
        }
        public DataTable solicitar_conteo_sesion(String datos)
        {
            DataTable Usuario = new DataTable();


            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_solicitar_contador_sesiones(datos).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                Usuario = salida.ConvertToDataTable(a);
            }
            return Usuario;
        }
        public DataTable traer_n_sesiones(String username)
        {
            DataTable datos = new DataTable();
            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_traer_bloqueo_sesiones(username).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                datos = salida.ConvertToDataTable(a);
            }
            return datos;
        }
        public user_session traerUser(Int32 id)
        {

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                user_session user = db.user_session.Find(id);
                return user;
            }

        }
    }
}
