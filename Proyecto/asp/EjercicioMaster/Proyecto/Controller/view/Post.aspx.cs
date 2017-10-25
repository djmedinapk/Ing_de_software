using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_post_Post : System.Web.UI.Page
{
    public String post;
    void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            this.MasterPageFile = "~/Master2_2.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["user_id"] == null)
        {
            Session["username"] = null;
            Session["user_id"] = null;
            Session["Iperfil_url"] = null;
            //Response.Redirect("../login/ingresar.aspx");
        }
        else
        {
            //// TperfilUsuario.Text = Session["username"].ToString();
            //if (IsPostBack)
            //{

            //}
            //else
            //{
                
            //}

        }
        post = Request.QueryString[0].ToString();
        DAOpost DApost = new DAOpost();
        DataTable datosPost = DApost.ver_post(int.Parse(post.ToString()));
        cargar_post(sender,e, datosPost);
        DAOpost visitar = new DAOpost();
        DataTable visita = visitar.visita_post(int.Parse(post.ToString()));
    }
    protected void cargar_post(object sender, EventArgs e,DataTable datospost)
    {
        if (datospost.Rows.Count > 0)
        {
            LpostTitulo.Text = datospost.Rows[0]["titulo"].ToString();
            LpostContenido.Text = datospost.Rows[0]["contenido"].ToString();
            LpostFuentes.Text = "Fuente: "+datospost.Rows[0]["fuente"].ToString();
            LpostCategoria.Text = "Categoria(s): "+datospost.Rows[0]["categoria"].ToString();
            LpostUsername.Text = datospost.Rows[0]["username"].ToString();
            IpostAvatar.ImageUrl = datospost.Rows[0]["avatar_username"].ToString();
            LcargarComentarios.Text = datospost.Rows[0]["comentarios"].ToString() + " Comentarios";
        }
        
    }
}