using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Data;
using System.Collections;

public partial class view_home_Index : System.Web.UI.Page
{
    void Page_PreInit(Object sender, EventArgs e)
    {

        Lotros master = new Lotros();
        try
        {
            this.MasterPageFile = master.aux2((DataRow)Session["data_user"]);
        }
        catch { }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 idioma = 2;
        Int32 id_pagina = 6;
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
        L_mas_vistos.Text = controles["L_mas_vistos"].ToString();
        L_mas_votados.Text = controles["L_mas_votados"].ToString();
        L_recientes.Text = controles["L_recientes"].ToString();
        //HyperLink2.Text = controles["HyperLink2"].ToString();
        //HLhome.Text = controles["HLhome"].ToString();
        //HyperLink1.Text = controles["HyperLink1"].ToString();

    }


}