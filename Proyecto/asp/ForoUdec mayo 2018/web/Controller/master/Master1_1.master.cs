using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class Master1 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LverificarSesion verificar = new LverificarSesion();
        try
        {
            Response.Redirect(verificar.verificar_sesion((DataRow)Session["data_user"], "../login/ingresar.aspx"));
        }
        catch
        {
            String[] permisos = new String[] { "AD", "U2", "M2" };
            String[] respuesta = verificar.verificar_permisos3((DataRow)Session["data_user"], permisos, "~/view/perfil/correoinstitucional.aspx", Session["correo_inst"].ToString());
           try
            {
                Response.Redirect(respuesta[0]);
            }
            catch
            {
                Lusername.Text = respuesta[1];
            }
            
        }

        //var papas = (DataRow)Session["data_user"];
        //if (papas!=null) {
        //    if (Session["correo_inst"] != null || papas["id_permisos"].ToString()=="2")
        //    {
        //        Lusername.Text = papas["username"].ToString();
        //    }
        //    else
        //    {
        //        Response.Redirect("~/view/perfil/correoinstitucional.aspx");
        //    }
        //}
        //else
        //{
        //    Response.Redirect("~/view/home/index.aspx");
        //}
        Int32 idioma = 2;
        Int32 id_pagina = 29;
        try
        {
            idioma = Int32.Parse(Session["idioma"].ToString());
            Lotros post = new Lotros();
            try
            {
                Int32 aux = Int32.Parse(post.aux1(!IsPostBack));
            }
            catch
            {
                DDL_lenguaje.SelectedValue = idioma.ToString();
            }

        }
        catch
        {
            idioma = 2;
        }

        Lidioma cargar_controles = new Lidioma();
        Hashtable controles = cargar_controles.cargar_controles(id_pagina, idioma);
        L_inicio.Text = controles["L_inicio"].ToString();
        L_foropublico.Text = controles["L_foropublico"].ToString();
        BTNsearch.Text = controles["BTNsearch"].ToString();
        Tsearch.Attributes["placeholder"] = controles["Tsearch"].ToString();
        L_derechos_reservados.Text = controles["L_derechos_reservados"].ToString();
        L_categorias.Text = controles["L_categorias"].ToString();
        L_perfil.Text = controles["L_perfil"].ToString();
    }

    protected void BTNsearch_Click(object sender, EventArgs e)
    {
        String busqueda = Tsearch.Text;
        Response.Redirect("~/view/private/search.aspx?search=" + busqueda);
    }

    protected void DDL_lenguaje_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 index = Int32.Parse(DDL_lenguaje.SelectedValue.ToString());
        Lidioma cambiar_cultura = new Lidioma();
        String cultura = cambiar_cultura.select_idioma(index);
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultura);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
        Session["idioma"] = index;
        Int32 id_pagina = 23;
        try
        {
            Lidioma cargar_controles = new Lidioma();
            Hashtable controles = cargar_controles.cargar_controles(id_pagina, index);
            L_inicio.Text = controles["L_inicio"].ToString();
            L_foropublico.Text = controles["L_foropublico"].ToString();
            BTNsearch.Text = controles["BTNsearch"].ToString();
            Tsearch.Attributes["placeholder"] = controles["Tsearch"].ToString();
            L_derechos_reservados.Text = controles["L_derechos_reservados"].ToString();
            L_categorias.Text = controles["L_categorias"].ToString();
            L_perfil.Text = controles["L_perfil"].ToString();
        }
        catch
        {

        }


    }
}
