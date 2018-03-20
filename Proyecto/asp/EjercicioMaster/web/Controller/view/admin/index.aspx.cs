using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
using System.Collections;

public partial class view_admin_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LverificarSesion verificar = new LverificarSesion();//"U1", "M1", "U2","M2",
        String[] permisos = new String[] { "AD" };
        try
        {
            String url = verificar.verificar_sesion((DataRow)Session["data_user"], "../home/index.aspx");
            Response.Redirect(url);
        }
        catch
        {
            try
            {
                String url = verificar.verificar_permisos((DataRow)Session["data_user"], permisos, "../home/index.aspx");
                Response.Redirect(url);
            }
            catch
            {

            }
        }
        Ladmin_main solicitud = new Ladmin_main();
        Uadmin_main datos = new Uadmin_main();
        datos = solicitud.main_page();
        //try {
            LtotalUsers.Text = datos.LtotalUsers;
            HLtotalUser.Attributes.Add("data-content",datos.HltotalUsers);
            LtotalPost.Text = datos.LtotalPost;
            HLtotalPost.Attributes.Add("data-content",datos.HltotalPost);
            LtotalComentarios.Text = datos.LtotalComentarios;
            LtotalPuntos.Text = datos.LtotalPuntos;

        //} catch {
        //Response.Redirect("../home/index.aspx");
        // }

        Int32 idioma = 2;
        Int32 id_pagina =1;
        try
        {
            idioma = Int32.Parse(Session["idioma"].ToString());
            Lotros post = new Lotros();
        }
        catch
        {
            idioma = 2;
        }

        Lidioma cargar_controles = new Lidioma();
        Hashtable controles = cargar_controles.cargar_controles(id_pagina, idioma);
        L_total_usuarios.Text = controles["L_total_usuarios"].ToString();
        L_total_publicaciones.Text = controles["L_total_publicaciones"].ToString();
        L_total_comentarios.Text = controles["L_total_comentarios"].ToString();
        L_total_puntos.Text = controles["L_total_puntos"].ToString();
        L_top_perfiles_publicaciones.Text = controles["L_top_perfiles_publicaciones"].ToString();
        //L_publicaciones.Text = controles["L_publicaciones"].ToString();
        L_top_perfiles_puntos.Text = controles["L_top_perfiles_puntos"].ToString();
        //L_puntos.Text = controles["L_puntos"].ToString();
        //L_top_perfiles*/.Text = controles["L_top_perfiles"].ToString();
        //L_sessions.Text = controles["L_sessions"].ToString();
        //L_top_perfiles.Text = controles["L_top_perfiles"].ToString();
        L_top_publicaciones_populares.Text = controles["L_top_publicaciones_populares"].ToString();
        L_titulo.Text = controles["L_titulo"].ToString();
        L_fecha.Text = controles["L_fecha"].ToString();
        L_visitas1.Text = controles["L_visitas1"].ToString();
        L_action.Text = controles["L_action"].ToString();


    }
}