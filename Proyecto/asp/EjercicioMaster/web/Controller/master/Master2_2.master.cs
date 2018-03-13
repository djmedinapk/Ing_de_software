using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Master1 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["user_id"] == null || Session["data_user"] == null)
        {
            Session["username"] = null;
            Session["user_id"] = null;
            Session["Iperfil_url"] = null;
            
        }
        else
        {
           var datos_user = (DataRow)Session["data_user"];
            try {
                
               LmasterUsername.Text = datos_user["username"].ToString();
            } catch { }
            try
            {
                LPerfil datos_usuario = new LPerfil();
                Uvista_perfil datos = datos_usuario.vista_perfil(Int32.Parse(Session["user_id"].ToString()));
                ImasterAvatar.ImageUrl = datos.ImageUrl;
            }
            catch { }

        }

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
}