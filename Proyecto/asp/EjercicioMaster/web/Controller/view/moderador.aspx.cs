using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Collections;

public partial class view_moderador_moderador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LverificarSesion verificar = new LverificarSesion();
       try
        {
            Response.Redirect(verificar.verificar_sesion((DataRow)Session["data_user"], "../login/ingresar.aspx"));
        }
        catch
        {
            var papas = (DataRow)Session["data_user"];//"U1", "M1", "U2","M2",
            String[] permisos = new String[] { "AD", "M1", "M2" };
            
            try
            {
                Response.Redirect(verificar.verificar_permisos((DataRow)Session["data_user"], permisos, "~\\View\\perfil\\perfil.aspx"));
            }
            catch
            {
                Panelprivado.Visible = false;
                String[] permisos1 = new String[] { "AD", "M2" };
                Panelprivado.Visible = verificar.verificar_permisos_bool((DataRow)Session["data_user"], permisos1, "~\\View\\perfil\\perfil.aspx");
            }

        }

        //if (Session["username"] == null || Session["user_id"] == null)
        //{
        //    Session["username"] = null;
        //    Session["user_id"] = null;
        //    Session["Iperfil_url"] = null;
        //    Response.Redirect("../login/ingresar.aspx");
        //}
        //else
        //{
        //    // TperfilUsuario.Text = Session["username"].ToString();
        //    if (IsPostBack)
        //    {
        //        // BperfilMod_Click(sender, e);
        //        //Iperfil.ImageUrl = Session["Iperfil_url"].ToString();
        //        //Lusername.Text = Session["username"].ToString();
        //    }
        //    else
        //    {
        //        //Iperfil.ImageUrl = Session["Iperfil_url"].ToString();
        //        //Lusername.Text = Session["username"].ToString();
        //    }
        //    var papas = (DataRow)Session["data_user"];
        //    if (int.Parse(papas["id_permisos"].ToString()) == 1 || int.Parse(papas["id_permisos"].ToString()) == 4 || int.Parse(papas["id_permisos"].ToString()) == 2)
        //    {
        //        if (int.Parse(papas["id_permisos"].ToString()) == 1)
        //        {
        //            Panelprivado.Visible = false;
        //        }
        //        else { Panelprivado.Visible = true; }
        //    }
        //    else
        //    {
        //        Response.Redirect("~\\View\\perfil\\perfil.aspx");

        //    }

        //}
        Int32 idioma = 2;
        Int32 id_pagina = 12;
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
        L_comentarios.Text = controles["L_comentarios"].ToString();
        L_publicaciones1.Text = controles["L_publicaciones1"].ToString();
        L_publicas.Text = controles["L_publicas"].ToString();
        L_privadas.Text = controles["L_privadas"].ToString();
        //L_denuncias.Text = controles["L_denuncias"].ToString();
        //L_denuncias.Text = controles["L_denuncias"].ToString();
        //Beliminar.Text = controles["Beliminar"].ToString();

    }

    protected void Beliminar_Command(object sender, CommandEventArgs e)
    {
        Int32 postid = Int32.Parse(e.CommandArgument.ToString());
        Lpost eliminar = new Lpost();
        eliminar.eliminarPost(postid, e.CommandName, Session.SessionID);
        Response.Redirect("moderador.aspx");
    }
  

    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        Int32 postid = Int32.Parse(e.CommandArgument.ToString());
        Lpost post = new Lpost();
        post.aceptar_denuncia(postid, e.CommandName);
        Response.Redirect("../moderador/moderador.aspx");
    }
}