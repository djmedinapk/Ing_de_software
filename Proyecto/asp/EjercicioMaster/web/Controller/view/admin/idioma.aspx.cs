using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class view_admin_idioma : System.Web.UI.Page
{
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
}