using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Collections;
using System.Data;

public partial class view_home_categoria : System.Web.UI.Page
{
 void Page_PreInit(Object sender, EventArgs e)
    {
        Lotros master = new Lotros();
        try {
            this.MasterPageFile = master.aux2((DataRow)Session["data_user"]);
        } catch { }
        
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 idioma = 2;
        Int32 id_pagina = 4;
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
        L_categorias.Text = controles["L_categorias"].ToString();
        hver.Text= controles["hver"].ToString();
        htitulo.Text= controles["htitulo"].ToString();
        hfecha.Text= controles["hfecha"].ToString();
        hdescripcion.Text= controles["hdescripcion"].ToString();
        hvisitas.Text= controles["hvisitas"].ToString();

        //ListView1.FindControl("verr");
        

    }
}