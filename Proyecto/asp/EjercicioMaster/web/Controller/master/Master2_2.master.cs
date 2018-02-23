using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                DAOperfil datos_usuario = new DAOperfil();
                DataTable datos = datos_usuario.traerDatos_vistaPerfil(Int32.Parse(Session["user_id"].ToString()));
                if (datos.Rows.Count > 0)
                {
                    ImasterAvatar.ImageUrl = datos.Rows[0]["avatar"].ToString();
                }
                else
                {
                    ImasterAvatar.ImageUrl = "~\\Imagenes\\Default\\123.jpg";
                }
            }
            catch { }

        }

    }
    protected void Bminiatura_salir_Click(object sender, EventArgs e)
        {
            Session["user_id"] = null;
            Session["username"] = null;
            Session["data_user"] = null;
            Session.Clear();


        DAOUsuario user = new DAOUsuario();
            Eusuario datos = new Eusuario
            {
                Session = Session.SessionID
            };
            user.CerrarSession(datos);

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