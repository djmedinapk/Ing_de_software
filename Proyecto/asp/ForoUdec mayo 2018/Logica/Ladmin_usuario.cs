using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using Encapsulados;
using System.Data;
using Persistencia;
using Tablas;
using Persistence;

namespace Logica
{
    public class Ladmin_usuario
    {
        //clase para evaluar si es postback
        //public bool posb(bool entrada)
        //{
        //    if(entrada==false)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        public Uadmin_ver_usuario ver_llenar_campos_usuario(String comando, Int32 id)
        {
            Uadmin_ver_usuario usuariodd = new Uadmin_ver_usuario();
            if (comando == "ver")
            {
                //Dadmin consulta = new Dadmin();
                //DataTable dato = consulta.datos_usuario(id);

                //if (dato.Rows.Count > 0)
                //{
                //    //usuario.Alerta = Alerta("id" + dato.Rows[0]["id"].ToString(), "rojo");
                //    usuario.Id = dato.Rows[0]["id"].ToString();
                //    usuario.Username = dato.Rows[0]["username"].ToString();
                //    usuario.Correo = dato.Rows[0]["correo"].ToString();
                //    usuario.Password = dato.Rows[0]["pasword"].ToString();
                //    usuario.Nsesion = dato.Rows[0]["n_sesiones"].ToString();
                //}
                //else
                //{
                //    usuario.Alerta = Alerta("No Se Encontro EL usuario", "rojo");
                ////}
                //Puser solicitud = new Puser();
                PsqlLogin solicitud = new PsqlLogin();
                user_session user = solicitud.traerUser(id);

                if (user!=null)
                {
                    //usuario.Alerta = Alerta("id" + dato.Rows[0]["id"].ToString(), "rojo");
                    usuariodd.Id = user.id.ToString();
                    usuariodd.Username = user.username;
                    usuariodd.Correo = user.correo;
                    usuariodd.Password = user.pasword;
                    usuariodd.Nsesion = user.n_sesiones.ToString();
                }
                else
                {
                    usuariodd.Alerta = Alerta("No Se Encontro EL usuario", "rojo");
                }

                
            }
            return usuariodd;
        }
        //Persi------------------Fin Persistencia---------------------------
        public void actualizarPerfil(Uadmin_ver_usuario_2 registro, Int32 id, String sessionId)
        {
            //Dadmin solicitud = new Dadmin();
            PsqlAdmin solicitud = new PsqlAdmin();
            Eadmin_actualizar_usuario_2 usuario = new Eadmin_actualizar_usuario_2();
            usuario.Id = id.ToString();
            usuario.Nombre = registro.Nombre;
            usuario.Apellido = registro.Apellido;
            usuario.Edad = registro.Edad;
            usuario.Session = sessionId;
            if (registro.Fem)
            {
                usuario.Sexo = "Femenino";
            }
            if (registro.Mas)
            {
                usuario.Sexo = "Masculino";
            }
            if (registro.Otro)
            {
                usuario.Sexo = "Otro";
            }
            solicitud.actualizar_perfil(usuario);
        }
        
        public void actualizarsesion(Uadmin_actualizar_usuario registro, Int32 id)
        {
            int admin = 0;
            String respuesta = null;
           // Dadmin solicitud = new Dadmin();
            PsqlAdmin solicitud = new PsqlAdmin();
            Eadmin_actualizar_usuario usuario = new Eadmin_actualizar_usuario();
            encryption encriptar = new encryption();
            usuario.Correo = registro.Correo;
            usuario.Password = encriptar.encrypto(registro.Password);
            usuario.Username = registro.Username;
            usuario.Session = registro.Session;
            if (registro.Admin)
            { admin = 1; }
            else { admin = 0; }

            string r = solicitud.actualizar_sesion(admin, id, usuario);

            solicitud.n_sesiones(usuario.Username, Int32.Parse(registro.Nsesion));


        }
        public Uadmin_ver_usuario_2 ver_llenar_campos_usuario_perfil(String comando, Int32 id)
        {
            Uadmin_ver_usuario_2 usuario = new Uadmin_ver_usuario_2();
            if (comando == "ver")
            {
                //Dadmin consulta = new Dadmin();
                PsqlAdmin consulta = new PsqlAdmin();
                DataTable dato = consulta.datos_usuario_perfil(id);
                
                if (dato.Rows.Count > 0)
                {
                    usuario.Nombre = dato.Rows[0]["nombre"].ToString();
                    usuario.Apellido = dato.Rows[0]["apellido"].ToString();
                    usuario.Edad = dato.Rows[0]["edad"].ToString();
                    switch (dato.Rows[0]["sexo"].ToString())
                    {
                        case "Masculino":
                            usuario.Mas = true;
                            usuario.Fem = false;
                            usuario.Otro = false;
                            break;
                        case "Femenino":
                            usuario.Mas = false;
                            usuario.Fem = true;
                            usuario.Otro = false;
                            break;
                        case "Otro":
                            usuario.Mas = true;
                            usuario.Fem = false;
                            usuario.Otro = true;
                            break;
                        default:
                            usuario.Mas = false;
                            usuario.Fem = false;
                            usuario.Otro = false;
                            break;
                    }
                }
                else
                {
                    // usuario.Alerta = Alerta("No Se Encontro EL usuario", "rojo");
                }
            }
            return usuario;
        }
        public String eliminar_response_redirect(String comando,Int32 id,String sessionId)
        {
            String respueta=null;

            if (comando == "eliminar")
            {
                // Dadmin eliminar = new Dadmin();
                PsqlAdmin eliminar = new PsqlAdmin();
                string informacion = eliminar.suspender_usuario(id, sessionId);
                respueta= "usuario.aspx";
            }
            return respueta;
        }
        public bool ver_estado_paneles(String comando)
        {
            bool respuesta=false;
            
            if (comando == "ver")
            {
                respuesta = true;
            }
            return respuesta;
        }
        
        
        private String Alerta(String mensaje, String tipo)
        {
            String boton;
            String aux = "dark";
            switch (tipo)
            {
                case "amarillo":
                    aux = "warning";
                    break;
                case "verde":
                    aux = "success";
                    break;
                case "azul":
                    aux = "primary";
                    break;
                case "gris":
                    aux = "dark";
                    break;
                case "rojo":
                    aux = "danger";
                    break;
            }
            boton = "<div class='alert alert-" + aux + " alert-dismissible show' role='alert'>" + mensaje +
                "  <button type='button' class='close' data-dismiss='alert' aria-label='Close'>" +
                "    <span aria-hidden='true'>&times;</span>" +
                "  </button>" +
                "</div> ";
            return boton;
        }

        
        
        public DataTable cargar_user()
        {
            // Dadmin solicitud = new Dadmin();
            PsqlAdmin solicitud = new PsqlAdmin();
            DataTable respuesta = solicitud.cargar_usuarios();
            return respuesta;
        }

    }
}
