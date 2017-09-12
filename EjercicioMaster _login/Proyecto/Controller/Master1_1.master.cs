using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master1 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"]==null)
        {
            Response.Redirect("home.aspx");
            Lusername.Text = null;
        }
        else
        {
            Lusername.Text = (String)Session["username_usuario"];
        }
    }

    protected void Bminiatura_salir_Click(object sender, EventArgs e)
    {
        Session["usuario"] = null;
        Session["idusuario"] = null;
        Session["username_usuario"] = null;
        Session["rol"] = null;
        if (Session["usuario"] == null)
        {
            Response.Redirect("home.aspx");
        }
    }
}
