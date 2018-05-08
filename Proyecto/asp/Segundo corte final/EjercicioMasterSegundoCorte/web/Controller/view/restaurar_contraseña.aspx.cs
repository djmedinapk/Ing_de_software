using Newtonsoft.Json;
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

public partial class view_restaurar_contraseña : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_respuesta.Text = "";
        Int32 idioma = 2;
        Int32 id_pagina = 11;
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
        L_digite_nombre.Text = controles["L_digite_nombre"].ToString();
        TResetPassUser.Attributes["placeholder"] = controles["TResetPassUser"].ToString();
        BResetPass.Text = controles["BResetPass"].ToString();

    }

    protected void B_recuperar_Click(object sender, EventArgs e)
    {
        LresetPass rse = new LresetPass();
        String[] respuesta = rse.reset(TResetPassUser.Text.ToString());
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
        L_respuesta.Text = respuesta[1];
    }
}
