using Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;

public partial class MasterAdmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 idioma = 2;
        Int32 id_pagina = 27;
        try
        {
            idioma = Int32.Parse(Session["idioma"].ToString());
            Lotros post = new Lotros();
            try
            {
                Int32 aux = Int32.Parse(post.aux1(!IsPostBack));
            }
            catch
            {
                DDL_lenguaje.SelectedValue = idioma.ToString();
            }

        }
        catch
        {
            idioma = 2;
        }

        Lidioma cargar_controles = new Lidioma();
        Hashtable controles = cargar_controles.cargar_controles(id_pagina, idioma);
        L_inicio.Text = controles["L_inicio"].ToString();
        L_idioma.Text = controles["L_idioma"].ToString();
        L_foro.Text = controles["L_foro"].ToString();
        L_usuario.Text = controles["L_usuario"].ToString();
        L_reportes.Text = controles["L_reportes"].ToString();
        L_publicaciones.Text = controles["L_publicaciones"].ToString();
    }

    protected void DDL_lenguaje_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 index = Int32.Parse(DDL_lenguaje.SelectedValue.ToString());
        Lidioma cambiar_cultura = new Lidioma();
        String cultura = cambiar_cultura.select_idioma(index);
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultura);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
        Session["idioma"] = index;
        Int32 id_pagina = 27;
        try
        {
            Lidioma cargar_controles = new Lidioma();
            Hashtable controles = cargar_controles.cargar_controles(id_pagina, index);
            L_inicio.Text = controles["L_inicio"].ToString();
            L_idioma.Text = controles["L_idioma"].ToString();
            L_publicaciones.Text = controles["L_publicaciones"].ToString();
            L_foro.Text = controles["L_foro"].ToString();
            L_usuario.Text = controles["L_usuario"].ToString();
            L_reportes.Text = controles["L_reportes"].ToString();
        }
        catch
        {

        }


    }
}
