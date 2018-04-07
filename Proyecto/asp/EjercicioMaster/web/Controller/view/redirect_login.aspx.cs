using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Collections;

public partial class view_login_redirect_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 idioma = 2;
        Int32 id_pagina = 10;
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
       Bredirect.Text = controles["Bredirect"].ToString();
       L_continuar.Text = controles["L_continuar"].ToString();
       L_restaurada.Text = controles["L_restaurada"].ToString();
    }

    protected void Bredirect_Click(object sender, EventArgs e)
    {
        Response.Redirect("../login/ingresar.aspx");
    }
}