using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (int.Parse(papas["id_permisos"].ToString()) == 1 || int.Parse(papas["id_permisos"].ToString()) == 4)
            {
               
            }
            else
            {
                Response.Redirect("~\\View\\perfil\\perfil.aspx");

            }

        }
    }

    protected void Beliminar_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "eliminar")
        {
            Int32 postid = Int32.Parse(e.CommandArgument.ToString());
            DAOpost eliminar = new DAOpost();
            DataTable informacion = eliminar.eliminar_post(postid, Session.SessionID);
            Response.Redirect("moderador.aspx");
        }
        if (e.CommandName == "validar")
        {
            Int32 postid = Int32.Parse(e.CommandArgument.ToString());
            DAOpost eliminar = new DAOpost();
            DataTable informacion = eliminar.validar_post(postid, Session.SessionID);
            Response.Redirect("moderador.aspx");
        }
    }
}