using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
using System.Threading;
using System.Globalization;
using System.Collections;

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
            var datos_user = (DataRow)Session["data_user"];
            try
            {

                LmasterUsername.Text = datos_user["username"].ToString();
            }
            catch { }
            try
            {
                LPerfil datos_usuario = new LPerfil();
                Uvista_perfil datos = datos_usuario.vista_perfil(Int32.Parse(Session["user_id"].ToString()));
                ImasterAvatar.ImageUrl = datos.ImageUrl;
            }
            catch { }

        }
        Int32 idioma = 2;
        Int32 id_pagina = 24;
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
        L_lenguaje.Text = controles["L_lenguaje"].ToString();
        Bminiatura_settings.Text = controles["Bminiatura_settings"].ToString();
        Bminiatura_salir.Text = controles["Bminiatura_salir"].ToString();
        L_bienvenido.Text = controles["L_bienvenido"].ToString();
        L_inicio.Text = controles["L_inicio"].ToString();
        L_categorias.Text = controles["L_categorias"].ToString();
        L_contacto.Text = controles["L_contacto"].ToString();
        BTNsearch.Text = controles["BTNsearch"].ToString();
        L_inicio1.Text = controles["L_inicio1"].ToString();
        L_categorias1.Text = controles["L_categorias1"].ToString();
        L_contacto1.Text = controles["L_contacto1"].ToString();
        L_foro_estudiantes.Text = controles["L_foro_estudiantes"].ToString();
        BTNsearch2.Text = controles["BTNsearch2"].ToString();
        L_contacto2.Text = controles["L_contacto2"].ToString();
        L_derechos_reservados.Text = controles["L_derechos_reservados"].ToString();


    }
    protected void Bminiatura_salir_Click(object sender, EventArgs e)
        {
        Llogin user = new Llogin();

        user.terminar_sesion(Session.SessionID.ToString());
        Session["user_id"] = null;
        Session["username"] = null;
        Session["data_user"] = null;
        Session.Clear();
        Response.Redirect("~\\view\\login\\ingresar.aspx");
    }

        protected void Bminiatura_settings_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\view\\perfil\\perfil.aspx");
        }
    protected void BTNsearch_Click(object sender, EventArgs e)
    {
        String busqueda = Tsearch.Text;
        Response.Redirect("~/view/home/search.aspx?search=" + busqueda);
    }
    protected void BTNsearch2_Click(object sender, EventArgs e)
    {
        String busqueda = Tsearch2.Text;
        Response.Redirect("~/view/home/search.aspx?search=" + busqueda);
    }
    protected void DDL_lenguaje_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 index = Int32.Parse(DDL_lenguaje.SelectedValue.ToString());
        Lidioma cambiar_cultura = new Lidioma();
        String cultura = cambiar_cultura.select_idioma(index);
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultura);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
        Session["idioma"] = index;
        Int32 id_pagina = 24;
        try
        {
            Lidioma cargar_controles = new Lidioma();
            Hashtable controles = cargar_controles.cargar_controles(id_pagina, index);
            L_lenguaje.Text = controles["L_lenguaje"].ToString();
            Bminiatura_settings.Text = controles["Bminiatura_settings"].ToString();
            Bminiatura_salir.Text = controles["Bminiatura_salir"].ToString();
            L_bienvenido.Text = controles["L_bienvenido"].ToString();
            L_inicio.Text = controles["L_inicio"].ToString();
            L_categorias.Text = controles["L_categorias"].ToString();
            L_contacto.Text = controles["L_contacto"].ToString();
            BTNsearch.Text = controles["BTNsearch"].ToString();
            L_inicio1.Text = controles["L_inicio1"].ToString();
            L_categorias1.Text = controles["L_categorias1"].ToString();
            L_contacto1.Text = controles["L_contacto1"].ToString();
            L_foro_estudiantes.Text = controles["L_foro_estudiantes"].ToString();
            BTNsearch2.Text = controles["BTNsearch2"].ToString();
            L_contacto2.Text = controles["L_contacto2"].ToString();
            L_derechos_reservados.Text = controles["L_derechos_reservados"].ToString();
            //webBrowser1.Refresh();
        }
        catch
        {

        }
    }
}