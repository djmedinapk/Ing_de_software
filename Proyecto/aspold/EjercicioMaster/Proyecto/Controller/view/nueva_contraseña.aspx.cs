using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_nueva_contraseña : System.Web.UI.Page
{
    public String token;
    protected void Page_Load(object sender, EventArgs e)
    {
        L_respuesta.Text = "";
        token = Request.QueryString[0];
        DAOResetPass validacion = new DAOResetPass();
        System.Data.DataTable validez = validacion.Validartoken(token);
        if(int.Parse(validez.Rows[0][0].ToString()) != 1) {
            Response.Redirect("ingresar.aspx");
        }
    }

    protected void BCambiarcontraseña_Click(object sender, EventArgs e)
    {
        DAOResetPass reset = new DAOResetPass();
        System.Data.DataTable validez = reset.CambiarContraseña(TNewPassUser.Text.ToString(),token);
        if(int.Parse(validez.Rows[0][0].ToString()) == 1)
        {
            L_respuesta.ForeColor = System.Drawing.Color.Green;
            L_respuesta.Text = "Su contraseña ha sido restablecida";
            Response.Redirect("redirect_login.aspx");
        }
        else if (int.Parse(validez.Rows[0].ToString()) == 0)
        {
            L_respuesta.ForeColor = System.Drawing.Color.Red;
            L_respuesta.Text = "No puede cambiarse la contraseña";
        }
    }
}