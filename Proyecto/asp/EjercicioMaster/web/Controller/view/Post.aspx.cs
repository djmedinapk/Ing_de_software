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



    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        if(Session["username"] == null || Session["user_id"] == null)
        {
            string frase = "Inicia Sesion Para Poder Realizar La Denuncia";
            Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>  <a href='../login/ingresar.aspx'  class='btn btn-success'>Iniciar Sesion</a>   <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
               "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
            TdenunciaComentarioText.Text = "";
        }
        else
        {
            Lpopup.Text = "";
            try {
                DAOdenuncia comentario = new DAOdenuncia();
                Int32 user_id = Int32.Parse(Session["user_id"].ToString());
                Int32 comentario_id = Int32.Parse(TdenunciaComentarioID.Text.ToString());
                string descripcion = TdenunciaComentarioText.Text.ToString();
                DataTable informacion = comentario.denuncia_comentario(user_id, comentario_id, descripcion);
                if (informacion.Rows.Count != 0)
                {
                    string frase = informacion.Rows[0][0].ToString();
                    Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                    TdenunciaComentarioText.Text = "";
                }
                else
                {
                    string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                    Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";

                }
            } catch {
                string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                    Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                    
                
            }
            
        }
        
    }
    protected void BdenunciaPost_Click(object sender, EventArgs e)
    {
        Lpost post_logica = new Lpost();
        String username = Session["username"].ToString();
        String userid = Session["user_id"].ToString();
        Int32 publicacion_id = Int32.Parse(post.ToString());
        String argumento = TdenunciaPostText.Text.ToString();
        String opcion = DDLopcion.SelectedValue.ToString();
        String [] mensaje = post_logica.recibir_denuncia_post(userid, username, publicacion_id, opcion, argumento);
        Lpopup.Text = mensaje[0];
        TdenunciaComentarioText.Text = mensaje[1];
        /*if (Session["username"] == null || Session["user_id"] == null)
        {
            string frase = "Inicia Sesion Para Poder Realizar La Denuncia";
            Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>  <a href='../login/ingresar.aspx'  class='btn btn-success'>Iniciar Sesion</a>   <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
               "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
            TdenunciaComentarioText.Text = "";
        }*/
        /*else
        {
            Lpopup.Text = "";
            try
            {
                DAOdenuncia denuncia = new DAOdenuncia();
                Int32 user_id = Int32.Parse(Session["user_id"].ToString());
                Int32 publicacion_id = Int32.Parse(post.ToString());
                switch (DDLopcion.SelectedValue.ToString())
                {
                    case "1" :
                        descripcion = "Viola derechos de autor - ";
                        break;
                    case "2":
                        descripcion = "Contenido Inapropiado - ";
                        break;
                    default:
                        descripcion = "Otro - ";
                        break;

                }
                descripcion += TdenunciaPostText.Text.ToString();
                DataTable informacion = denuncia.denuncia_publicacion(user_id, publicacion_id, descripcion);
                if (informacion.Rows.Count != 0)
                {
                    string frase = informacion.Rows[0][0].ToString();
                    Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                    TdenunciaComentarioText.Text = "";
                }
                else
                {
                    string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                    Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";

                }
            }
            catch
            {
                string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";


            }

        }*/

    }
    protected void enviar_puntuacion(object sender, EventArgs e, int puntuacion)
    {
        if (Session["username"] == null || Session["user_id"] == null)
        {
            string frase = "Inicia Sesion Para Poder Puntuar este Post";
            Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>  <a href='../login/ingresar.aspx'  class='btn btn-success'>Iniciar Sesion</a>   <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
               "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
            TdenunciaComentarioText.Text = "";
        }
        else
        {
            try
            {
                DAOpost puntuar = new DAOpost();
                Int32 user_id = Int32.Parse(Session["user_id"].ToString());
                Int32 post_id = Int32.Parse(post.ToString());
                DataTable informacion = puntuar.puntuar_post(puntuacion, user_id, post_id);
                if (informacion.Rows.Count != 0)
                {
                    string frase = informacion.Rows[0][0].ToString();
                    Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                }
                else
                {
                    string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                    Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";

                }

            } catch {
                string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
            }
            
        }
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["user_id"] == null)
        {
            string frase = "Inicia Sesion Para Poder Poder Comentar";
            Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>  <a href='../login/ingresar.aspx'  class='btn btn-success'>Iniciar Sesion</a>   <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
               "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
            TdenunciaComentarioText.Text = "";
        }
        else
        {
            Lpopup.Text = "";
            try
            {
                DAOpost comentario = new DAOpost();
                String contenido = TAcomentario.Text.ToString();
                Int32 comentario_id= Int32.Parse(Tidcomentario.Text.ToString());
                Int32 user_id = Int32.Parse(Session["user_id"].ToString());
                Int32 post_id = Int32.Parse(post.ToString());
                DataTable informacion = comentario.comentar_post(comentario_id,user_id, post_id, contenido);
                if (informacion.Rows.Count != 0)
                {
                    string frase = informacion.Rows[0][0].ToString();
                    Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                       "setInterval('guardar()', 1500);" +
                       "function guardar() { window.location.href='" + "Post.aspx?id=" + post.ToString() + "'; }</script>";
                    TAcomentario.Text = "";
                    //Response.Redirect("~/view/post/Post.aspx?id=" + post.ToString());
                }
                else
                {
                    string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                    Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                       "setInterval('guardar()', 1500);" +
                       "function guardar() { window.location.href='" + "Post.aspx?id=" + post.ToString() + "'; }</script>";

                }
            }
            catch
            {
                string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                       "setInterval('guardar()', 1500);" +
                       "function guardar() { window.location.href='" + "Post.aspx?id=" + post.ToString() + "'; }</script>";


            }

        }
        
    }

}