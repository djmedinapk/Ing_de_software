using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
using System.Collections;

public partial class view_perfil_verPerfil : System.Web.UI.Page
{
    public String userid;
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
        try
        {
            userid = Request.QueryString[0].ToString();
            cargar_datos_pagina(sender,e);
        }
        catch
        {
            Response.Redirect("~/view/home/index.aspx");
        }

        Int32 idioma = 2;
        Int32 id_pagina = 22;
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
        L_publicaciones.Text = controles["L_publicaciones"].ToString();
        L_informacion.Text = controles["L_informacion"].ToString();
        L_nombre.Text = controles["L_nombre"].ToString();
        L_edad.Text = controles["L_edad"].ToString();
        L_genero.Text = controles["L_genero"].ToString();

    }
    protected void cargar_datos_pagina(object sender, EventArgs e) {

        LPerfil datos_usuario = new LPerfil();
        Uvista_perfil datos_user = datos_usuario.vista_perfil(Int32.Parse(userid));
        
            Iperfil.ImageUrl = datos_user.ImageUrl;
            Lusername.Text = datos_user.Username;
            LtotalPublic.Text = datos_user.TotalPublic;
            Lestado.Text = datos_user.Estado;
            Lnombre.Text = datos_user.Nombre;
            Ledad.Text = datos_user.Edad;
            Lgenero.Text = datos_user.Genero;
        try { 
            Response.Redirect(datos_user.Response);
        }
        catch
        {

        }
        



    }
}