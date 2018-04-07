using System;
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
        controles.Idioma = DDL_lenguaje.SelectedIndex;
        controles.Control = control;
        controles.Formulario = DDL_Leng_pag.SelectedIndex;
        controles.Texto = texto;
    }





}