using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Loginaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        Elogin login = new Elogin()
        {
            Username = Login1.UserName.ToString(),
            Password = Login1.Password.ToString()
        };
        DAOtienda daoLogin = new DAOtienda();
        DataTable informacion = daoLogin.consultar_login(login);
        if (informacion.Rows.Count != 0)
        {
            Session["usuario"] = informacion;
            Session["idusuario"] = informacion.Rows[0][0];
            Session["username_usuario"] = informacion.Rows[0][3];
            Session["nombre_usuario"] = informacion.Rows[0][1];

            switch (informacion.Rows[0][5])
            {
                case 1:
                    Response.Redirect("home.aspx");
                    break;
                case 2:
                    Response.Redirect("home.aspx");
                    break;                                             
                case 3:
                    Response.Redirect("home.aspx");
                    break;
                case 4:
                    Response.Redirect("home.aspx");
                    break;
                default:
                    Response.Redirect("Login.aspx");
                    break;

            }
        }
        else
        {
            
            //Lerror.ForeColor = System.Drawing.Color.Red;
            //Lerror.Text = "Datos erróneos";
        }
    }
}