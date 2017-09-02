using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_rol_3 : System.Web.UI.Page
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
                    break;
                case 3:
                    
                    break;
                case 4:
                    Response.Redirect("rol_4.aspx");
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