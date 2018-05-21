using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using Encapsulados;
using Persistence;

namespace Logica
{
    public class LPerfil
    {
        public String modificar_datos_pers(int userid, Uadmin_actualizar_usuario2 newData, String sesion)
        {

            String popup = "";
            //Dperfil news = new Dperfil();
            PsqlPerfil news = new PsqlPerfil();
            Eadmin_actualizar_usuario_2 datos = new Eadmin_actualizar_usuario_2();
            datos.Id = newData.Id;
            datos.Nombre = newData.Nombre;
            datos.Apellido = newData.Apellido;
            datos.Edad = newData.Edad;
            datos.Sexo = newData.Sexo;
            //datos.Session = newData.Session;
            datos.Avatar = newData.Avatar;

            DataTable informacion = news.modificarDatos(userid, datos, sesion);
            popup = confirm_mod(informacion);            //Verifica si se agrego la informacion y devuelve el popUp
            return popup;
        }

        public String[] generar_url(String carpeta_destino, String nombreArchivo, String extension)
        {


            if (!Directory.Exists(carpeta_destino))
            {

                Directory.CreateDirectory(carpeta_destino);
            }


            String[] url = new String[2];

            if (nombreArchivo != "")
            {
                string saveLocation = carpeta_destino + "\\" + nombreArchivo;
                url[0] = "";
                url[1] = saveLocation;
                if (!(extension.Equals(".jpg") || extension.Equals(".gif") || extension.Equals(".jpge") || extension.Equals(".png")))
                {
                    //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo de archivo no valido');</script>");
                    url[0] = "archivo_no_valido";
                    url[1] = "";
                }
                return url;
            }
            else
            {
                url[1] = "";
                url[0] = "sin_cargar";
                return url;
            }
        }

        public String poner_imagen(String[] url)
        {
            String avatar = "";
            if (url[0] != "error" && url[0] != "archivo_no_valido" && url[0] != "sin_cargar")
            {
                avatar = url[2];                                  //Guarda la direccion de la imagen del avatar en BD
            }
            else
            {
                if (url[0] != "archivo_no_valido")
                {
                    if (url[0] != "sin_cargar")
                    {
                        //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error: al cargar la imagen');</script>");
                        avatar = "sinActualizar";

                    }
                    else
                    {
                        // cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo De Archivo no Valido');</script>");
                        avatar = "sinActualizar";
                    }

                }
                else
                {
                    //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo De Archivo no Valido');</script>");
                    avatar = "sinActualizar";
                }
            }
            return avatar;
        }
        public String confirm_mod(DataTable informacion)
        {
            String popup = "";
            if (informacion.Rows.Count != 0)
            {
                string frase = informacion.Rows[0][0].ToString();
                if (frase == "Registro_exitoso")
                {

                    popup = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> Se han guardado Los cambios</div>      <div class='modal-footer'>     <a href='../perfil/Perfil.aspx' class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                    //Response.Redirect("../perfil/Perfil.aspx");
                }
                else
                {
                    popup = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> Ha ocurrido algun Error por favor recarga la pagina e intentanuevamente</div>      <div class='modal-footer'>     <a href='../perfil/Perfil.aspx'   class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                }

            }
            return popup;
        }


