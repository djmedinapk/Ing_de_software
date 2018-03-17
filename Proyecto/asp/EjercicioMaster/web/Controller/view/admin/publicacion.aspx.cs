using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Data;

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
    }
}