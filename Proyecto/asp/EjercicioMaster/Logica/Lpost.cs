using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using Encapsulados;
using System.Data;

namespace Logica
{
    public class Lpost
    {

        public String publicarPost(Upost datos,bool autor,String modo, String sesion,Int32 user_Id)
        {
            String respuesta = null;
            Dpost publicar = new Dpost();
            Epublicacion post = new Epublicacion();
            post.Nombre = datos.Nombre;
            post.Descripcion = datos.Descripcion;
            post.Contenido = datos.Contenido;
            post.Categoria = datos.Categoria;
            post.Etiquetas = datos.Etiquetas;
            post.Miniatura = datos.Miniatura;

            if (autor == true)
            {
                post.Autor = datos.Autor;
            }
            else
            {
                post.Autor = "El Contenido es de mi autoria y/o Recopilacion de varias fuentes";
            }

            DataTable informacion = null; 

            if (modo == "1")
            {
                informacion = publicar.ingresar_post(post, user_Id, sesion, 1);
            }
            else
            {
                informacion = publicar.ingresar_post(post, user_Id, sesion, 0);
            }



            if (informacion.Rows.Count != 0)
            {
                string frase = informacion.Rows[0][0].ToString();
                if (frase == "Ingreso_exitoso")
                {
                    string mensaje = "<strong>Se relizo la publicacion</strong>, espera a que un moderador la acepte";
                    respuesta = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + mensaje + "</div>      <div class='modal-footer'><a href='../perfil/perfil.aspx' data-dismiss='modal'  class='btn btn-success'>Ir a perfil</a>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                          "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                          "setInterval('guardar()', 1500);" +
                         "function guardar() { window.location.href=\"../perfil/perfil.aspx\"; }</script>";

                }
                else
                {
                    string mensaje = "Error al prrocesar la solicitud";
                    respuesta = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + mensaje + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                          "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                          "setInterval('guardar()', 1500);" +
                           "function guardar() { window.location.href=\"../perfil/perfil.aspx\"; }</script>";
                }

            }
            else
            {

                string mensaje = "<strong>Upssss!</strong> Algo ha salido mal intenta recargar la pagina y vuelve a intentarlo";
                respuesta = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + mensaje + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                          "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                          "setInterval('guardar()', 1500);" +
                           "function guardar() { window.location.href=\"../perfil/perfil.aspx\"; }</script>";
            }

            return respuesta;
        }

        public String[] modo(String mode, String sesion,DataRow datos)
        {
            // master 1_1: foro privado   2_2: foro publico
            String[] master = new String[2];
            //modo 1: foro privado 2:foro publico
            if (mode == "1")
            {
                // id de permisos 2 : admin
                if (datos["id_permisos"].ToString() == "2")

                {
                    master[0] = "~/Master1_1.master";
                    master[1] = "1";
                }
                else
                {
                    // sesion es el correo institucional
                    if (sesion == "")
                    {
                        master[0] = "~/Master2_2.master";
                        master[1] = "2";
                    }
                    else
                    {
                        master[0] = "~/Master1_1.master";
                        master[1] = "1";
                    }
                }
                
               
            }
            else { 
                master[0] = "~/Master2_2.master";
                master[1] = "2";
            }
            return master;
        }

        public void eliminarPost(Int32 post_id,String comando,String sesion)
        {
            if (comando=="eliminar")
            {
                
                Dpost eliminar = new Dpost();
                DataTable informacion = eliminar.eliminar_post(post_id, sesion);
            }
            if (comando == "validar")
            {
                Dpost validar = new Dpost();
                DataTable informacion = validar.validar_post(post_id, sesion);
            }

        }