        public Uperfil_campos gestionar_nuevos_datos(Uadmin_actualizar_usuario datos, int userid, String sesion) //Trae los datos antiguos del usuario/ recibe los nuevos datos del formulario
        {
            String oldusername = null;
            String oldcorreo = null;
            String oldpassword = null;

            // Traer los datos antiguos
            Uperfil_campos data = new Uperfil_campos();
            // Dperfil old = new Dperfil();
            PsqlPerfil old = new PsqlPerfil();
            DataTable datosSesion = old.traerDatosSesion(userid);
            if (datosSesion.Rows.Count > 0)
            {
                oldusername = datosSesion.Rows[0]["username"].ToString();
                oldcorreo = datosSesion.Rows[0]["correo"].ToString();
                oldpassword = datosSesion.Rows[0]["pasword"].ToString();
            }

            //Recibir los datos nuevos
            Eadmin_actualizar_usuario datosAjustes = new Eadmin_actualizar_usuario();
            datosAjustes.Username = datos.Username;
            datosAjustes.Correo = datos.Correo;
            encryption encripto = new encryption();
            datosAjustes.Password = encripto.encrypto(datos.Password);
            //datosAjustes.Session = datos.Session;

            //Comparar NEW VS OLD
            if (datosAjustes.Password == "2122914021714301784233128915223624866126")
            {
                datosAjustes.Password = oldpassword;
            }

            if (oldusername == datosAjustes.Username && oldcorreo == datosAjustes.Correo && datosAjustes.Password == oldpassword)
            {
                data.Popup = "";
                data.Pass2 = "";
                data.Pass1 = "";
            }
            else
            {
                //Dperfil ajustes = new Dperfil();
                PsqlPerfil ajustes = new PsqlPerfil();
                DataTable informacion = ajustes.modificar_perfil_ajustes(userid, sesion, datosAjustes);
                if (informacion.Rows.Count != 0)
                {
                    string frase = informacion.Rows[0][0].ToString();
                    data.Popup = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> " + frase.ToString() + "</div>      <div class='modal-footer'>     <a href='../perfil/Perfil.aspx' class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                       "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                    if (frase == "Cambios Guardados")
                    {
                        data.Username = datosAjustes.Username;
                    }

                    data.Pass2 = "";
                    data.Pass1 = "";
                    //Response.Redirect("../perfil/Perfil.aspx");
                }
            }
            return data;
        }
        public DataTable Llistar_post_perfil(Int32 user_id,String sesion)
        {
            // Dperfil solicitud = new Dperfil();
            PsqlPerfil solicitud = new PsqlPerfil();
            DataTable posts = solicitud.listar_post(user_id, sesion);
            return posts;
        }
        public DataTable Llistar_post_perfil_private(Int32 user_id, String sesion)
        {
            //Dperfil solicitud = new Dperfil();
            PsqlPerfil solicitud = new PsqlPerfil();
            DataTable posts = solicitud.listar_post_private(user_id, sesion);
            return posts;
        }
        public DataTable Llistar_post_perfil_public(Int32 user_id, String sesion)
        {
            //Dperfil solicitud = new Dperfil();
            PsqlPerfil solicitud = new PsqlPerfil();
            DataTable posts = solicitud.listar_post_public(user_id, sesion);
            return posts;
        }

        public Uvista_perfil vista_perfil(Int32 userid)
        {
            //Dperfil datos_usuario = new Dperfil();
            PsqlPerfil datos_usuario = new PsqlPerfil();
            DataTable datos_user = datos_usuario.traerDatos_vistaPerfil(userid);
            Uvista_perfil respuesta = new Uvista_perfil();
            if (datos_user.Rows.Count > 0)
            {
                if (datos_user.Rows[0]["avatar"].ToString() != "")
                {
                    respuesta.ImageUrl = datos_user.Rows[0]["avatar"].ToString();
                }
                else
                {
                    respuesta.ImageUrl = "~\\Imagenes\\Default\\123.jpg";
                }
                
                respuesta.Username= datos_user.Rows[0]["username"].ToString();
                respuesta.TotalPublic= datos_user.Rows[0]["posts"].ToString();
                respuesta.Estado= datos_user.Rows[0]["estado"].ToString();
                respuesta.Nombre= datos_user.Rows[0]["nombre"].ToString();
                respuesta.Edad= datos_user.Rows[0]["edad"].ToString();
                respuesta.Genero= datos_user.Rows[0]["sexo"].ToString();
                respuesta.Response = null;
            }
            else
            {
                respuesta.Response="~/view/home/index.aspx";
            }
            return respuesta;
        }

