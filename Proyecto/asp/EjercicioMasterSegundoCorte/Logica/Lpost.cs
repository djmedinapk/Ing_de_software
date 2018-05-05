using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using Encapsulados;
using System.Data;
using System.IO;
using Persistencia;
using Tablas;
namespace Logica
{
    public class Lpost
    {

        public String publicarPost(Upost datos,bool autor,String modo, String sesion,Int32 user_Id)
        {
            String respuesta = null;
            publicacion neww = new publicacion();
            neww.titulo = datos.Nombre;
            neww.descripcion = datos.Descripcion;
            neww.contenido = datos.Contenido;
            neww.id_categoria = datos.Categoria;
            neww.etiquetas = datos.Etiquetas;
            neww.miniatura = datos.Miniatura;
            if (autor == true)
            {
                neww.fuente = datos.Autor;
            }
            else
            {
                neww.fuente = "El Contenido es de mi autoria y/o Recopilacion de varias fuentes";
            }
            neww.fecha = DateTime.Now;
            neww.id_estado = 3;
            neww.visitas = 0;
            neww.id_usuario = user_Id;
            if (modo == "1")
            {
                neww.seccion = "privado";
            }
            else
            {
                neww.seccion = "publico";
            }
            Ppost solicitud = new Ppost();
            solicitud.publicarPost(neww);
            // db.publicaciones.Add(neww);
            //db.SaveChanges();
            string mensaje = "<strong>Se relizo la publicacion</strong>, espera a que un moderador la acepte";
                respuesta = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + mensaje + "</div>      <div class='modal-footer'><a href='../perfil/perfil.aspx' data-dismiss='modal'  class='btn btn-success'>Ir a perfil</a>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                        "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                        "setInterval('guardar()', 1500);" +
                        "function guardar() { window.location.href=\"../perfil/perfil.aspx\"; }</script>";

            
            //Dpost publicar = new Dpost();
            //Epublicacion post = new Epublicacion();
            //post.Nombre = datos.Nombre;
            //post.Descripcion = datos.Descripcion;
            //post.Contenido = datos.Contenido;
            //post.Categoria = datos.Categoria;
            //post.Etiquetas = datos.Etiquetas;
            //post.Miniatura = datos.Miniatura;

            //if (autor == true)
            //{
            //    post.Autor = datos.Autor;
            //}
            //else
            //{
            //    post.Autor = "El Contenido es de mi autoria y/o Recopilacion de varias fuentes";
            //}
            ////DataTable informacion = null; 

            ////if (modo == "1")
            ////{
            ////    informacion = publicar.ingresar_post(post, user_Id, sesion, 1);
            ////}
            ////else
            ////{
            ////    informacion = publicar.ingresar_post(post, user_Id, sesion, 0);
            ////}



            //if (informacion.Rows.Count != 0)
            //{
            //    string frase = informacion.Rows[0][0].ToString();
            //    if (frase == "Ingreso_exitoso")
            //    {
            //        string mensaje = "<strong>Se relizo la publicacion</strong>, espera a que un moderador la acepte";
            //        respuesta = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + mensaje + "</div>      <div class='modal-footer'><a href='../perfil/perfil.aspx' data-dismiss='modal'  class='btn btn-success'>Ir a perfil</a>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
            //              "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
            //              "setInterval('guardar()', 1500);" +
            //             "function guardar() { window.location.href=\"../perfil/perfil.aspx\"; }</script>";

            //    }
            //    else
            //    {
            //        string mensaje = "Error al prrocesar la solicitud";
            //        respuesta = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + mensaje + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
            //              "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
            //              "setInterval('guardar()', 1500);" +
            //               "function guardar() { window.location.href=\"../perfil/perfil.aspx\"; }</script>";
            //    }

            //}
            //else
            //{

            //    string mensaje = "<strong>Upssss!</strong> Algo ha salido mal intenta recargar la pagina y vuelve a intentarlo";
            //    respuesta = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + mensaje + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
            //              "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
            //              "setInterval('guardar()', 1500);" +
            //               "function guardar() { window.location.href=\"../perfil/perfil.aspx\"; }</script>";
            //}

            return respuesta;
        }
        public void eliminarPost(Int32 post_id, String comando, String sesion)
        {
            if (comando == "eliminar")
            {
                //Dpost eliminar = new Dpost();
                //DataTable informacion = eliminar.eliminar_post(post_id, sesion);
                Ppost solicitud = new Ppost();
                solicitud.eliminarPost(post_id);
            }
            if (comando == "validar")
            {
                //Dpost validar = new Dpost();
                //DataTable informacion = validar.validar_post(post_id, sesion);
                Ppost solicitud = new Ppost();
                solicitud.validarPost(post_id);
            }

        }

