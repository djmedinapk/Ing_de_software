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

namespace Logica
{
    public class LPerfil
    {
        public String modificar_datos_pers(int userid, Uadmin_actualizar_usuario2 newData, String sesion)
        {

            String popup="";
            Dperfil news = new Dperfil();
            Eadmin_actualizar_usuario_2 datos = new Eadmin_actualizar_usuario_2();
            datos.Id = newData.Id;
            datos.Nombre = newData.Nombre;
            datos.Apellido = newData.Apellido;
            datos.Edad = newData.Edad;
            datos.Sexo = newData.Sexo;
            //datos.Session = newData.Session;
            datos.Avatar = newData.Avatar;

            DataTable informacion = news.modificarDatos(userid, datos,sesion);
            popup = confirm_mod(informacion);            //Verifica si se agrego la informacion y devuelve el popUp
            return popup;
        }

        public String [] generar_url(String carpeta_destino, String nombreArchivo, String extension)
        {


            if (!Directory.Exists(carpeta_destino))
            {

                Directory.CreateDirectory(carpeta_destino);
            }


            String []url = new String[2]; 
            
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
            else {
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
        public String confirm_mod(DataTable informacion) {
            String popup = "";
            if (informacion.Rows.Count != 0)
            {
                string frase = informacion.Rows[0][0].ToString();
                if (frase == "Registro_exitoso")
                {

                    popup = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> Se han guardado Los cambios</div>      <div class='modal-footer'>     <a href='../perfil/Perfil.aspx' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                    //Response.Redirect("../perfil/Perfil.aspx");
                }
                else
                {
                    popup = "<div class='modal fade' id='mostrarmodal' tabindex='-1' role='dialog' aria-labelledby='basicModal' aria-hidden='true'><div class='modal-dialog'>   <div class='modal-content'><div class='modal-body'> Ha ocurrido algun Error por favor recarga la pagina e intentanuevamente</div>      <div class='modal-footer'>     <a href='../perfil/Perfil.aspx' data-dismiss='modal'  class='btn btn-danger'>cerrar</a>  </div>   </div></div></div>" +
                   "<script>$(document).ready(function(){   $('#mostrarmodal').modal('show');});</script>";
                }

            }
            return popup;
        }


        public Uperfil_campos gestionar_nuevos_datos(Uadmin_actualizar_usuario datos, int userid,String sesion) //Trae los datos antiguos del usuario/ recibe los nuevos datos del formulario
        {
            String oldusername = null;
            String oldcorreo = null;
            String oldpassword = null;

            // Traer los datos antiguos
            Uperfil_campos data = new Uperfil_campos();
            Dperfil old = new Dperfil();
            DataTable datosSesion = old.traerDatosSesion(userid);
            if (datosSesion.Rows.Count > 0)
            {
                oldusername = datosSesion.Rows[0]["username"].ToString();
                oldcorreo = datosSesion.Rows[0]["correo"].ToString();
                oldpassword = datosSesion.Rows[0]["pasword"].ToString();
            }
            
            //Recibir los datos nuevos
            Eadmin_actualizar_usuario datosAjustes =  new Eadmin_actualizar_usuario ();
            datosAjustes.Username = datos.Username;
            datosAjustes.Correo = datos.Correo;
            datosAjustes.Password = datos.Password;
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
                Dperfil ajustes = new Dperfil();
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
    }
}