        public Upost2 cargarPost(Int32 id_post,Int32 userid)
        {
            Dpost cargar = new Dpost();
            Int32 post_id = id_post;
            Int32 user_id = userid;
            DataTable datos_post = cargar.cargar_mod_post(post_id, user_id);
            Upost2 respuesta = new Upost2();
            if (datos_post.Rows.Count > 0)
            {
               respuesta.Nombre = datos_post.Rows[0]["titulo"].ToString();
                respuesta.Descripcion = datos_post.Rows[0]["descripcion"].ToString();
                respuesta.Etiquetas = datos_post.Rows[0]["etiquetas"].ToString();
                respuesta.Contenido = datos_post.Rows[0]["contenido"].ToString();
                if (datos_post.Rows[0]["fuente"].ToString() == "El Contenido es de mi autoria y/o Recopilacion de varias fuentes")
                {
                    respuesta.Fuentes1 = true;
                    respuesta.Fuentes2 = false;
                    respuesta.Autor = "";
                }
                else
                {
                    respuesta.Fuentes1 = false;
                    respuesta.Fuentes2 = true;
                    respuesta.Autor = datos_post.Rows[0]["fuente"].ToString();
                }
                respuesta.Miniatura = datos_post.Rows[0]["miniatura"].ToString();
                //editor1.Value= datos_post.Rows[0]["contenido"].ToString();
                respuesta.Categoria = datos_post.Rows[0]["id_categoria"].ToString();
            }
            return respuesta;
        }

        public void aceptar_denuncia(Int32 post_id,String comando)
        {
            if (comando == "eliminar")
            {

                DDenuncia eliminar = new DDenuncia();
                DataTable informacion = eliminar.aceptar_denuncia_comentario(post_id);
            }
        }
        public String terminar_mod(Upost datos, String sesion, Int32 user_id,Int32 post_id,bool autor,String miniatura)
        {
            String respuesta = null;

            Dpost publicar = new Dpost();
            Epublicacion post = new Epublicacion();
            post.Nombre = datos.Nombre;
            post.Descripcion = datos.Descripcion;
            post.Contenido = datos.Contenido;
            post.Categoria = datos.Categoria;
            post.Etiquetas = datos.Etiquetas;
            post.Miniatura = datos.Miniatura;

            if (post.Miniatura == "error")
            {
                post.Miniatura = miniatura;
            }


            if (autor == true)
            {
                post.Autor = datos.Autor;
            }
            else
            {
                post.Autor = "El Contenido es de mi autoria y/o Recopilacion de varias fuentes";
            }


            DataTable informacion = publicar.modificar_post(post, user_id, sesion, post_id);

            if (informacion.Rows.Count != 0)
            {
                string frase = informacion.Rows[0][0].ToString();
                respuesta = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                           "setInterval('guardar()', 1500);" +
                           "function guardar() { window.location.href='" + "Post.aspx?id=" + post_id.ToString() + "'; }</script>";
            }
            else
            {


            }
            return respuesta;
        }

        public String[] recibir_denuncia_post(String userid,String username, Int32 postid, String opcion, String argumento)
        {
            String[] mensaje = new String[2];
            string descripcion;
            if (username == null || userid == null)
            {
                string frase = "Inicia Sesion Para Poder Realizar La Denuncia";
               mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> "
                    + frase.ToString() + "</div>      <div class='modal-footer'>  <a href='../login/ingresar.aspx'  class='btn btn-success'>Iniciar Sesion</a>   <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
               mensaje[1] = "";
            }
            else
            {
                mensaje[0] = "";
                try
                {
                    DDenuncia denuncia = new DDenuncia();
                    Int32 user_id = Int32.Parse(userid);
                    switch (opcion)
                    {
                        case "1":
                            descripcion = "Viola derechos de autor - ";
                            break;
                        case "2":
                            descripcion = "Contenido Inapropiado - ";
                            break;
                        default:
                            descripcion = "Otro - ";
                            break;

                    }
                    descripcion += argumento;
                    DataTable informacion = denuncia.denuncia_publicacion(user_id, postid, descripcion);
                    if (informacion.Rows.Count != 0)
                    {
                        string frase = informacion.Rows[0][0].ToString();
                       mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                           "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                        mensaje[1] = "";
                    }
                    else
                    {
                        string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                       mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                           "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";

                    }
                }
                catch
                {
                    string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                   mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                }

            }
            return mensaje;
        }
    }
}