        public String terminar_mod(Upost datos, String sesion, Int32 user_id, Int32 post_id, bool autor, String miniatura)
        {
            String respuesta = null;
            using (ForoUdecContext db = new ForoUdecContext("post"))
            {
                publicacion neww = db.publicaciones.Find(post_id);
                neww.titulo = datos.Nombre;
                neww.descripcion = datos.Descripcion;
                neww.contenido = datos.Contenido;
                neww.id_categoria = datos.Categoria;
                neww.etiquetas = datos.Etiquetas;
                neww.miniatura = datos.Miniatura;
                if (autor == true)
                {
                    neww.fuente = datos.Autor;
                }
                else
                {
                    neww.fuente = "El Contenido es de mi autoria y/o Recopilacion de varias fuentes";
                }
                neww.id_estado = 3;
                Ppost solicitud = new Ppost();
                solicitud.modificarPost(neww);
                // db.SaveChanges();
                string mensaje = "<strong>Se relizo la publicacion</strong>, espera a que un moderador la acepte";
                respuesta = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + mensaje + "</div>      <div class='modal-footer'><a href='../perfil/perfil.aspx' data-dismiss='modal'  class='btn btn-success'>Ir a perfil</a>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                      "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                      "setInterval('guardar()', 1500);" +
                     "function guardar() { window.location.href=\"../perfil/perfil.aspx\"; }</script>";

            }
            //String respuesta = null;

            //Dpost publicar = new Dpost();
            //Epublicacion post = new Epublicacion();
            //post.Nombre = datos.Nombre;
            //post.Descripcion = datos.Descripcion;
            //post.Contenido = datos.Contenido;
            //post.Categoria = datos.Categoria;
            //post.Etiquetas = datos.Etiquetas;
            //post.Miniatura = datos.Miniatura;

            //if (post.Miniatura == "error")
            //{
            //    post.Miniatura = miniatura;
            //}


            //if (autor == true)
            //{
            //    post.Autor = datos.Autor;
            //}
            //else
            //{
            //    post.Autor = "El Contenido es de mi autoria y/o Recopilacion de varias fuentes";
            //}


            //DataTable informacion = publicar.modificar_post(post, user_id, sesion, post_id);

            //if (informacion.Rows.Count != 0)
            //{
            //    string frase = informacion.Rows[0][0].ToString();
            //    respuesta = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
            //       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
            //               "setInterval('guardar()', 1500);" +
            //               "function guardar() { window.location.href='" + "Post.aspx?id=" + post_id.ToString() + "'; }</script>";
            //}
            //else
            //{


            //}
            return respuesta;
        }
        //public void aceptar_denuncia(Int32 post_id, String comando,Int32 comentario_id)
        //{
        //    if (comando == "eliminar")
        //    {
        //        //DDenuncia eliminar = new DDenuncia();
        //        //DataTable informacion = eliminar.aceptar_denuncia_comentario(post_id);
        //        using (ForoUdecContext db = new ForoUdecContext("denuncia"))
        //        {
        //            denuncia_comentario pd = db.denuncia_comentarios.Find(post_id);
        //            pd.id_estado = 2;
        //            db.SaveChanges();
        //        }
        //    }
        //}
//persis ---------------------------Fin Persistencia-------------
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

