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
                    Response.Redirect("home2_2.aspx");
                    break;                                             //Faltan 2 paginas para los roles!!
                case 3:
                    Response.Redirect("home.aspx");
                    break;
                case 4:
                    Response.Redirect("home2_2.aspx");
                    break;
                case 5:
                    Response.Redirect("homeAdmin.aspx");
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



}
