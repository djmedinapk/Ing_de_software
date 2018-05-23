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
        
        public DataTable guardadoSession(ingresos datos)
        {
            DataTable Usuario = new DataTable();

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                db.ingresos.Add(datos);
                db.SaveChanges();
            }

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
        public Int32 solicitar_bloqueo_sesion_pre(String datos)
        {
            Int32 Usuario;


            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                List<Int32?> a = db.f_solicitar_bloqueo_preingreso(datos).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                Usuario = Int32.Parse(a.First().ToString());
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
        public String solicitar_conteo_sesion(String datos)
        {
            String Usuario;


            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                List<String> a = db.f_solicitar_contador_sesiones(datos).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                Usuario = a.First().ToString();
            }
            return Usuario;
        }
        public Int32 traer_n_sesiones(String username)
        {
            Int32 datos ;
            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                List<int?> a = db.f_traer_bloqueo_sesiones(username).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                //datos = salida.ConvertToDataTable(a);
                datos = Int32.Parse(a.First().ToString());
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
        public DataTable ingresar(String userio_name, String pass)
        {
            DataTable Usuario = new DataTable();
            

            using (ForoUdecEntities1 db = new ForoUdecEntities1())
            {
                var a = db.f_loggin(userio_name,pass).ToList();
                ConverToDataTable salida = new ConverToDataTable();
                Usuario = salida.ConvertToDataTable(a);
                
            }
            return Usuario;
        }

    }
}
