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
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Elogin login = new Elogin()
        //{
        //    Username = Tlogin_user.Text,
        //    Password = Tlogin_pass.Text
        //};
        //DAOtienda daoLogin = new DAOtienda();
        //DataTable informacion = daoLogin.consultar_login(login);
        //if (informacion.Rows.Count != 0)
        //{
        //    Session["usuario"] = informacion;
        //    Session["idusuario"] = informacion.Rows[0][0];
        //    Session["username_usuario"] = informacion.Rows[0][1];
        //    Session["rol"] = informacion.Rows[0][3];

        //    switch (informacion.Rows[0][5])
        //    {
        //        case 1:
        //            Response.Redirect("home1_1.aspx");
        //            break;
        //        case 2:
        //            Response.Redirect("home1_1.aspx");
        //            break;
        //        case 3:
        //            Response.Redirect("home1_1.aspx");
        //            break;
        //        case 4:
        //            Response.Redirect("home1_1.aspx");
        //            break;
        //        case 5:
        //            Response.Redirect("homeAdmin.aspx");
        //            break;
        //        default:
        //            Response.Redirect("home.aspx");
        //            break;
        //    }
        //}
    }
}
