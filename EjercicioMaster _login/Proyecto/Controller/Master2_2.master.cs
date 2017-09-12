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
        if (Session["usuario"] != null)
        {
            switch (Session["rol"])
            {
                case 1:
                    Response.Redirect("home.aspx");
                    break;
                case 2:
                    Lusername.Text = (String)Session["username_usuario"];
                    break;                                             //Faltan 2 paginas para los roles!!
                case 3:
                    Response.Redirect("home.aspx");
                    break;
                case 4:
                    Lusername.Text = (String)Session["username_usuario"];
                    break;
                case 5:

                    break;
                default:
                    Response.Redirect("home.aspx");
                    break;

            }

        }
        else
        {
            Response.Redirect("home.aspx");
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
