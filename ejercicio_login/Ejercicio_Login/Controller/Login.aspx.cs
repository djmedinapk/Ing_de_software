using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Lerror.ForeColor = System.Drawing.Color.Black;
        Lerror.Text = "";
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
                    Response.Redirect("rol_4.aspx");
                    break;
                default:
                    Response.Redirect("Login.aspx");
                    break;

            }
        }
    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        Elogin login = new Elogin()
        {
            Username = Login1.UserName.ToString(),
            Password = Login1.Password.ToString()
        };
        DAOlogin daoLogin = new DAOlogin();
        DataTable informacion = daoLogin.consultar_login(login);
        if (informacion.Rows.Count != 0)
        {
            Session["usuario"]=informacion.Rows[0][0];
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
                    Response.Redirect("rol_4.aspx");
                    break;
                default:
                    Response.Redirect("Login.aspx");
                    break;

            }
        }
        else
        {
            Lerror.ForeColor = System.Drawing.Color.Red;
            Lerror.Text = "Datos erróneos";
        }
    }
}

    
