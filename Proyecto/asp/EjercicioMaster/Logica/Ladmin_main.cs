using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using System.Data;

namespace Logica
{
    public class Ladmin_main
    {
        public Uadmin_main main_page()
        {
            
            Dadmin solicitud = new Dadmin();
            DataTable datos = solicitud.cargar_pag_home();
            Uadmin_main datos2 = new Uadmin_main();
            datos2.LtotalUsers= datos.Rows[0]["_totaluser"].ToString();
            datos2.HltotalUsers = "Usuarios activos: "+ datos.Rows[0]["_totaluser_activos"].ToString() + "<br>Usuarios suspendido: " + datos.Rows[0]["_totaluser_suspendidos"].ToString() + "<br>Usuarios inactivos: " + datos.Rows[0]["_totaluser_inactivos"].ToString();
            datos2.LtotalPost = datos.Rows[0]["_totalPost"].ToString();
            datos2.HltotalPost = "Publicaciones Activas: " + datos.Rows[0]["_totalPost_activos"].ToString() + "<br>Publicaciones suspendidas: " + datos.Rows[0]["_totalPost_suspendidos"].ToString() + "<br>Publicaciones Pendientes: " + datos.Rows[0]["_totalPost_pendientes"].ToString();
            datos2.LtotalComentarios= datos.Rows[0]["_totalcomentarios"].ToString();
            datos2.LtotalPuntos= datos.Rows[0]["_totalpoints"].ToString();
            return datos2;
        }
        public DataTable cargar_top_user_post()
        {
            Dadmin solicitud = new Dadmin();
            DataTable respuesta = solicitud.cargar_pag_home_toppub();
            return respuesta;
        }
        public DataTable cargar_top_user_puntos()
        {
            Dadmin solicitud = new Dadmin();
            DataTable respuesta = solicitud.cargar_pag_home_toppoint();
            return respuesta;
        }
        
    }
}