        public String[] cargar_Imagen(String nombreArchivo, String sesion, String tpostnombre, String extension,String carpeta_destino, String saveLocation)
        {
            String[] url = new String[2];
            url[0] = "";
            if (!Directory.Exists(carpeta_destino))
            {
                Directory.CreateDirectory(carpeta_destino);
            }

            if (nombreArchivo != null)
            {
                

                if (!(extension.Equals(".jpg") || extension.Equals(".gif") || extension.Equals(".jpge") || extension.Equals(".png")))
                {
                    // cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo de archivo no valido');</script>");
                    url[0] = "error";
                }
                else
                {

                    if (System.IO.File.Exists(saveLocation))
                    {
                        //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');</script>");
                        url[0] = "~\\Imagenes\\Post" + "\\" + sesion + "\\" + tpostnombre + "\\" + nombreArchivo;
                        url[1] = "";
                    }
                    else
                    {

                        try
                        {
                           url[1]= saveLocation;
                            //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo ha sido cargado');</script>");
                            url[0] = "~\\Imagenes\\Post" + "\\" + sesion + "\\" + tpostnombre + "\\" + nombreArchivo;
                        }
                        catch (Exception exc)
                        {
                            //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error: al cargar la imagen');</script>");
                        }
                    }
                }
                return url;
            }
            else {  url[0] = ""; return url; }
        }
        public void aceptar_denuncia(Int32 post_id,String comando)
        {
            if (comando == "eliminar")
            {

                DDenuncia eliminar = new DDenuncia();
                DataTable informacion = eliminar.aceptar_denuncia_comentario(post_id);
            }
            
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
        public String[] enviarPuntuacion(String userid, String username, Int32 postid, int puntuacion)
        {
            String[] mensaje = new String[2];
            if (username == null || userid == null)
            {
                string frase = "Inicia Sesion Para Poder Puntuar este Post";
                mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>  <a href='../login/ingresar.aspx'  class='btn btn-success'>Iniciar Sesion</a>   <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                mensaje[1] = "";
            }
            else
            {
                try
                {
                    Dpost puntuar = new Dpost();
                    DataTable informacion = puntuar.puntuar_post(puntuacion, int.Parse(userid), postid);
                    if (informacion.Rows.Count != 0)
                    {
                        string frase = informacion.Rows[0][0].ToString();
                       mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                           "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
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


        public String[] Denuncia_comentario(String userid, String username, Int32 comId, String descripcion)
        {
            String[] mensaje = new String[2];
            if (userid == null || username == null)
            {
                string frase = "Inicia Sesion Para Poder Realizar La Denuncia";
                mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>  <a href='../login/ingresar.aspx'  class='btn btn-success'>Iniciar Sesion</a>   <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                mensaje[1] = "";
            }
            else
            {
               mensaje[0] = "";
                try
                {
                    DDenuncia comentario = new DDenuncia();
                    DataTable informacion = comentario.denuncia_comentario(int.Parse(userid), comId, descripcion);
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
                    mensaje[1] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                }

            }
            return mensaje;
        }

        public String[] agregar_comentario(String userid, String username, Int32 comId, Int32 post_id, String contenido)
        {
            String[] mensaje = new String[3];
            if (userid == null || username == null)
            {
                string frase = "Inicia Sesion Para Poder Poder Comentar";
                mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>  <a href='../login/ingresar.aspx'  class='btn btn-success'>Iniciar Sesion</a>   <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
               mensaje[1] = "";
            }
            else
            {
                mensaje[0] = "";
                try
                {
                    Dpost comentario = new Dpost();
                    DataTable informacion = comentario.comentar_post(comId, int.Parse(userid), post_id, contenido);
                    if (informacion.Rows.Count != 0)
                    {
                        string frase = informacion.Rows[0][0].ToString();
                        mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                           "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                           "setInterval('guardar()', 1500);" +
                           "function guardar() { window.location.href='" + "Post.aspx?id=" + post_id + "'; }</script>";
                        mensaje[2] = "";
                        //Response.Redirect("~/view/post/Post.aspx?id=" + post.ToString());
                    }
                    else
                    {
                        string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                        mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                           "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                           "setInterval('guardar()', 1500);" +
                           "function guardar() { window.location.href='" + "Post.aspx?id=" + post_id + "'; }</script>";

                    }
                }
                catch
                {
                    string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                    mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                           "setInterval('guardar()', 1500);" +
                           "function guardar() { window.location.href='" + "Post.aspx?id=" + post_id + "'; }</script>";


                }

            }

            return mensaje;
        }
        public String[] agregar_comentario_privado(String userid, String username, Int32 comId, Int32 post_id, String contenido)
        {
            String[] mensaje = new String[3];
            if (userid == null || username == null)
            {
                string frase = "Inicia Sesion Para Poder Poder Comentar";
                mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>  <a href='../login/ingresar.aspx'  class='btn btn-success'>Iniciar Sesion</a>   <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                mensaje[1] = "";
            }
            else
            {
                mensaje[0] = "";
                try
                {
                    Dpost comentario = new Dpost();
                    DataTable informacion = comentario.comentar_post(comId, int.Parse(userid), post_id, contenido);
                    if (informacion.Rows.Count != 0)
                    {
                        string frase = informacion.Rows[0][0].ToString();
                        mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                           "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                           "setInterval('guardar()', 1500);" +
                           "function guardar() { window.location.href='" + "Post_udec.aspx?id=" + post_id + "'; }</script>";
                        mensaje[2] = "";
                        //Response.Redirect("~/view/post/Post.aspx?id=" + post.ToString());
                    }
                    else
                    {
                        string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                        mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                           "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                           "setInterval('guardar()', 1500);" +
                           "function guardar() { window.location.href='" + "Post_udec.aspx?id=" + post_id + "'; }</script>";

                    }
                }
                catch
                {
                    string frase = "Ha ocurrido algun error al procesar la solicitud intente recargar la pagina e intentando de nuevo";
                    mensaje[0] = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='#' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});" +
                           "setInterval('guardar()', 1500);" +
                           "function guardar() { window.location.href='" + "Post_udec.aspx?id=" + post_id + "'; }</script>";


                }

            }

            return mensaje;
        }

        public DataTable listar_categorias()
        {
            Dpost solicitud = new Dpost();
            DataTable categorias = solicitud.listar_categoria();
            return categorias;
        }
        public Upost3 ver_post(Int32 post_id, DataRow sesion)
        {
            Dpost solicitud = new Dpost();
            DataTable datospost = solicitud.ver_post(post_id);
            Upost3 dp1 = new Upost3();
            if (datospost.Rows.Count > 0)
            {
                if (datospost.Rows[0]["estado"].ToString() == "Activo")
                {
                    dp1.Titulo = datospost.Rows[0]["titulo"].ToString();
                    dp1.Contenido = datospost.Rows[0]["contenido"].ToString();
                    dp1.Fuentes = "Fuente: " + datospost.Rows[0]["fuente"].ToString();
                    dp1.Categoria = "Categoria(s): " + datospost.Rows[0]["categoria"].ToString();
                    dp1.Username = datospost.Rows[0]["username"].ToString();
                    dp1.Avatar = datospost.Rows[0]["avatar_username"].ToString();
                    dp1.Urlperfil = "~/view/perfil/verPerfil.aspx?id=" + datospost.Rows[0]["id_usuario"].ToString();
                    dp1.Avatarimg = dp1.Urlperfil;
                    dp1.Totalpubs = datospost.Rows[0]["posts"].ToString();
                    dp1.Totalcoments = datospost.Rows[0]["comentarios"].ToString();
                    dp1.P1 = true;
                    dp1.P2 = true;
                    dp1.P3 = true;
                    dp1.P4 = true;
                    dp1.P5 = true;
                    dp1.BagregarComentario1 = true;
                    dp1.PagregarComentario1 = true;
                    dp1.Respons = null;
                }
                else
                {
                    if (sesion != null)
                    {
                        var papas = sesion;
                        if (int.Parse(papas["id_permisos"].ToString()) == 1 || int.Parse(papas["id_permisos"].ToString()) == 4 || int.Parse(papas["id"].ToString()) == int.Parse(datospost.Rows[0]["id_usuario"].ToString()))
                        {
                            dp1.Titulo = datospost.Rows[0]["titulo"].ToString();
                            dp1.Contenido = datospost.Rows[0]["contenido"].ToString();
                            dp1.Fuentes = "Fuente: " + datospost.Rows[0]["fuente"].ToString();
                            dp1.Categoria = "Categoria(s): " + datospost.Rows[0]["categoria"].ToString();
                            dp1.Username = datospost.Rows[0]["username"].ToString();
                            dp1.Avatar = datospost.Rows[0]["avatar_username"].ToString();
                            String urlPerfil = "~/view/perfil/verPerfil.aspx?id=" + datospost.Rows[0]["id_usuario"].ToString();
                            dp1.Avatarimg = urlPerfil;
                            dp1.P1 = false;
                            dp1.P2 = false;
                            dp1.P3 = false;
                            dp1.P4 = false;
                            dp1.P5 = false;
                            dp1.Lpuntuacion1 = "";
                            dp1.BagregarComentario1 = false;
                            dp1.PagregarComentario1 = false;
                            dp1.Respons = null;
                        }
                        else
                        {
                            dp1.Respons="../home/index.aspx";

                        }
                    }
                    else
                    {
                        dp1.Respons = "../home/index.aspx";

                    }
                }

            }
            else
            {
                dp1.Respons = "../home/index.aspx";
            }

            Dpost visitar = new Dpost();
            DataTable visita = visitar.visita_post(post_id);
            return dp1;
        }

        public DataTable listar_ver_post_home(String orden)
        {
            Dpost solicitud = new Dpost();
            DataTable post = solicitud.ver_post_home(orden);
            return post;
        }
        public DataTable listar_ver_comentarios_post(int post_id, int comentario)
        {
            Dpost solicitud = new Dpost();
            DataTable post = solicitud.ver_comentarios(post_id, comentario);
            return post;
        }
        public DataTable listar_ver_post_moderador(String orden)
        {
            Dpost solicitud = new Dpost();
            DataTable post = solicitud.listar_post_moderador(orden);
            return post;
        }
        public DataTable listar_busqueda(String info)
        {
            Dpost solicitud = new Dpost();
            DataTable post = solicitud.busqueda(info);
            return post;
        }
        public DataTable listar_categorias_home(String orden)
        {
            Dpost solicitud = new Dpost();
            DataTable post = solicitud.ver_post_home_categoria(orden);
            return post;
        }
        
        public DataTable ver_post_home_private(string orden)
        {
            Dpost solicitud = new Dpost();
            DataTable post = solicitud.ver_post_home_private(orden);
            return post;
        }
        public DataTable ver_post_home_categoria_private(string orden)
        {
            Dpost solicitud = new Dpost();
            DataTable post = solicitud.ver_post_home_categoria_private(orden);
            return post;
        }
        public DataTable listar_busqueda_private(String info)
        {
            Dpost solicitud = new Dpost();
            DataTable post = solicitud.busqueda_private(info);
            return post;
        }
        public DataTable mostar_denuncia_comentario()
        {
            DDenuncia solicitud = new DDenuncia();
            DataTable post = solicitud.mostar_denuncia_comentario();
            return post;
        }
        public DataTable eliminar_denuncia_comentario(Int32 id_denuncia)
        {
            DDenuncia solicitud = new DDenuncia();
            DataTable post = solicitud.eliminar_denuncia_comentario(id_denuncia);
            return post;
        }
    }
}
