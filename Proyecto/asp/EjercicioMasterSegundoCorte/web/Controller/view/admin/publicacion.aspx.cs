using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Data;
using System.Collections;

public partial class view_admin_publicacion : System.Web.UI.Page
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
        Int32 idioma = 2;
        Int32 id_pagina = 2;
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
        L_publicas.Text = controles["L_publicas"].ToString();
        L_id.Text = controles["L_id"].ToString();
        L_titulo.Text = controles["L_titulo"].ToString();
        L_descripcion.Text = controles["L_descripcion"].ToString();
        L_estado.Text = controles["L_estado"].ToString();
        L_fecha.Text = controles["L_fecha"].ToString();
        L_action.Text = controles["L_action"].ToString();
        //Beliminar.Text = controles["Beliminar"].ToString();
        L_privadas.Text = controles["L_privadas"].ToString();
        L_id1.Text = controles["L_id1"].ToString();
        L_titulo1.Text = controles["L_titulo1"].ToString();
        L_descripcion1.Text = controles["L_descripcion1"].ToString();
        L_estado1.Text = controles["L_estado1"].ToString();
        L_fecha1.Text = controles["L_fecha1"].ToString();
        L_action1.Text = controles["L_action1"].ToString();
        L_action.Text = controles["L_action"].ToString();

    }
}