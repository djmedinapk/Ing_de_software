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
    public String control;
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
        try
        {
            post = Request.QueryString[0].ToString();
            DAOpost DApost = new DAOpost();
            DataTable datosPost = DApost.ver_post(int.Parse(post.ToString()));
            cargar_post(sender, e, datosPost);
            DAOpost visitar = new DAOpost();
            DataTable visita = visitar.visita_post(int.Parse(post.ToString()));
        }
        catch
        {
            Response.Redirect("~/view/home/index.aspx");
        }
        
    }
    protected void cargar_post(object sender, EventArgs e,DataTable datospost)
    {
        if (datospost.Rows.Count > 0)
        {
            if (datospost.Rows[0]["estado"].ToString()=="Activo") {
                LpostTitulo.Text = datospost.Rows[0]["titulo"].ToString();
                LpostContenido.Text = datospost.Rows[0]["contenido"].ToString();
                LpostFuentes.Text = "Fuente: " + datospost.Rows[0]["fuente"].ToString();
                LpostCategoria.Text = "Categoria(s): " + datospost.Rows[0]["categoria"].ToString();
                LpostUsername.Text = datospost.Rows[0]["username"].ToString();
                IpostAvatar.ImageUrl = datospost.Rows[0]["avatar_username"].ToString();
                String urlPerfil = "~/view/perfil/verPerfil.aspx?id=" + datospost.Rows[0]["id_usuario"].ToString();
                HLavatarImagen.NavigateUrl = urlPerfil;
                LtotalPublic.Text = datospost.Rows[0]["posts"].ToString();
                LcargarComentarios.Text = datospost.Rows[0]["comentarios"].ToString() + " Comentarios";
            }
            else
            {
                if (Session["data_user"] != null)
                {
                    var papas = (DataRow)Session["data_user"];
                    if (int.Parse(papas["id_permisos"].ToString()) == 1 || int.Parse(papas["id_permisos"].ToString()) == 4 || int.Parse(papas["id"].ToString())==int.Parse(datospost.Rows[0]["id_usuario"].ToString()))
                    {
                        LpostTitulo.Text = datospost.Rows[0]["titulo"].ToString();
                        LpostContenido.Text = datospost.Rows[0]["contenido"].ToString();
                        LpostFuentes.Text = "Fuente: " + datospost.Rows[0]["fuente"].ToString();
                        LpostCategoria.Text = "Categoria(s): " + datospost.Rows[0]["categoria"].ToString();
                        LpostUsername.Text = datospost.Rows[0]["username"].ToString();
                        IpostAvatar.ImageUrl = datospost.Rows[0]["avatar_username"].ToString();
                        String urlPerfil = "~/view/perfil/verPerfil.aspx?id=" + datospost.Rows[0]["id_usuario"].ToString();
                        HLavatarImagen.NavigateUrl = urlPerfil;
                        Bpunt1.Visible = false;
                        Bpunt2.Visible = false;
                        Bpunt3.Visible = false;
                        Bpunt4.Visible = false;
                        Bpunt5.Visible = false;
                        Lpuntuacionn.Text = "";
                        BagregarComentario.Visible = false;
                        panel_comentario.Visible = false;
                    }
                    else
                    {
                        Response.Redirect("../home/index.aspx");

                    }
                }
                else
                {
                    Response.Redirect("../home/index.aspx");

                }
            }
           
        }
        else
        {
            Response.Redirect("../home/index.aspx");
        }
        
    }



    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        if(Session["username"] == null || Session["user_id"] == null)
        {
            string frase = "Inicia Sesion Para Poder Realizar La Denuncia";
            Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>  <a href='../login/ingresar.aspx'  class='btn btn-success'>Iniciar Sesion</a>   <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
               "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
            TdenunciaComentarioText.Value = "";
        }
        else
        {
            Lpopup.Text = "";
            try {
                DAOdenuncia comentario = new DAOdenuncia();
                Int32 user_id = Int32.Parse(Session["user_id"].ToString());
                Int32 comentario_id = Int32.Parse(TdenunciaComentarioID.Text.ToString());
                string descripcion = TdenunciaComentarioText.Value.ToString();
                DataTable informacion = comentario.denuncia_comentario(user_id, comentario_id, descripcion);
                if (informacion.Rows.Count != 0)
                {
                    string frase = informacion.Rows[0][0].ToString();
                    Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                    TdenunciaComentarioText.Value = "";
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
        string descripcion;
        if (Session["username"] == null || Session["user_id"] == null)
        {
            string frase = "Inicia Sesion Para Poder Realizar La Denuncia";
            Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>  <a href='../login/ingresar.aspx'  class='btn btn-success'>Iniciar Sesion</a>   <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
               "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
            TdenunciaComentarioText.Value = "";
        }
        else
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
                descripcion += TdenunciaPostText.Value.ToString();
                DataTable informacion = denuncia.denuncia_publicacion(user_id, publicacion_id, descripcion);
                if (informacion.Rows.Count != 0)
                {
                    string frase = informacion.Rows[0][0].ToString();
                    Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                    TdenunciaComentarioText.Value = "";
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

        }

    }
    protected void enviar_puntuacion(object sender, EventArgs e, int puntuacion)
    {
        if (Session["username"] == null || Session["user_id"] == null)
        {
            string frase = "Inicia Sesion Para Poder Puntuar este Post";
            Lpopup.Text = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>  <a href='../login/ingresar.aspx'  class='btn btn-success'>Iniciar Sesion</a>   <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
               "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
            TdenunciaComentarioText.Value = "";
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
            TdenunciaComentarioText.Value = "";
        }
        else
        {
            Lpopup.Text = "";
            try
            {
                DAOpost comentario = new DAOpost();
                String contenido = TAcomentario.Value.ToString();
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
                    TAcomentario.Value = "";
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