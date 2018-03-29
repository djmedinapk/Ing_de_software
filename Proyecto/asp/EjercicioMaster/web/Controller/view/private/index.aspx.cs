using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Collections;

public partial class view_Private_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Int32 idioma = 2;
        Int32 id_pagina = 19;
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
        L_bienvenido1.Text = controles["L_bienvenido1"].ToString();
        L_biendenido1_1.Text = controles["L_biendenido1_1"].ToString();
        L_bienvenido2.Text = controles["L_bienvenido2"].ToString();
        L_bienvenido2_2.Text = controles["L_bienvenido2_2"].ToString();
        L_anterior.Text = controles["L_anterior"].ToString();
        L_siguiente.Text = controles["L_siguiente"].ToString();
        L_mas_vistos.Text = controles["L_mas_vistos"].ToString();
        L_mas_votados.Text = controles["L_mas_votados"].ToString();
        L_recientes.Text = controles["L_recientes"].ToString();
        //L_ir_a1.Text = controles["L_ir_a1"].ToString();
        //L_ir_a2.Text = controles["L_ir_a2"].ToString();
        //L_ir_a3.Text = controles["L_ir_a3"].ToString();


    }
}