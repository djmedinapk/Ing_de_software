using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Collections;

public partial class view_nueva_contraseña : System.Web.UI.Page
{
    public String token;
    protected void Page_Load(object sender, EventArgs e)
    {
        L_respuesta.Text = "";
        try {
            token = Request.QueryString[0];
        }
        catch
        {
            Response.Redirect("ingresar.aspx");
        }
        
        LresetPass validar = new LresetPass();
        try
        {
            Response.Redirect(validar.validar(token));
            
        }
        catch
        {
            
        }
        //DAOResetPass validacion = new DAOResetPass();
        //System.Data.DataTable validez = validacion.Validartoken(token);
        //if(int.Parse(validez.Rows[0][0].ToString()) != 1) {
        //    Response.Redirect("ingresar.aspx");
        //}
        Int32 idioma = 2;
        Int32 id_pagina = 9;
        try
        {
            idioma = Int32.Parse(Session["idioma"].ToString());
            Lotros post = new Lotros();
        }
        catch
        {
            idioma = 2;
        }

        Lidioma cargar_controles = new Lidioma();
        Hashtable controles = cargar_controles.cargar_controles(id_pagina, idioma);
        L_nueva_contraseña.Text = controles["L_nueva_contraseña"].ToString();
        TNewPassUser.Attributes["placeholder"] = controles["TNewPassUser"].ToString();
        TNewPassUser2.Attributes["placeholder"] = controles["TNewPassUser2"].ToString();
        BCambiarcontraseña.Text = controles["BCambiarcontraseña"].ToString();
    }

    protected void BCambiarcontraseña_Click(object sender, EventArgs e)
    {
        //DAOResetPass reset = new DAOResetPass();
        //System.Data.DataTable validez = reset.CambiarContraseña(encryption(TNewPassUser.Text.ToString()),token);
        //if(int.Parse(validez.Rows[0][0].ToString()) == 1)
        //{
        //    L_respuesta.ForeColor = System.Drawing.Color.Green;
        //    L_respuesta.Text = "Su contraseña ha sido restablecida";
        //    Response.Redirect("redirect_login.aspx");
        //}
        //else if (int.Parse(validez.Rows[0].ToString()) == 0)
        //{
        //    L_respuesta.ForeColor = System.Drawing.Color.Red;
        //    L_respuesta.Text = "No puede cambiarse la contraseña";
        //}
        LresetPass cambiarpass = new LresetPass();
        String[] respuesta = cambiarpass.cambiarpass(TNewPassUser.Text.ToString(), token);
        L_respuesta.Text = respuesta[1];
        switch (respuesta[0])
        {
            case "Blue":
                L_respuesta.ForeColor = System.Drawing.Color.Blue;
                break;
            case "Red":
                L_respuesta.ForeColor = System.Drawing.Color.Red;
                break;
            case "Green":
                L_respuesta.ForeColor = System.Drawing.Color.Green;
                break;
        }
        try
        {
            Response.Redirect(respuesta[2]);
        }
        catch { }
    }
    
}