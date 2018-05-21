using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using System.Data;
using Persistence;
using Persistencia;

namespace Logica
{
    public class Ladmin_main
    {
        public Uadmin_main main_page()
        {

            //Dadmin solicitud = new Dadmin();
            PsqlAdmin solicitud = new PsqlAdmin();
            DataTable datos = solicitud.cargar_pag_home();
            Uadmin_main datos2 = new Uadmin_main();
            datos2.LtotalUsers= datos.Rows[0]["totalusere1"].ToString();
            datos2.HltotalUsers = "Usuarios activos: "+ datos.Rows[0]["totalusere2"].ToString() + "<br>Usuarios suspendido: " + datos.Rows[0]["totalusere3"].ToString() + "<br>Usuarios inactivos: " + datos.Rows[0]["totalusere2"].ToString();
            datos2.LtotalPost = datos.Rows[0]["totalusere4"].ToString();
            datos2.HltotalPost = "Publicaciones Activas: " + datos.Rows[0]["totalusere5"].ToString() + "<br>Publicaciones suspendidas: " + datos.Rows[0]["totalusere7"].ToString() + "<br>Publicaciones Pendientes: " + datos.Rows[0]["totalusere6"].ToString();
            datos2.LtotalComentarios= datos.Rows[0]["totalusere8"].ToString();
            datos2.LtotalPuntos= datos.Rows[0]["totalusere9"].ToString();
            return datos2;
        }
        public DataTable cargar_top_user_post()
        {
            //Dadmin solicitud = new Dadmin();
            PsqlAdmin solicitud = new PsqlAdmin();
            DataTable respuesta = solicitud.cargar_pag_home_toppub();
            return respuesta;
        }
        public DataTable cargar_top_user_puntos()
        {
            //Dadmin solicitud = new Dadmin();
            PsqlAdmin solicitud = new PsqlAdmin();
            DataTable respuesta = solicitud.cargar_pag_home_toppoint();

            return respuesta;
        }

        public DataTable cargar_admin_chart()
        {
            //Dadmin solicitud = new Dadmin();
            PsqlAdmin solicitud = new PsqlAdmin();
            DataTable respuesta = solicitud.cargar_pag_home_chart();

            return respuesta;
        }


    }
}
