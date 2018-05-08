using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class view_admin_idioma : System.Web.UI.Page
{
    Int32 idform = 1;
    Int32 idIdio = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 idioma = 2;
        Int32 id_pagina = 25;
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
        L_agregar_idioma.Text = controles["L_agregar_idioma"].ToString();
        Tnombre.Attributes["placeholder"] = controles["Tnombre"].ToString();
        Tcultura.Attributes["placeholder"] = controles["Tcultura"].ToString();
        BTNagregarIdioma.Text = controles["BTNagregarIdioma"].ToString();
        L_cargar_idioma.Text = controles["L_cargar_idioma"].ToString();
        L_lenguaje.Text = controles["L_lenguaje"].ToString();
        L_lenguaje_pag.Text = controles["L_lenguaje_pag"].ToString();
        L_idiomas.Text = controles["L_idiomas"].ToString(); 
    }

    protected void BTNagregarIdioma_Click(object sender, EventArgs e)
    {
        Lidioma idioma = new Lidioma();
        Uidioma_agregar datos = new Uidioma_agregar();
        datos.Idioma = Tnombre.Text.ToString();
        datos.Terminacion=Tcultura.Text.ToString();
        idioma.agregar_idioma(datos);
        Response.Redirect("~/view/admin/idioma.aspx");
    }


    protected void DDL_Leng_pag_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        idform = DDL_Leng_pag.SelectedIndex;
        idIdio = DDL_lenguaje.SelectedIndex;
        Lidioma idioma = new Lidioma();
        DataTable datos = idioma.cargar_ctrl(idform,idIdio);
        //Gridcontroles.DataSource = datos;
        //datos.Columns.Cast<DataColumn>().ToList().ForEach(column => ListCtrl.Columns.Add(column.Caption));
        Gridcontroles.DataBind();
    }

    protected void guardar_control(String control, String texto)
    {
        Lidioma idioma = new Lidioma();
        Uidioma_controles controles = new Uidioma_controles();
        controles.Idioma = Int32.Parse(DDL_lenguaje.SelectedValue);
        controles.Control = control;
        controles.Formulario = Int32.Parse(DDL_Leng_pag.SelectedValue.ToString());
        controles.Texto = texto;
    }
    protected DataTable cargar_crt(Int32 form, Int32 idioma)
    {
        Lidioma idiomas = new Lidioma();
        DataTable datos = idiomas.cargar_ctrl(form, idioma);
        return datos;
    }

    protected void Beliminar_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "eliminar")
        {
            Int32 id = Int32.Parse(e.CommandArgument.ToString());
            Lidioma idioma = new Lidioma();
            idioma.eliminar_idioma(id);
            Response.Redirect("~/view/admin/idioma.aspx");
        }
    }



    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "update")
        {  
            
         
        }
    }

    protected void Controlupdating(object sender, GridViewUpdateEventArgs e)
    {
        Lidioma idioma = new Lidioma(); 
        var a = Int32.Parse(DDL_lenguaje.SelectedValue);
        var b = Int32.Parse(DDL_Leng_pag.SelectedValue.ToString());
        TextBox valor = Gridcontroles.Rows[e.RowIndex].FindControl("Tbtexto") as TextBox;
        Label control = Gridcontroles.Rows[e.RowIndex].FindControl("control") as Label;
        String texto = valor.Text;
        String ctrl = control.Text;
        idioma.modificar_control(ctrl, a, b, texto);
    }
}