        public Utraer_datos traer_d(DataRow sesion)
        {
            Utraer_datos respuesta = new Utraer_datos();
            //Dperfil old = new Dperfil();
            PsqlPerfil old = new PsqlPerfil();
            DataTable datosold = old.traerDatos(int.Parse(sesion["id"].ToString()));
            DataTable datosSession = old.traerDatosSesion(int.Parse(sesion["id"].ToString()));

            DataTable correoIns = old.traerCorreoInstitucional(int.Parse(sesion["id"].ToString()));

            if (datosSession.Rows.Count > 0)
            {
                respuesta.TperfilAjustesUsername = datosSession.Rows[0]["username"].ToString();
                respuesta.TperfilAjustesCorreo = datosSession.Rows[0]["correo"].ToString();
                respuesta.LtotalPublic = datosSession.Rows[0]["posts"].ToString();



            }
            if (datosold.Rows.Count > 0)
            {
                respuesta.Lpopup = "";
                respuesta.TperfilNombre= datosold.Rows[0]["nombre"].ToString();
                respuesta.TperfilApellido = datosold.Rows[0]["apellido"].ToString();
                respuesta.TperfilEdad = datosold.Rows[0]["edad"].ToString();
                respuesta.IperfilImage= datosold.Rows[0]["avatar"].ToString();
                respuesta.RB1= datosold.Rows[0]["sexo"].ToString();
            }
            else
            {
                respuesta.Lpopup = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'>      <div class='modal-header'>     <button type='button' class='close' data-dismiss='modal' aria-hidden='true'>&times;</button>         <h4>Bienvenido A ForoUdec</h4>  </div>      <div class='modal-body'>         <h4>Opciones de Perfil</h4>         Antes de comenzar, te surgerimos que completes tu perfil.      </div>      <div class='modal-footer'>     <a href='#v-pills-profile' data-dismiss='modal' data-toggle='pill'  role='tab' aria-controls='v-pills-profile'  class='btn btn-danger'>Ir a Perfil</a>  </div>   </div></div></div>" +
                    "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                respuesta.IperfilImage = "~\\Imagenes\\Default\\123.jpg";
            }
            if (correoIns.Rows.Count > 0)
            {
                if (correoIns.Rows[0][0].ToString() != "")
                {

                    respuesta.Bcorreoins= false;
                    respuesta.Tcorreoins = true;
                    respuesta.Tcorreoins2 = correoIns.Rows[0][0].ToString();
                    respuesta.Pprivados = true;
                }
                else
                {
                    respuesta.Pprivados = false;
                    respuesta.Bcorreoins = true;
                    respuesta.Tcorreoins = false;
                    respuesta.Tcorreoins2 = "";
                }
            }
            else
            {
                respuesta.Pprivados= false;
                respuesta.Bcorreoins = true;
                respuesta.Tcorreoins = false;
                respuesta.Tcorreoins2 = "";
            }

            return respuesta;
        }
        public String enviarcodigo(String mail)
        {
            //-------------codigo ramdomaniaco para verificar token fuente:http://joefay.blogspot.com.co/2012/04/generar-cadenas-de-texto-aleatorio.html
            Random obj = new Random();
            string posibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = posibles.Length;
            char letra;
            int longitudnuevacadena = 5;
            string nuevacadena = "";
            for (int i = 0; i < longitudnuevacadena; i++)
            {
                letra = posibles[obj.Next(longitud)];
                nuevacadena += letra.ToString();
            }
            String auxsinvalor = nuevacadena;
            Lcorreo correo = new Lcorreo();
            String mensajecorreo = "<html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /><title>Validar Correo</title></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0'>  <tr>  " +
                    "  <td align='center' valign='top' bgcolor='#FFFFFF' style='background-color:#FFFFFF;'><br>    <tr>        <td colspan='2' align='left' valign='top' bgcolor='#078B0A' style='background-color:#078B0A; padding:10px; font-family:Arial; color:#FFFFFF; font-size:60px;'>ForoUdec</td>    " +
                    "    </tr>        <td colspan='2' align='left' valign='top' bgcolor='#F2FB06' style='background-color:#F2FB06; padding:5px;'></td>        </tr>      <tr>      <tr>      <td style='background-color:#666666; width:100px; '>      	      </td>          " +
                    "  <td align='left' valign='top' style='font-family:Verdana, sans-serif; color:#232222;'>            <div style='font-size:24px;'><b>Verificar Correo Institucional</b></div>            <div style='font-size:14px;'><br>              <p>Para registrar el correo ingresa el siguiente codigo de seguridad<br> <b>" + nuevacadena + "</b>.</p></div>    " +
                    "             <div style='font-size:11px;'><br>                " +
                    " ForoUdec 2017 © Todos Los Derechos Reservados <br>  <br>               </div></td>          </tr>    <br>        </table>    <br>    <br></td>  </tr></table></body></html>";
            //*********************************************************************************
            correo.enviarCorreo(mail, nuevacadena, mensajecorreo);
            
            String respuesta = nuevacadena;
            return respuesta;
        }

    }
}

