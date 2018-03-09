using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class view_post_Post : System.Web.UI.Page
{
    public String post;
    public String control;
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
            post = Request.QueryString[0].ToString();
            cargar_post();
        }
        catch
        {
            Response.Redirect("~/view/home/index.aspx");
        }
        
    }
    protected void cargar_post()
    {
        Lpost DApost = new Lpost();
       Upost3 datospost = DApost.ver_post(int.Parse(post.ToString()),(DataRow)Session["data_user"]);
        try
        {
            LpostTitulo.Text = datospost.Titulo;
            LpostContenido.Text = datospost.Contenido;
            LpostFuentes.Text = datospost.Fuentes;
            LpostCategoria.Text = datospost.Categoria;
            LpostUsername.Text = datospost.Username;
            IpostAvatar.ImageUrl = datospost.Avatar;
            HLavatarImagen.NavigateUrl = datospost.Avatarimg;
            LtotalPublic.Text = datospost.Totalpubs;
            LcargarComentarios.Text = datospost.Totalcoments;

            Bpunt1.Visible = datospost.P1;
            Bpunt2.Visible = datospost.P2;
            Bpunt3.Visible = datospost.P3;
            Bpunt4.Visible = datospost.P4;
            Bpunt5.Visible = datospost.P5;
            Lpuntuacionn.Text = datospost.Lpuntuacion1;
            BagregarComentario.Visible = datospost.BagregarComentario1;
            panel_comentario.Visible = datospost.PagregarComentario1;
        }
        catch
        {
            Response.Redirect("../home/index.aspx");
        }
        try
        {
            Response.Redirect(datospost.Respons);
        }
        catch { }
        
    }



    protected void BDenuncia_comentario(object sender, EventArgs e)   //Boton denuncia de comentarios!!!
    {
        String username;
        String userid;
        Lpost post_logica = new Lpost();
        try
        {
            username = Session["username"].ToString();
            userid = Session["user_id"].ToString();
        }
        catch
        {
            username = null;
            userid = null;
        }
        Int32 comentario_id = Int32.Parse(TdenunciaComentarioID.Text.ToString());
        String descripcion = TdenunciaComentarioText.Text.ToString();
        String[] mensaje = post_logica.Denuncia_comentario(userid, username, comentario_id, descripcion);
        Lpopup.Text = mensaje[0];
        TdenunciaComentarioText.Text = mensaje[1];
    }

    protected void Bdenuncia_Post(object sender, EventArgs e)     //Envia la denuncia de un post
    {
        String username;
        String userid;
        Lpost post_logica = new Lpost();
        try
        {
            username = Session["username"].ToString();
            userid = Session["user_id"].ToString();
        }
        catch
        {
            username = null;
            userid = null;
        }

        Int32 publicacion_id = Int32.Parse(post.ToString());
        String argumento = TdenunciaPostText.Text.ToString();
        String opcion = DDLopcion.SelectedValue.ToString();
        String [] mensaje = post_logica.recibir_denuncia_post(userid, username, publicacion_id, opcion, argumento);
        Lpopup.Text = mensaje[0];
        TdenunciaComentarioText.Text = mensaje[1];

    }
    protected void enviar_puntuacion(object sender, EventArgs e, int puntuacion)       //Envia la puntuacion del post
    {
        String username;
        String userid;
        Lpost post_logica = new Lpost();
        try
        {
            username = Session["username"].ToString();
            userid = Session["user_id"].ToString();
        }
        catch
        {
            username = null;
            userid = null;
        }
        
        Int32 publicacion_id = Int32.Parse(post.ToString());
        String[] mensaje = post_logica.enviarPuntuacion(userid, username, publicacion_id,puntuacion);
        Lpopup.Text = mensaje[0];
        TdenunciaComentarioText.Text = mensaje[1];
    }

    protected void Bpunt1_Click(object sender, EventArgs e)
    {
        int valor = 1;
        enviar_puntuacion(sender, e, valor);
    }

    protected void Bpunt2_Click(object sender, EventArgs e)
    {
        int valor = 2;
        enviar_puntuacion(sender, e, valor);
    }

    protected void Bpunt3_Click(object sender, EventArgs e)
    {
        int valor = 3;
        enviar_puntuacion(sender, e, valor);
    }

    protected void Bpunt4_Click(object sender, EventArgs e)
    {
        int valor = 4;
        enviar_puntuacion(sender, e, valor);
    }

    protected void Bpunt5_Click(object sender, EventArgs e)
    {
        int valor = 5;
        enviar_puntuacion(sender, e, valor);
    }

    protected void Bagregar_comentario(object sender, EventArgs e)                   //Boton para agregar el comentario!!!!
    {
        String username;
        String userid;
        Lpost post_logica = new Lpost();
        try
        {
            username = Session["username"].ToString();
            userid = Session["user_id"].ToString();
        }
        catch
        {
            username = null;
            userid = null;
        }
        String contenido = TAcomentario.Text.ToString();
        Int32 comentario_id = Int32.Parse(Tidcomentario.Text.ToString());
        Int32 post_id = Int32.Parse(post.ToString());
        String[] mensaje = post_logica.agregar_comentario(userid, username, comentario_id, post_id, contenido);
        Lpopup.Text = mensaje[0];
        TdenunciaComentarioText.Text = mensaje[1];
        TAcomentario.Text = mensaje[2];

    }

}