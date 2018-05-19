using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Collections;

public partial class view_Private_search : System.Web.UI.Page
{
    String busqueda;
    protected void Page_Load(object sender, EventArgs e)
    {
        Lotros aux = new Lotros();
        Int32 aux1;
        try {
            aux1 = Int32.Parse(aux.aux1(IsPostBack));
            busqueda = Request.QueryString["search"].ToString();
            Tsearch.Text = busqueda;
        } catch { busqueda = ""; }
        Int32 idioma = 2;
        Int32 id_pagina = 21;
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
        L_resultado_busqueda.Text = controles["L_resultado_busqueda"].ToString();


    }
}