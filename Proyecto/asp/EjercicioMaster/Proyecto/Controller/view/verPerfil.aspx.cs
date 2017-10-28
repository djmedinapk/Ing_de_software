using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_perfil_verPerfil : System.Web.UI.Page
{
    public String userid;
    void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            this.MasterPageFile = "~/Master2_2.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            userid = Request.QueryString[0].ToString();

            
            if (!IsPostBack)
            {
                cargar_datos_pagina(sender,e);
            }
        }
        catch
        {
            Response.Redirect("~/view/home/index.aspx");
        }
    }
    protected void cargar_datos_pagina(object sender, EventArgs e) {

        DAOperfil datos_usuario = new DAOperfil();
        DataTable datos_user = datos_usuario.traerDatos_vistaPerfil(Int32.Parse(userid));
        if (datos_user.Rows.Count > 0)
        {
            Iperfil.ImageUrl = datos_user.Rows[0]["avatar"].ToString();
            Lusername.Text = datos_user.Rows[0]["username"].ToString();
            LtotalPublic.Text = datos_user.Rows[0]["posts"].ToString();
        }
        else
        {
            Response.Redirect("~/view/home/index.aspx");
        }
        



    }
}