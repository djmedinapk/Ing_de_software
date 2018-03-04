using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class view_moderador_moderador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (Session["username"] == null || Session["user_id"] == null)
        {
            Session["username"] = null;
            Session["user_id"] = null;
            Session["Iperfil_url"] = null;
            Response.Redirect("../login/ingresar.aspx");
        }
        else
        {
            // TperfilUsuario.Text = Session["username"].ToString();
            if (IsPostBack)
            {
                // BperfilMod_Click(sender, e);
                //Iperfil.ImageUrl = Session["Iperfil_url"].ToString();
                //Lusername.Text = Session["username"].ToString();
            }
            else
            { 
                //Iperfil.ImageUrl = Session["Iperfil_url"].ToString();
                //Lusername.Text = Session["username"].ToString();
            }
            var papas = (DataRow)Session["data_user"];
            if (int.Parse(papas["id_permisos"].ToString()) == 1 || int.Parse(papas["id_permisos"].ToString()) == 4 || int.Parse(papas["id_permisos"].ToString()) == 2)
            {
                if (int.Parse(papas["id_permisos"].ToString()) == 1 )
                {
                    Panelprivado.Visible = false;
                }
                else { Panelprivado.Visible = true; }
            }
            else
            {
                Response.Redirect("~\\View\\perfil\\perfil.aspx");

            }

        }
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
        Lpost eliminar = new Lpost();
        Lpost post = new Lpost();
        post.aceptar_denuncia(postid, e.CommandName);
        Response.Redirect("../moderador/moderador.aspx");
    }
}