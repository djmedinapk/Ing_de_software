using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Collections;

public partial class view_home_categoria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Int32 idioma = 2;
        Int32 id_pagina = 18;
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
        L_categoria.Text = controles["L_categoria"].ToString();
        //id_post.text = controles["id_post"].ToString();

    }
}