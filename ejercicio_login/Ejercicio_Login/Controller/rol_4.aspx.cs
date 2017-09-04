using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_rol_4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            switch (Session["usuario"])
            {
                case 1:
                    Response.Redirect("rol_1.aspx");
                    break;
                case 2:
                    Response.Redirect("rol_2.aspx");
                    break;                                             //Faltan 2 paginas para los roles!!
                case 3:
                    Response.Redirect("rol_3.aspx");
                    break;
                case 4:
                    
                    break;
                default:
                    Response.Redirect("Login.aspx");
                    break;

            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["usuario"] = null;
        Response.Redirect("Login.aspx");
    }
}